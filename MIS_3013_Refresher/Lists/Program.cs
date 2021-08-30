using System;
using System.Collections.Generic;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> examGrades = new List<double>();

            bool shouldContinue = true;

            while (shouldContinue)
            {
                Console.WriteLine("Please enter your exam grade >>");
                double grade = Convert.ToDouble(Console.ReadLine());

                examGrades.Add(grade);

                Console.WriteLine("Do you want to enter another grade? yes or no >>");
                string answer = Console.ReadLine();

                if (answer.ToLower() == "no")
                {
                    //break;
                    shouldContinue = false;
                }
            }

            double avg, sum = 0;


            foreach (double grade in examGrades)
            {
                sum += grade;
            }

            avg = sum / examGrades.Count;
            Console.WriteLine($"The average of your exam grades is {avg.ToString("P2")}");
        }
    }
}
