using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using DemoRD.DTO;
using DemoRD.DB;
using System.Text;



namespace DemoRD.Domain
{
    public class Crypto
    {

        public static Guid userGUID { get; set; }



        private static byte[] EncryptPassword(string userName, string password, byte[] salt1, byte[] salt2)
        {
            string tmpPassword = null;

            // password + lots of salt
            tmpPassword = Convert.ToBase64String(salt1)
                     + Convert.ToBase64String(salt2)
                     + userName.ToLower() + password;

            //Convert the password string into an Array of bytes.
            UTF8Encoding textConverter = new UTF8Encoding();
            byte[] passBytes = textConverter.GetBytes(tmpPassword);


            return new SHA384Managed().ComputeHash(passBytes);

        }

        public static bool SavePassword(string firstName, string lastName, string login, string password)
        {


            byte[] _salt1 = GenerateSALT();
            byte[] _salt2 = GenerateSALT();

            byte[] _hashedPass = EncryptPassword(login, password, _salt1, _salt2);

            RepositoryDB.storePassword(firstName, lastName, login, _hashedPass, _salt1, _salt2);
           
         
            return true;

        }

        public static bool VerifyPassword(string login, string password)
        {
            User _user = RepositoryDB.getUser(login);

            //storing user GUID for 
            userGUID = _user.User_ID;

            byte[] _passwordHash = EncryptPassword(login, password, _user.Salt1, _user.Salt2);

            return PasswordsCompare(_passwordHash, _user.Hash);
        }


        // Just compare to two arrays for equality
        // You can add a length comparison, but normally
        // all hashes are the same size.
        private static bool PasswordsCompare(byte[] psswd1, byte[] psswd2)
        {
            try
            {
                for (int i = 0; i < psswd1.Length; i++)
                {
                    if (psswd1[i] != psswd2[i])
                        return false;
                }
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }
        }

        // Generate a six-byte salt
        private static byte[] GenerateSALT()
        {
            byte[] data = new byte[6];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(data);
            return data;
        }




        public static string EncryptXOR(string strIn, string strKey)
        {

            string sbOut = String.Empty;

            string _result = "";
            for (int i = 0; i < strIn.Length; i++)

            {
                _result = string.Format("{0:000}", strIn[i] ^ strKey[i % strKey.Length]);
                sbOut += _result;
            }

            return sbOut;
        }

        public static string DecryptXOR(string strIn, string strKey)
        {
            string sbOut = string.Empty;
            for (int i = 0; i < strIn.Length; i += 3)
            {
                byte code = Convert.ToByte(strIn.Substring(i, 3));
                sbOut += (char)(code ^ strKey[(i / 3) % strKey.Length]);
            }

            return sbOut;
        }

    }



}
