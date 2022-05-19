using System;

namespace UserLogin
{
   public class LoginValidation
    {
        static public UserRoles currentUserRole { get; private set; }
        static public String currentUserUsername { get; private set; }
        public delegate void ActionOnError(string errorMsg);
        private String Username;
        private String Password;
        private ActionOnError ErrorAction;
        private String ErrorMsg;

        public LoginValidation(String name, String pass, ActionOnError errAction)
        {
            Username = name;
            Password = pass;
            ErrorAction = errAction;
        }
        public Boolean ValidateUserInput(User guy) {

            Boolean emptyUsername = String.IsNullOrEmpty(Username);
            Boolean emptyPassword = String.IsNullOrEmpty(Password);

            if (emptyUsername) {
                ErrorMsg = "Empty username";
                ErrorAction(ErrorMsg);
                Logger.LogAuthError(1, ErrorMsg);
                return false;
            }
            if (emptyPassword) {
                ErrorMsg = "Empty password"; ErrorAction(ErrorMsg);
                Logger.LogAuthError(1, ErrorMsg);
                return false;
            }

            Boolean usernameTooShort = Username.Length < 5;
            Boolean passwordTooShort = Password.Length < 5;

            if (usernameTooShort) {
                ErrorMsg = "Username is less than 5 symbols!"; ErrorAction(ErrorMsg);
                Logger.LogAuthError(2, ErrorMsg);
                return false;
            }
            if (passwordTooShort) {
                ErrorMsg = "Password is less than 5 symbols!"; ErrorAction(ErrorMsg);
                Logger.LogAuthError(2, ErrorMsg);
                return false;
            }

           guy = UserData.IsUserPassCorrect(Username, Password);
            if (guy == null) {
                ErrorMsg = "No user found with these credentials!"; ErrorAction(ErrorMsg);
                Logger.LogAuthError(3, ErrorMsg);
                return false; }
            currentUserUsername = guy.Username;
            currentUserRole = (UserRoles)guy.Role;
            Logger.LogActivity("Successful Login");
            return true;
        }
    }
}
