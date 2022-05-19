using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
   public class Student
    {
        public int StudentId { get; set; }
        public string GivenName{ get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public string Faculty { get; set; }
        public string Specialization { get; set; }
        public string EduDegree { get; set; }
        public string Status { get; set; }
        public string FacNum { get; set; }
        public int Kurs { get; set; }
        public int Potok { get; set; }
        public int Group { get; set; }
        public string PfpSrc { get; set; }
        //public byte[] Photo { get; set; }
        public Student() { }

        public Student(int studentId, string givenName, string middleName, string familyName, string faculty, string specialization, string eduDegree, string status, string facNum, int kurs, int potok, int group, string pfpSrc)
        {
            StudentId = studentId;
            GivenName = givenName;
            MiddleName = middleName;
            FamilyName = familyName;
            Faculty = faculty;
            Specialization = specialization;
            EduDegree = eduDegree;
            Status = status;
            FacNum = facNum;
            Kurs = kurs;
            Potok = potok;
            Group = group;
            PfpSrc = pfpSrc;
        }
        public override string ToString() { return this.GivenName+" "+this.MiddleName+" "+this.FamilyName; }
    }
}
