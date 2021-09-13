using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_ClassesExample
{
    public class Student
    {
        public int SoonerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsOnProbation { get; set; }
        public double GPA { get; set; }

        private double BursarBalance;

        //public List<string> something { get; set; }

        //public UniversityCourse course { get; set; }

        /// <summary>
        /// Default/empty constructor
        /// </summary>
        public Student()
        {
            SoonerID = 0;
            FirstName = string.Empty;
            LastName = string.Empty; //""
            IsOnProbation = false;
            GPA = 0;
            BursarBalance = 0;
            //something = new List<string>();
            //course = new UniversityCourse();
        }

        public Student(int id, string fName, string lName, double BursarBalance)
        {
            SoonerID = id;
            FirstName = fName;
            LastName = lName;
            IsOnProbation = false;
            GPA = 0;
            this.BursarBalance = BursarBalance;
        }
        public Student(int id, string fName, string lName, double BursarBalance, double gpa, bool isProbation)
        {
            SoonerID = id;
            FirstName = fName;
            LastName = lName;
            IsOnProbation = isProbation;
            GPA = gpa;
            this.BursarBalance = BursarBalance;
        }

        public Student(string fName, string lName)
        {
            SoonerID = 0;
            FirstName = fName;
            LastName = lName;
            IsOnProbation = false;
            GPA = 0;
            BursarBalance = 0;
        }

        /// <summary>
        /// Make a payment towards the Bursar Balance
        /// </summary>
        /// <param name="amount">A positive amount to deduct from the bursar balance</param>
        public void MakePayment(double amount)
        {
            if (amount <0)
            {
                Console.WriteLine("Amount must be negative");
                //throw new Exception("Amount must be negative");
            }

            BursarBalance -= amount;
        }

        public double CheckBalance()
        {
            return BursarBalance;
        }

        public override string ToString()
        {
            return $"{LastName}, {FirstName} ({SoonerID.ToString("N0")})";
        }

    }

    //public class UniversityCourse
    //{
    //}
}
