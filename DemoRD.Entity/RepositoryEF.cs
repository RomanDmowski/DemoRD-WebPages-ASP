using DemoRD.DTO;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoRD.Entity
{
    public class RepositoryEF
    {

        public static List<ClaimListItem> GetListClaim(string userName)
        {

            List<ClaimListItem> resultList = new List<ClaimListItem>();

            using (var db = new rd002Entities())
            {


                var query = from c in db.Claims
                            orderby c.date_claim
                            where c.User.login == userName
                            select c;


                foreach (var item in query)
                {
                    resultList.Add(convertClaimEFToClaimListItem_ClaimDetails(item));
                }

            }




            //      ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            //      string connectionStr = "Data Source = " + connectionSetting.ConnectionString;
            //      SqlConnection myConnection = new SqlConnection(connectionStr);
            //      myConnection.Open();

            //      DataTable t = new DataTable();
            ////x      List<ClaimListItem> resultList = new List<ClaimListItem>();

            //      using (SqlDataAdapter a = new SqlDataAdapter(
            //      //"Select TOP 100 claim_number,first_name,last_name,facility_name, date_claim, (select SUM(amount_billed) FROM Claim_services WHERE claim_number=Claims.claim_number) as 'amount',  (select SUM(patient_responsibility)  FROM Claim_services WHERE claim_number=Claims.claim_number) as 'patient_responibility' FROM Claims INNER JOIN Users ON Users.user_id= Claims.user_id Inner JOIN Facilities ON Facilities.facility_id = Claims.facility_id WHERE Claims.user_id='" + user_id + "' ORDER BY Claims.date_claim DESC", myConnection))
            //      "Select TOP 100 claim_number,first_name,last_name,facility_name, date_claim, (select SUM(amount_billed) FROM Claim_services WHERE claim_number=Claims.claim_number) as 'amount',  (select SUM(patient_responsibility)  FROM Claim_services WHERE claim_number=Claims.claim_number) as 'patient_responibility' FROM Claims INNER JOIN Users ON Users.user_id= Claims.user_id Inner JOIN Facilities ON Facilities.facility_id = Claims.facility_id WHERE Users.login='" + userName + "' ORDER BY Claims.date_claim DESC", myConnection))
            //      {
            //          a.Fill(t);
            //      };

            //      foreach (DataRow row in t.Rows)
            //      {
            //          resultList.Add(convertDatarowToClaimListItem_ClaimDetails(row, userName, myConnection));
            //      }

            //      myConnection.Close();


            return resultList;

        }


        public static ClaimListItem GetClaim(long ClaimNumber)
        {

            ClaimListItem _resultClaim = new ClaimListItem();


            using (var db = new rd002Entities())
            {
                var _claim = db.Claims.First(cl => cl.claim_number == ClaimNumber);
                _resultClaim = convertClaimEFToClaimListItem_ListClaims(_claim);
            }

            return _resultClaim;

            ////string connectionStr = "Data Source = hp9887\\sql5422; Initial Catalog = test_entity; Integrated Security = True; MultipleActiveResultSets = True; Application Name = EntityFramework";

            //ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            //string connectionStr = "Data Source = " + connectionSetting.ConnectionString;
            //SqlConnection myConnection = new SqlConnection(connectionStr);
            //myConnection.Open();

            //DataTable t = new DataTable();

            //using (SqlDataAdapter a = new SqlDataAdapter(
            //"Select TOP 100 claim_number,first_name,last_name,facility_name, date_claim FROM Claims INNER JOIN Users ON Users.user_id= Claims.user_id Inner JOIN Facilities ON Facilities.facility_id = Claims.facility_id WHERE Claims.claim_number=" + ClaimNumber + " ORDER BY Claims.date_claim DESC", myConnection))

            //{
            //    a.Fill(t);
            //};
            ////It should be one row only
            //DataRow _dataRow = t.Rows[0];

            //_resultClaim = convertDatarowToClaimListItem_ListClaims(_dataRow, myConnection);

            //myConnection.Close();

            //return _resultClaim;

        }



        public static int IsLoginInDatabaseEF(string loginToTest)
        {
            // if something wrong return -1

            int _count = -1;

            using (var db = new rd002Entities())
            {
                _count = db.Users.Count(us => us.login == loginToTest);
            }

            return _count;



            //SqlConnection myConnection = null;
            ////string connectionStr = "Data Source = hp9887\\sql5422; Initial Catalog = test_entity; Integrated Security = True; MultipleActiveResultSets = True; Application Name = EntityFramework";
            //ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            //string connectionStr = "Data Source = " + connectionSetting.ConnectionString;


            //int _count = new int();

            ////SELECT COUNT(*) AS NumberOfOrders FROM Orders;
            //try
            //{

            //    myConnection = new SqlConnection(connectionStr);

            //    myConnection.Open();
            //    //test r@wp.pl

            //    SqlCommand cmd = new SqlCommand("select COUNT(*) from Users where login = @Login", myConnection);
            //    SqlParameter param = new SqlParameter();
            //    param.ParameterName = "@Login";
            //    param.Value = loginToTest;
            //    cmd.Parameters.Add(param);

            //    object _result = cmd.ExecuteScalar();


            //    if (_result != null)
            //    {
            //        _count = (int)_result;
            //    }
            //    else
            //    {
            //        _count = -1;
            //    }
            //    return _count;
            //}
            //finally
            //{

            //    // close connection
            //    if (myConnection != null)
            //    {
            //        myConnection.Close();
            //    }
        }


        public static void storePassword(string _first_name, string _last_name, string _login, byte[] _hashPass, byte[] _salt01, byte[] _salt02)
        {



            using (var db = new rd002Entities()) 
            {
                try
                {
                    var user = new User { first_name = _first_name, hash = _hashPass, last_name = _last_name, login = _login, salt1 = _salt01, salt2 = _salt02 };
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Sorry, there was an application problem. Technical description:" + ex.Message);
                }

            }


            //SqlConnection myConnection = null;

            //ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            //string connectionStr = "Data Source = " + connectionSetting.ConnectionString;
            ////string connectionStr = "Data Source = hp9887\\sql5422; Initial Catalog = test_entity; Integrated Security = True; MultipleActiveResultSets = True; Application Name = EntityFramework";


            //try
            //{

            //    myConnection = new SqlConnection(connectionStr);

            //    myConnection.Open();

            //    SqlCommand cmd = new SqlCommand("INSERT INTO Users (first_name, last_name, login, salt1, salt2, hash) VALUES(@first_name, @last_name, @login, @salt1, @salt2, @hash)", myConnection);
            //    SqlParameter param = new SqlParameter();



            //    cmd.Parameters.Add(new SqlParameter("@first_name", _first_name));
            //    cmd.Parameters.Add(new SqlParameter("@last_name", _last_name));
            //    cmd.Parameters.Add(new SqlParameter("@login", _login));
            //    cmd.Parameters.Add(new SqlParameter("@salt1", _salt01));
            //    cmd.Parameters.Add(new SqlParameter("@salt2", _salt02));
            //    cmd.Parameters.Add(new SqlParameter("@hash", _hashPass));

            //    int _countRecord = cmd.ExecuteNonQuery();



            //}
            //finally
            //{

            //    // close connection
            //    if (myConnection != null)
            //    {
            //        myConnection.Close();
            //    }
            //}


        }




        public static DemoRD.DTO.User getUser(string login)
        {

            DemoRD.DTO.User _user = new DTO.User();


            using (var db = new rd002Entities())
            {

                try
                {
                    var _userEF = db.Users.Single(us => us.login == login);
                    _user = convertUserEFToUser(_userEF);
                    return _user;
                }
                catch (Exception ex)
                {

                    throw new Exception("Sorry, there was an application problem. Technical description:" + ex.Message);
                }       


            }

            //SqlConnection myConnection = null;

            //ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            //string connectionStr = "Data Source = " + connectionSetting.ConnectionString;


            //User _user = new User();
            ////SqlDataAdapter _sqlDataAdapter = null;
            //DataTable userTable = new DataTable();

            //try
            //{
            //    myConnection = new SqlConnection(connectionStr);
            //    myConnection.Open();

            //    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE login=@login", myConnection);
            //    //SqlParameter param = new SqlParameter();
            //    cmd.Parameters.Add(new SqlParameter("@login", login));
            //    //cmd.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar, 100,login));

            //    SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(cmd);
            //    // _sqlDataAdapter.InsertCommand = cmd;
            //    _sqlDataAdapter.Fill(userTable);

            //    DataRow _dataRow = userTable.Rows[0];

            //    _user = convert_DataRowToUser(_dataRow);

            //    return _user;
            //}
            //finally
            //{
            //    // close connection
            //    if (myConnection != null)
            //    {
            //        myConnection.Close();
            //    }
            //}
        }




        public static List<DemoRD.DTO.User> getListUser()
        {

            DemoRD.DTO.User _user = new DTO.User();
            List<DemoRD.DTO.User> _resultList = new List<DTO.User>();


            using (var db = new rd002Entities())
            {
                try
                {
                    var query = from u in db.Users
                                select u;
                    foreach (var item in query)
                    {
                        _user = convertUserEFToUser(item);
                        _resultList.Add(_user);
                    }
                    return _resultList;
                }
                catch (Exception ex)
                {
                    throw new Exception("Sorry, there was an application problem. Technical description:" + ex.Message);
                }
            }



            //SqlConnection myConnection = null;

            //ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            //string connectionStr = "Data Source = " + connectionSetting.ConnectionString;


            //User _user = new User();
            //List<User> _resultList = new List<User>();
            //DataTable userTable = new DataTable();

            //try
            //{
            //    myConnection = new SqlConnection(connectionStr);
            //    myConnection.Open();

            //    SqlCommand cmd = new SqlCommand("getUsers", myConnection);
            //    SqlDataAdapter _sqlDataAdapter = new SqlDataAdapter(cmd);
            //    _sqlDataAdapter.Fill(userTable);

            //    foreach (DataRow _dataRow in userTable.Rows)
            //    {
            //        _user = convert_DataRowToUser(_dataRow);
            //        _resultList.Add(_user);
            //    }

            //    return _resultList;
            //}
            //finally
            //{
            //    // close connection
            //    if (myConnection != null)
            //    {
            //        myConnection.Close();
            //    }
            //}




        }






        public static Boolean updateUser(string login, string firstName, string lastName)
        {


            using (var db = new rd002Entities())
            {
                try
                {
                    var _user = db.Users.Single(us => us.login == login);
                    _user.first_name = firstName;
                    _user.last_name = lastName;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                    throw new Exception("Sorry, there was an application problem. Technical description:" + ex.Message);      
                }
               
                

            }

            //SqlConnection myConnection = null;

            //ConnectionStringSettings connectionSetting = getConnectionSettings("sql01");
            //string connectionStr = "Data Source = " + connectionSetting.ConnectionString;

            //try
            //{
            //    myConnection = new SqlConnection(connectionStr);
            //    myConnection.Open();


            //    SqlCommand cmd = new SqlCommand("updateUser");

            //    cmd.CommandType = CommandType.StoredProcedure;

            //    cmd.Parameters.Add(new SqlParameter("@login", login));
            //    cmd.Parameters.Add(new SqlParameter("@first_name", firstName));
            //    cmd.Parameters.Add(new SqlParameter("@last_name", lastName));

            //    cmd.Connection = myConnection;

            //    int _row = cmd.ExecuteNonQuery();

            //    return true;
            //}
            //catch (Exception e)
            //{
            //    string res = e.Message;
            //    return false;
            //}
            //finally
            //{
            //    // close connection
            //    if (myConnection != null)
            //    {
            //        myConnection.Close();
            //    }
            //}
        }













        private static DTO.User convertUserEFToUser(User _userEF)
        {
            DemoRD.DTO.User _user = new DemoRD.DTO.User();

            _user.FirstName = _userEF.first_name;
            _user.Hash = _userEF.hash;
            _user.LastName = _userEF.last_name;
            _user.Login = _userEF.login;
            _user.Salt1 = _userEF.salt1;
            _user.Salt2 = _userEF.salt2;
            _user.User_ID = _userEF.user_id;

            return _user;
        }

        private static ClaimListItem convertClaimEFToClaimListItem_ClaimDetails(DemoRD.Entity.Claim claimItem)
        {

            try
            {

                ClaimListItem itemClaim = new ClaimListItem();

                itemClaim.ClaimNumber = claimItem.claim_number;
                itemClaim.PatientFirstName = claimItem.User.first_name;
                itemClaim.PatientLastName = claimItem.User.last_name;
                itemClaim.FacilityName = claimItem.Facility.facility_name;
                itemClaim.DateClaim = (DateTime)claimItem.date_claim;

                itemClaim.AmountBilledSum = claimItem.Claim_services.Sum(cs => cs.amount_billed);

                itemClaim.PatientResponsibilitySum = claimItem.Claim_services.Sum(cs => cs.patient_responsibility);

                return itemClaim;
            }
            catch (Exception ex)
            {

                throw new Exception("Sorry, there was an application problem. Technical description:" + ex.Message);
            }
        }

        private static ClaimListItem convertClaimEFToClaimListItem_ListClaims(DemoRD.Entity.Claim claimItem)
        {
            ClaimListItem itemClaim = new ClaimListItem();

            //select TOP 100 claim_number,first_name,last_name,facility_name, date_claim FROM Claims

            itemClaim.ClaimNumber = claimItem.claim_number;
            itemClaim.PatientFirstName = claimItem.User.first_name;
            itemClaim.PatientLastName = claimItem.User.last_name;
            itemClaim.FacilityName = claimItem.Facility.facility_name;
            itemClaim.DateClaim = (DateTime)claimItem.date_claim;

            itemClaim.StatusesClaimList = getStatusClaimListEF(claimItem.Claim_status);
            itemClaim.ServicesClaimList = getServicesClaimListEF(claimItem.Claim_services);

            return itemClaim;
        }

        private static List<ServiceClaim> getServicesClaimListEF(ICollection<Claim_services> claim_servicesEF)
        {
            List<ServiceClaim> _resultList = new List<ServiceClaim>();
            
            foreach (var item in claim_servicesEF)
            {
                ServiceClaim _serviceClaim = new ServiceClaim();

                _serviceClaim.AmountBilled = item.amount_billed;
                if (_serviceClaim.AmountBilled == -1) _serviceClaim.AmountBilled = 0;

                _serviceClaim.ClaimNumber = item.claim_number;
                _serviceClaim.DateVisited = (DateTime)item.date_visited;
                _serviceClaim.DetailsText = item.service_details_text;

                _serviceClaim.PatientResponsibility = item.patient_responsibility;
                if (_serviceClaim.PatientResponsibility == -1) _serviceClaim.PatientResponsibility = 0;

                _serviceClaim.PlanDiscount = item.plan_discount;
                if (_serviceClaim.PlanDiscount == -1) _serviceClaim.PlanDiscount = 0;

                _serviceClaim.PlanPaid = item.plan_paid;
                if (_serviceClaim.PlanPaid == -1) _serviceClaim.PlanPaid = 0;

                _resultList.Add(_serviceClaim);
            }

            return _resultList;
        }

        private static List<StatusClaim> getStatusClaimListEF(ICollection<Claim_status> claim_status)
        {
         
            List<StatusClaim> _resultList = new List<StatusClaim>();

            foreach (var item in claim_status)
            {
                StatusClaim _statusClaim = new StatusClaim();
                _statusClaim.ClaimNumber = item.claim_number;
                _statusClaim.DateStatus = (DateTime)item.status_date;
                _statusClaim.Status = item.status;

                _resultList.Add(_statusClaim);
            }

            return _resultList;

        }

        //private static List<StatusClaim> getStatusClaimList(DemoRD.Entity.Claim_status statusClaimEF)
        //{

        //    DataTable statusTable = new DataTable();
        //    List<StatusClaim> resultList = new List<StatusClaim>();
        //    using (SqlDataAdapter a2 = new SqlDataAdapter(
        //    "SELECT * FROM Claim_status WHERE claim_number='" + claimNumber + "'", sqlConn2))
        //    {
        //        a2.Fill(statusTable);
        //    };

        //    foreach (DataRow row in statusTable.Rows)
        //    {
        //        //row.Field<int>(0)
        //        StatusClaim itemStatus = new StatusClaim();
        //        itemStatus.ClaimNumber = row.Field<long>("claim_number");
        //        itemStatus.DateStatus = row.Field<DateTime>("status_date");
        //        itemStatus.Status = row.Field<String>("status");

        //        resultList.Add(itemStatus);
        //    }

        //    return resultList;
        //}


        //private static List<ServiceClaim> getServicesClaimList(long claim_number, SqlConnection sqlConn2)
        //{

        //    DataTable servicesTable = new DataTable();
        //    List<ServiceClaim> resultList = new List<ServiceClaim>();

        //    string result = "";


        //    using (SqlDataAdapter a2 = new SqlDataAdapter(
        //    "SELECT * FROM Claim_services WHERE claim_number=" + claim_number, sqlConn2))
        //    {
        //        a2.Fill(servicesTable);
        //    };

        //    foreach (DataRow row in servicesTable.Rows)
        //    {

        //        //row.Field<int>(0)
        //        ServiceClaim itemService = new ServiceClaim();

        //        itemService.AmountBilled = row.Field<decimal>("amount_billed");
        //        if (itemService.AmountBilled == -1) itemService.AmountBilled = 0;

        //        itemService.ClaimNumber = row.Field<long>("claim_number");
        //        itemService.DateVisited = row.Field<DateTime>("date_visited");

        //        itemService.PlanDiscount = row.Field<decimal>("plan_discount");
        //        if (itemService.PlanDiscount == -1) itemService.PlanDiscount = 0;

        //        itemService.DetailsText = row.Field<string>("service_details_text");

        //        itemService.PatientResponsibility = row.Field<decimal>("patient_responsibility");
        //        if (itemService.PatientResponsibility == -1) itemService.PatientResponsibility = 0;

        //        itemService.PlanPaid = row.Field<decimal>("plan_paid");
        //        if (itemService.PlanPaid == -1) itemService.PlanPaid = 0;



        //        resultList.Add(itemService);
        //        //
        //        result += itemService.DateVisited.ToShortDateString();

        //    }

        //    return resultList;
        //}


    }
}
