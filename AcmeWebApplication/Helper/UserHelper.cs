using AcmeWebApplication.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AcmeWebApplication.Helper
{
    public static class UserHelper
    {
        public static List<UserModel> GetAllUsersData(SqlConnection DBConnectionString)
        {
            DBConnectionString.Open();
            SqlCommand cmd = new SqlCommand("GetUsersData", DBConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            var userList = new List<UserModel>();
            foreach (DataRow dr in dataTable.Rows)
            {
                userList.Add(new UserModel(dr));
            }

            DBConnectionString.Close();

            return userList;
        }

        public static void AddNewUser(SqlConnection DBConnectionString, UserModel data)
        {
            DBConnectionString.Open();
            SqlCommand cmd = new SqlCommand("AddUserInfo", DBConnectionString);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@FirstName", data.FirstName);
            cmd.Parameters.Add("@LastName", data.LastName);
            cmd.Parameters.Add("@EmailAddress", data.EmailAddress);
            cmd.Parameters.Add("@StartDate", data.StartDate);
            cmd.Parameters.Add("@Experience", data.Experience);
            cmd.Parameters.Add("@Activity", data.Activity);
            cmd.Parameters.Add("@Comments", data.Comments);

            cmd.ExecuteNonQuery();
            DBConnectionString.Close();
        }

        public static void RemoveAllUsers(SqlConnection DBConnectionString)
        {
            DBConnectionString.Open();
            var sql = @"DELETE FROM Users";
            SqlCommand cmd = new SqlCommand(sql, DBConnectionString);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            DBConnectionString.Close();
        }
    }
}