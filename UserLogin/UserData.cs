using System;
using System.Collections.Generic;
using System.Linq;

namespace UserLogin
{
   public static class UserData
    {
        static public List<User> TestUsers
        {
            get
            {
                if (testUsers == null) { 
                 ResetTestUserData();
                }
                return testUsers;
            }
            set { }
        }
        static private List<User> testUsers;

        static private void ResetTestUserData() {
            User admin = new User
            {
                UserId = 1,
                Username = "okito15",
                Password = "parola123",
                FacNum = "121219017",
                Role = UserRoles.ADMIN,
                Created = DateTime.Now,
                ValidUntil = DateTime.MaxValue
            };

            User student = new User
            {
                UserId = 2,
                Username = "Ivan",
                Password = "IvanPass",
                FacNum = "121219000",
                Role = UserRoles.STUDENT,
                Created = DateTime.Now,
                ValidUntil = DateTime.MaxValue
            };

            testUsers = new List<User>
            {
                admin,
                student
            };


            student.UserId = 3;
            student.Username = "Darth";
            student.Password = "Vader";
            student.FacNum = "121219999";
            student.Role = UserRoles.STUDENT;
            student.Created = DateTime.Now;
            student.ValidUntil = DateTime.MaxValue;

            testUsers.Add(student);
			
			student.UserId = 4;
            student.Username = "Petko";
            student.Password = "password";
            student.FacNum = "121219100";
            student.Role = UserRoles.STUDENT;
            student.Created = DateTime.Now;
            student.ValidUntil = DateTime.MaxValue;

            testUsers.Add(student);
			
        }

        public static User ExtractUserFromUsername(String inputUsername) {
            UserContext context = new UserContext();
            User result = (from user in context.Users where user.Username == inputUsername select user).FirstOrDefault();
            return result;
        }

        public static User IsUserPassCorrect(String name, String pass) {
            UserContext context = new UserContext();
            User result = (from user in context.Users where user.Username == name && user.Password == pass select user).FirstOrDefault();
            return result;
        }

        public static void SetUserActiveTo(String inputUsername, DateTime inputActiveUntil){
            UserContext context = new UserContext();
            User usr = (from user in context.Users where user.Username == inputUsername select user).FirstOrDefault();
            usr.ValidUntil = inputActiveUntil;
            Logger.LogActivity("Modified active until timestamp for " + inputUsername);
            context.SaveChanges();
        }

        public static void AssignUserRole(string inputUsername, UserRoles newRole) {
            UserContext context = new UserContext();
            User usr =
                (from u in context.Users
                where u.Username == inputUsername
                select u).First();
                usr.Role = newRole;
                Logger.LogActivity("Modified role of " + inputUsername);
            context.SaveChanges();
        }
        public static void PrintAllUsers()
        {
            UserContext userContext = new UserContext();
            foreach (User user in userContext.Users)
            {
                Console.WriteLine(user.Username);
            }
        }
    }
}
