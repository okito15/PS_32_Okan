using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UserLogin
{
   static public class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity) {
            string activityLine = LoginValidation.currentUserUsername + "; "
     + LoginValidation.currentUserRole + "; "
     + activity;
            currentSessionActivities.Add(activityLine);

          StreamWriter woah=  File.AppendText(Program.userActivityFile);
            //if the file does not exist, it is created
            woah.WriteLine(activityLine);
            woah.Close();

            AddLogToDB(activityLine);
        }

        static public void LogAuthError(int errCode, string errDescription)
        {
            string activityLine = "Error code: " + errCode+"| "+errDescription;
            StreamWriter sw = File.AppendText(Program.authErrorsFile);
            //if the file does not exist, it is created
            sw.WriteLine(activityLine);
            sw.Close();

            AddLogToDB(activityLine);
        }

        static public IEnumerable<string> GetActivity(string fileName)
        {
            List<string> activities = new List<string>();
            StreamReader sr = new StreamReader(fileName);
            activities.Add(sr.ReadToEnd());
            sr.Close();
            return activities;
        }

        static public void ClearActivity(string fileName)
        {
            File.WriteAllText(fileName, String.Empty);
            Console.WriteLine("Cleared "+fileName+"!");
        }

        static public IEnumerable<string> GetCurrentSessionActivities(string filter)
        {
            List<string> filteredActivities = (from activity in currentSessionActivities
             where activity.Contains(filter)
             select activity).ToList();
            return filteredActivities;
        }

        static private void AddLogToDB(string activityLine) {
            DateTime localDate = DateTime.Now;
            LogsContext context = new LogsContext();
            Log newLog = new Log(activityLine, localDate);
            context.Logs.Add(newLog);
            context.SaveChanges();
            Console.WriteLine("=== Log added to DB ===");
            newLog.PrintData();
            Console.WriteLine("=== End of Log ===");
        }
    }
}
