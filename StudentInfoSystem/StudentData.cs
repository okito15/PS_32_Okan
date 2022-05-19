using System.Collections.Generic;

namespace StudentInfoSystem
{
    class StudentData
    {
        static public List<Student> TestStudents
        {
            get
            {
                testStudents = null;
                if (testStudents == null) {
                    ResetTestStudentsData();
                }
                return testStudents;
            }
            private set { }
        }
        static private List<Student> testStudents;

        static private void ResetTestStudentsData() {
            testStudents = new List<Student>();
            Student test1 = new Student(2,"Okan","Sezgin","Seid","FKST","KSI","Bachelor","Redoven", "121219017",3,9,32,"Okan.jpg");
            Student test2 = new Student(3, "Ivan", "Petrov", "Petrov", "FKST", "KSI", "Bachelor", "Redoven", "121219000", 3, 9, 32, "Ivan.jpg");

            testStudents = new List<Student>
            {
                test1,
                test2
            };
        }
    }
}
