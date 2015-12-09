using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DemoRD.DTO;
using DemoRD.Entity;




namespace DemoRD.Domain
    
{
    public class ClaimsData
    {   //get list of claims with all necessary informations like encrypted claim number
        //
        public static List<ClaimListItem> GetListClaimsFinal(string userNameDomain)
        {
            // XOR Claim number

            List<ClaimListItem> _listClaims = RepositoryEF.GetListClaim(userNameDomain);

            foreach (var item in _listClaims)
            {
                item.EncryptedClaimNumber = Crypto.EncryptXOR(item.ClaimNumber.ToString(), userNameDomain);
            }

            return _listClaims;

        }


        public static ClaimListItem GetClaimsDetail (string _claimNumberEncryptedXOR, string _userName)
        {

            long _claimNumberDecrypted =long.Parse(Crypto.DecryptXOR(_claimNumberEncryptedXOR, _userName));

            ClaimListItem _claimDetail = RepositoryEF.GetClaim(_claimNumberDecrypted);

            return _claimDetail;

        }

    }
}