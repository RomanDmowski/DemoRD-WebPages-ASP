using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using DemoRD.DTO;


namespace DemoRD.DB
{
    public class RepositoryDB
    {

        // select TOP 100 claim_number,first_name,last_name,facility_name, date_claim, (select SUM(amount_billed) FROM Claim_services WHERE claim_number=Claims.claim_number) as 'amount',  (select SUM(patient_responsibility)  FROM Claim_services WHERE claim_number=Claims.claim_number) as 'patient_responibility' FROM Claims INNER JOIN Users ON Users.user_id= Claims.user_id Inner JOIN Facilities ON Facilities.facility_id = Claims.facility_id WHERE Claims.user_id='2ED3183E-056B-E511-AAD9-AC7289DB9A88' ORDER BY Claims.date_claim DESC
        public static List<ClaimListItem> GetListClaim(string userName)
        {

            ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            string connectionStr = "Data Source = " + connectionSetting.ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionStr);
            myConnection.Open();

            DataTable t = new DataTable();
            List<ClaimListItem> resultList = new List<ClaimListItem>();

            using (SqlDataAdapter a = new SqlDataAdapter(
            //"Select TOP 100 claim_number,first_name,last_name,facility_name, date_claim, (select SUM(amount_billed) FROM Claim_services WHERE claim_number=Claims.claim_number) as 'amount',  (select SUM(patient_responsibility)  FROM Claim_services WHERE claim_number=Claims.claim_number) as 'patient_responibility' FROM Claims INNER JOIN Users ON Users.user_id= Claims.user_id Inner JOIN Facilities ON Facilities.facility_id = Claims.facility_id WHERE Claims.user_id='" + user_id + "' ORDER BY Claims.date_claim DESC", myConnection))
            "Select TOP 100 claim_number,first_name,last_name,facility_name, date_claim, (select SUM(amount_billed) FROM Claim_services WHERE claim_number=Claims.claim_number) as 'amount',  (select SUM(patient_responsibility)  FROM Claim_services WHERE claim_number=Claims.claim_number) as 'patient_responibility' FROM Claims INNER JOIN Users ON Users.user_id= Claims.user_id Inner JOIN Facilities ON Facilities.facility_id = Claims.facility_id WHERE Users.login='" + userName + "' ORDER BY Claims.date_claim DESC", myConnection))
            {
                a.Fill(t);
            };

            foreach (DataRow row in t.Rows)
            {
                resultList.Add(convertDatarowToClaimListItem_ClaimDetails(row, userName, myConnection));
            }

            myConnection.Close();


            return resultList;

        }


        public static ClaimListItem GetClaim(long ClaimNumber)
        {

            ClaimListItem _resultClaim = new ClaimListItem();

            //string connectionStr = "Data Source = hp9887\\sql5422; Initial Catalog = test_entity; Integrated Security = True; MultipleActiveResultSets = True; Application Name = EntityFramework";

            ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            string connectionStr = "Data Source = " + connectionSetting.ConnectionString;
            SqlConnection myConnection = new SqlConnection(connectionStr);
            myConnection.Open();

            DataTable t = new DataTable();

            using (SqlDataAdapter a = new SqlDataAdapter(
            "Select TOP 100 claim_number,first_name,last_name,facility_name, date_claim FROM Claims INNER JOIN Users ON Users.user_id= Claims.user_id Inner JOIN Facilities ON Facilities.facility_id = Claims.facility_id WHERE Claims.claim_number=" + ClaimNumber + " ORDER BY Claims.date_claim DESC", myConnection))

            {
                a.Fill(t);
            };
            //It should be one row only
            DataRow _dataRow = t.Rows[0];

            _resultClaim = convertDatarowToClaimListItem_ListClaims(_dataRow, myConnection);

            myConnection.Close();

            return _resultClaim;

        }

        private static ClaimListItem convertDatarowToClaimListItem_ClaimDetails(DataRow _dataRowClaims, String _userName, SqlConnection _dbConnection)
        {

            try
            {

                ClaimListItem itemClaim = new ClaimListItem();

                itemClaim.ClaimNumber = _dataRowClaims.Field<long>("claim_number");
                itemClaim.PatientFirstName = _dataRowClaims.Field<string>("first_name");
                itemClaim.PatientLastName = _dataRowClaims.Field<string>("last_name");
                itemClaim.FacilityName = _dataRowClaims.Field<string>("facility_name");
                itemClaim.DateClaim = _dataRowClaims.Field<DateTime>("date_claim");

                itemClaim.AmountBilledSum = _dataRowClaims.Field<decimal?>("amount");
                itemClaim.PatientResponsibilitySum = _dataRowClaims.Field<decimal?>("patient_responibility");
             
                return itemClaim;
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry, there was an application problem. Technical description:" + ex.Message);
            }
        }



