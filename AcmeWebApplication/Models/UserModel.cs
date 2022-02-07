using System;
using System.Data;

namespace AcmeWebApplication.Models
{
    public class UserModel
    {
        public UserModel(DataRow dr)
        {
            this.UserID = dr.Field<int>("UserID");
            this.FirstName = dr.Field<string>("FirstName");
            this.LastName = dr.Field<string>("LastName");
            this.EmailAddress = dr.Field<string>("EmailAddress");
            this.StartDate = dr.Field<DateTime?>("StartDate");
            this.Experience = dr.Field<int>("Experience");
            this.Activity = dr.Field<string>("Activity");
            this.Comments = dr.Field<string>("Comments");
            this.SignUpDate = dr.Field<DateTime?>("SingedUpDate");
        }

        public UserModel()
        { }

        public UserModel(string firstName, string lastName, string emailAddress, DateTime startTime, int experience,
                        string activity, string comments)
        {
            this.UserID = 0;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.EmailAddress = emailAddress;
            this.StartDate = startTime;
            this.Experience = experience;
            this.Activity = activity;
            this.Comments = comments;
            this.SignUpDate = DateTime.Now;
        }

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? StartDate { get; set; }
        public int Experience { get; set; }
        public string Activity { get; set; }
        public string Comments { get; set; }
        public DateTime? SignUpDate { get; set; }
    }
}