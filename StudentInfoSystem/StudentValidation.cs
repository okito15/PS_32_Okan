using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;


namespace StudentInfoSystem
{
    class StudentValidation
    {
        public Student GetStudentByUser(User input) {
            Boolean emptyFakNum = String.IsNullOrEmpty(input.FacNum);
            if (emptyFakNum) {
                Console.WriteLine("User has no fakulty number!");
                return null;
            }
            foreach (Student Iter in StudentData.TestStudents)
            {
                if (Iter.FacNum == input.FacNum)
                {
                    Console.WriteLine("Found student!");
                    return Iter;
                }
            }
            Console.WriteLine("No Student found with User's fakulty number!");
            return null;
        }
    }
}
