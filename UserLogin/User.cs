using System;

namespace UserLogin
{
   public class User
    {
        public Int32 UserId { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String FacNum { get; set; }
        public UserRoles Role { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? ValidUntil { get; set; }

        public void PrintData() {
            Console.WriteLine("Username-> {0} Password-> {1} Faculty Number-> {2} Role-> {3}"
                , Username, Password, FacNum, Role);
        }
    }
}
