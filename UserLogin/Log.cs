using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace UserLogin
{
    public class Log
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity), Key()]
        public Int32 LogId { get; private set; }
        public String ActivityLine { get; set; }
        public DateTime Created { get; set; }

        public Log(string activityLine, DateTime created)
        {
            ActivityLine = activityLine;
            Created = created;
        }

        public void PrintData()
        {
            Console.WriteLine("Log ID-> {0} | Data-> {1} | Created-> {2}"
                , LogId,ActivityLine,Created);
        }
    }
}