        private static ClaimListItem convertDatarowToClaimListItem_ListClaims(DataRow _dataRowClaims, SqlConnection _dbConnection)
        {
            ClaimListItem itemClaim = new ClaimListItem();

            //select TOP 100 claim_number,first_name,last_name,facility_name, date_claim FROM Claims

            itemClaim.ClaimNumber = _dataRowClaims.Field<long>("claim_number");
            itemClaim.PatientFirstName = _dataRowClaims.Field<string>("first_name");
            itemClaim.PatientLastName = _dataRowClaims.Field<string>("last_name");
            itemClaim.FacilityName = _dataRowClaims.Field<string>("facility_name");
            itemClaim.DateClaim = _dataRowClaims.Field<DateTime>("date_claim");

            itemClaim.StatusesClaimList = getStatusClaimList(itemClaim.ClaimNumber, _dbConnection);
            itemClaim.ServicesClaimList = getServicesClaimList(itemClaim.ClaimNumber, _dbConnection);

            return itemClaim;
        }

        private static User convert_DataRowToUser(DataRow _dataRowUser)
        {
            User itemUser = new User();

            itemUser.FirstName = _dataRowUser.Field<string>("first_name");
            itemUser.Hash = _dataRowUser.Field<byte[]>("hash");
            itemUser.LastName = _dataRowUser.Field<string>("last_name");
            itemUser.Login = _dataRowUser.Field<string>("login");

            //itemUser.Parent_User_id = null;

            itemUser.Salt1 = _dataRowUser.Field<byte[]>("salt1");
            itemUser.Salt2 = _dataRowUser.Field<byte[]>("salt2");
            itemUser.User_ID = _dataRowUser.Field<Guid>("user_id");

            return itemUser;
        }







        private static List<StatusClaim> getStatusClaimList(long claimNumber, SqlConnection sqlConn2)
        {

            DataTable statusTable = new DataTable();
            List<StatusClaim> resultList = new List<StatusClaim>();
            using (SqlDataAdapter a2 = new SqlDataAdapter(
            "SELECT * FROM Claim_status WHERE claim_number='" + claimNumber + "'", sqlConn2))
            {
                a2.Fill(statusTable);
            };

            foreach (DataRow row in statusTable.Rows)
            {
                //row.Field<int>(0)
                StatusClaim itemStatus = new StatusClaim();
                itemStatus.ClaimNumber = row.Field<long>("claim_number");
                itemStatus.DateStatus = row.Field<DateTime>("status_date");
                itemStatus.Status = row.Field<String>("status");

                resultList.Add(itemStatus);
            }

            return resultList;
        }


        private static List<ServiceClaim> getServicesClaimList(long claim_number, SqlConnection sqlConn2)
        {

            DataTable servicesTable = new DataTable();
            List<ServiceClaim> resultList = new List<ServiceClaim>();

            string result = "";


            using (SqlDataAdapter a2 = new SqlDataAdapter(
            "SELECT * FROM Claim_services WHERE claim_number=" + claim_number, sqlConn2))
            {
                a2.Fill(servicesTable);
            };

            foreach (DataRow row in servicesTable.Rows)
            {

                //row.Field<int>(0)
                ServiceClaim itemService = new ServiceClaim();

                itemService.AmountBilled = row.Field<decimal>("amount_billed");
                if (itemService.AmountBilled == -1) itemService.AmountBilled = 0;

                itemService.ClaimNumber = row.Field<long>("claim_number");
                itemService.DateVisited = row.Field<DateTime>("date_visited");

                itemService.PlanDiscount = row.Field<decimal>("plan_discount");
                if (itemService.PlanDiscount == -1) itemService.PlanDiscount = 0;

                itemService.DetailsText = row.Field<string>("service_details_text");

                itemService.PatientResponsibility = row.Field<decimal>("patient_responsibility");
                if (itemService.PatientResponsibility == -1) itemService.PatientResponsibility = 0;

                itemService.PlanPaid = row.Field<decimal>("plan_paid");
                if (itemService.PlanPaid == -1) itemService.PlanPaid = 0;



                resultList.Add(itemService);
                //
                result += itemService.DateVisited.ToShortDateString();

            }

            return resultList;
        }

