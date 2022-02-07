using AcmeWebApplication.Helper;
using AcmeWebApplication.Models;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AcmeWebApplication.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllUsersData()
        {
            var DBConnectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["AcemDB"].ConnectionString);
            var userList = UserHelper.GetAllUsersData(DBConnectionString);

            return Request.CreateResponse(HttpStatusCode.OK, userList);
        }

        [HttpPost]
        public HttpResponseMessage SignUpUser(UserModel data)
        {
            try
            {
                var DBConnectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["AcemDB"].ConnectionString);
                UserHelper.AddNewUser(DBConnectionString, data);

                return Request.CreateResponse(HttpStatusCode.OK, "New User added successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message.ToString());
            }
        }
    }
}