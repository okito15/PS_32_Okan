using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
   class Program
    {
        public const string userActivityFile = "test.txt";
        public const string authErrorsFile = "authErrors.txt";
        public static void promptResetApp() {
            Console.WriteLine("Press Enter to continue ...");
            Console.ReadLine();
            Console.Clear();
            openAdminMenu();
        }
       public static void printAdminMenu() {
            Console.WriteLine("Awaiting command:");
            Console.WriteLine("0: Exit");
            Console.WriteLine("1: Modify role of user");
            Console.WriteLine("2: Modify datetime validity of user");
            Console.WriteLine("3: List users");
            Console.WriteLine("4: Output user activity");
            Console.WriteLine("5: Output current user activity");
            Console.WriteLine("6: Output auth errors");
            Console.WriteLine("7: Are Users empty? If yes, add them.");
       }
        public static User extractUserFromPrompt() {
           Console.Write("Enter username of User to be retrieved -> ");
           string inputName = Console.ReadLine();
            User extractedUser = UserData.ExtractUserFromUsername(inputName);
            if (extractedUser == null) {
                Console.WriteLine("No user with such username!");
                promptResetApp();
            }
            return extractedUser;
        }
       public static void customErrorPrint(string errorMsg) {
             Console.WriteLine("!!! " + errorMsg + " !!!");
       }
       public static void openAdminMenu() {
            printAdminMenu();
            
            string choice = Console.ReadLine();
            switch (choice) {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":
                    User inputUser = extractUserFromPrompt();
                    Console.Write("Enter new user role for " + inputUser.Username + " : Press 1 for Admin, 2 for Student, 3 for Inspector, 4 for Professor, 0 for Anon -> ");
                    string newRoleSelection = Console.ReadLine();
                    switch (newRoleSelection) {
                        case "1":
                            UserData.AssignUserRole(inputUser.Username, UserRoles.ADMIN);
                            break;
                        case "2":
                            UserData.AssignUserRole(inputUser.Username, UserRoles.STUDENT);
                            break;
                        case "3":
                            UserData.AssignUserRole(inputUser.Username, UserRoles.INSPECTOR);
                            break;
                        case "4":
                            UserData.AssignUserRole(inputUser.Username, UserRoles.PROFESSOR);
                            break;
                        case "0":
                            UserData.AssignUserRole(inputUser.Username, UserRoles.ANONYMOUS);
                            break;
                    }
                    Console.WriteLine("Done!");
                    openAdminMenu();
                    break;
                case "2":
                    User chosenOne = extractUserFromPrompt();
                    Console.Write("Enter new ending timestamp for " + chosenOne.Username + "'s validity ->");
                    String inputDateTime = Console.ReadLine();
                    try
                    {
                       DateTime newValidUntil = DateTime.Parse(inputDateTime);
                       UserData.SetUserActiveTo(chosenOne.Username, newValidUntil);
                    }
                    catch (Exception err) {
                        Console.WriteLine("Invalid datetime entered ,"+err);
                        promptResetApp();
                    }
                    Console.WriteLine("Done!");
                    openAdminMenu();
                    break;
                case "3":
                    UserData.PrintAllUsers();
                    openAdminMenu();
                    break;

                case "4":
                    StringBuilder sb4 = new StringBuilder();
                    IEnumerable<string> acts =
                            Logger.GetActivity(userActivityFile);

                    foreach (string line in acts)
                    {
                        sb4.Append(line);
                    }
                    Console.WriteLine("START OF CURRENT USER ACTIVITY");
                    Console.WriteLine(sb4.ToString());
                    Console.WriteLine("END OF CURRENT USER ACTIVITY");
                    openAdminMenu();
                    break;
                case "5":
                    Console.WriteLine("Enter a filter");
                    string filter=Console.ReadLine();
                    StringBuilder sb5 = new StringBuilder();
                    IEnumerable<string> currentActs =
                            Logger.GetCurrentSessionActivities(filter);
                    foreach (string line in currentActs)
                    {
                        sb5.Append(line);
                    }
                    Console.WriteLine("START OF CURRENT USER ACTIVITY");
                    Console.WriteLine(sb5.ToString());
                    Console.WriteLine("END OF CURRENT USER ACTIVITY");
                    openAdminMenu();
                    break;
                case "6":
                    StringBuilder sb6 = new StringBuilder();
                    IEnumerable<string> authErrors =
                            Logger.GetActivity(authErrorsFile);
                    foreach (string line in authErrors)
                    {
                        sb6.Append(line);
                    }
                    Console.WriteLine("START OF AUTH ERRORS");
                    Console.WriteLine(sb6.ToString());
                    Console.WriteLine("END OF AUTH ERRORS");
                    openAdminMenu();
                    break;
                case "7":
                    UserContext context = new UserContext();
                    IEnumerable<User> queryUsers = context.Users;
                    int countUsers = queryUsers.Count();
                    if (countUsers == 0)
                    {
                        Console.WriteLine("User count from DB is 0");
                        WriteTestUsersToDB();
                    }
                    else {
                        Console.WriteLine("User count from DB is 0");
                    }
                    openAdminMenu();
                    break;
                default:
                    Console.WriteLine("No such choice available!");
                    promptResetApp();
                    break;
            }
       }

        private static void WriteTestUsersToDB()
        {
            UserContext context = new UserContext();
            foreach (User dude in UserData.TestUsers) {
                context.Users.Add(dude);
            }
            context.SaveChanges();
            Console.WriteLine("Added test users to DB successfully");
        }

        static void Main(string[] args)
        {
            String inputUsername = null;
            String inputPassword = null;
            Console.Write("Enter username -> ");
            inputUsername = Console.ReadLine();
            Console.Write("Enter password -> ");
            inputPassword = Console.ReadLine();
            LoginValidation validation = new LoginValidation(inputUsername, inputPassword, customErrorPrint);
            User wow = new User();
            wow.Username = inputUsername;
            wow.Password = inputPassword;
            validation.ValidateUserInput(wow);

            switch (LoginValidation.currentUserRole) {
                case UserRoles.STUDENT:
                    Console.WriteLine("Hello, Student");
                    break;
                case UserRoles.ADMIN:
                    Console.WriteLine("Welcome, Admin");
                    openAdminMenu();
                    break;
                default:
                    Console.WriteLine("Login failed");
                    Environment.Exit(0);
                    break;
            }

        }
    }
}