        public static int IsLoginInDatabaseDB(string loginToTest)
        {
            // if something wrong return -1



            SqlConnection myConnection = null;
            //string connectionStr = "Data Source = hp9887\\sql5422; Initial Catalog = test_entity; Integrated Security = True; MultipleActiveResultSets = True; Application Name = EntityFramework";
            ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            string connectionStr = "Data Source = " + connectionSetting.ConnectionString;


            int _count = new int();

            //SELECT COUNT(*) AS NumberOfOrders FROM Orders;
            try
            {

                myConnection = new SqlConnection(connectionStr);

                myConnection.Open();
                //test r@wp.pl

                SqlCommand cmd = new SqlCommand("select COUNT(*) from Users where login = @Login", myConnection);
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@Login";
                param.Value = loginToTest;
                cmd.Parameters.Add(param);

                object _result = cmd.ExecuteScalar();


                if (_result != null)
                {
                    _count = (int)_result;
                }
                else
                {
                    _count = -1;
                }
                return _count;
            }
            finally
            {

                // close connection
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }

        }



        public static void storePassword(string _first_name, string _last_name, string _login, byte[] _hashPass, byte[] _salt01, byte[] _salt02)
        {

            SqlConnection myConnection = null;

            ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            string connectionStr = "Data Source = " + connectionSetting.ConnectionString;
            //string connectionStr = "Data Source = hp9887\\sql5422; Initial Catalog = test_entity; Integrated Security = True; MultipleActiveResultSets = True; Application Name = EntityFramework";


            try
            {

                myConnection = new SqlConnection(connectionStr);

                myConnection.Open();
              
                SqlCommand cmd = new SqlCommand("INSERT INTO Users (first_name, last_name, login, salt1, salt2, hash) VALUES(@first_name, @last_name, @login, @salt1, @salt2, @hash)", myConnection);
                SqlParameter param = new SqlParameter();



                cmd.Parameters.Add(new SqlParameter("@first_name", _first_name));
                cmd.Parameters.Add(new SqlParameter("@last_name", _last_name));
                cmd.Parameters.Add(new SqlParameter("@login", _login));
                cmd.Parameters.Add(new SqlParameter("@salt1", _salt01));
                cmd.Parameters.Add(new SqlParameter("@salt2", _salt02));
                cmd.Parameters.Add(new SqlParameter("@hash", _hashPass));

                int _countRecord = cmd.ExecuteNonQuery();



            }
            finally
            {

                // close connection
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }


        }

        public static User getUser(string login)
        {

            SqlConnection myConnection = null;

            ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            string connectionStr = "Data Source = " + connectionSetting.ConnectionString;


            User _user = new User();
            //SqlDataAdapter _sqlDataAdapter = null;
            DataTable userTable = new DataTable();

            try
            {
                myConnection = new SqlConnection(connectionStr);
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE login=@login", myConnection);
                //SqlParameter param = new SqlParameter();
                cmd.Parameters.Add(new SqlParameter("@login", login));
                //cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, 100,login));

                SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(cmd);
                // _sqlDataAdapter.InsertCommand = cmd;
                _sqlDataAdapter.Fill(userTable);

                DataRow _dataRow = userTable.Rows[0];

                _user = convert_DataRowToUser(_dataRow);

                return _user;
            }
            finally
            {
                // close connection
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }



        public static List<User> getListUser()
        {

            SqlConnection myConnection = null;

            ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            string connectionStr = "Data Source = " + connectionSetting.ConnectionString;


            User _user = new User();
            List<User> _resultList = new List<User>();
            DataTable userTable = new DataTable();

            try
            {
                myConnection = new SqlConnection(connectionStr);
                myConnection.Open();

                SqlCommand cmd = new SqlCommand("getUsers", myConnection);
                SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(cmd);
                _sqlDataAdapter.Fill(userTable);

                foreach (DataRow _dataRow in userTable.Rows)
                {
                    _user = convert_DataRowToUser(_dataRow);
                    _resultList.Add(_user);
                }

                return _resultList;
            }
            finally
            {
                // close connection
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }





        public static Boolean updateUser(string login, string firstName, string lastName  )
        {

            SqlConnection myConnection = null;

            ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            string connectionStr = "Data Source = " + connectionSetting.ConnectionString;

            try
            {
                myConnection = new SqlConnection(connectionStr);
                myConnection.Open();


                SqlCommand cmd = new SqlCommand("updateUser");

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@login", login));
                cmd.Parameters.Add(new SqlParameter("@first_name", firstName));
                cmd.Parameters.Add(new SqlParameter("@last_name", lastName));

                cmd.Connection = myConnection;

                int _row = cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                string res = e.Message;
                return false;
            }
            finally
            {
                // close connection
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }



        private static ConnectionStringSettings getConnectionSettings(string _nameConnectiongString)
        {
            // add references System.Configuration

            ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings[_nameConnectiongString];

            return connectionStringSettings;
        }

    }
}