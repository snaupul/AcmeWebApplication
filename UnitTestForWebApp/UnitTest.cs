using AcmeWebApplication.Helper;
using AcmeWebApplication.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace UnitTestForWebApp
{
    [TestClass]
    public class UnitTest
    {
        #region Constants

        private const string FirstName = "TestFirstName";
        private const string LastName = "TestLastName";
        private const string EmailAddress = "test@gmail.com";
        private const int Experience = 2;
        private const string Activity = "Running";
        private const string Comments = "Test Comments";

        #endregion Constants

        private DateTime StartDate = new DateTime(2022, 01, 01);

        [TestMethod]
        public void AddNewuser_ShowAllUsersData()
        {
            var DBConnectionString = new SqlConnection(ConfigurationManager.ConnectionStrings["AcemDB_Testing"].ConnectionString);
            var userData = new UserModel(FirstName, LastName, EmailAddress, StartDate, Experience, Activity, Comments);
            UserHelper.AddNewUser(DBConnectionString, userData);
            var addedUserrInfo = UserHelper.GetAllUsersData(DBConnectionString);
            Assert.AreEqual(addedUserrInfo.Count, 1, "addedUserrInfo.Count");
            Assert.AreEqual(addedUserrInfo[0].FirstName, FirstName, "addedUserrInfo.FirstName");
            Assert.AreEqual(addedUserrInfo[0].LastName, LastName, "addedUserrInfo.LastName");
            Assert.AreEqual(addedUserrInfo[0].EmailAddress, EmailAddress, "addedUserrInfo.EmailAddress");
            Assert.AreEqual(addedUserrInfo[0].StartDate, StartDate, "addedUserrInfo.StartDate");
            Assert.AreEqual(addedUserrInfo[0].Experience, Experience, "addedUserrInfo.Experience");
            Assert.AreEqual(addedUserrInfo[0].Activity, Activity, "addedUserrInfo.Activity");
            Assert.AreEqual(addedUserrInfo[0].Comments, Comments, "addedUserrInfo.Comments");

            UserHelper.RemoveAllUsers(DBConnectionString);
        }
    }
}