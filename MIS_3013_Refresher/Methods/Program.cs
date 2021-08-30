using System;

namespace Methods
{
    class Program
    {

        static void Main(string[] args)
        {
            double value1ForY = LineValueForY(.75, 7, 0);
            Console.WriteLine($"y = ({.75}){7} + {0} ==> {value1ForY}");

            int f = Factorial(5);
            Console.WriteLine($"5! = {f.ToString("N0")}");

            Console.WriteLine("Please input the number you want the factorial of >>");
            Console.WriteLine($"The factorial is {Factorial(Convert.ToInt32(Console.ReadLine()))}");
        }

        /// <summary>
        /// Calculates the y value of a line
        /// </summary>
        /// <param name="m">The slope of the line</param>
        /// <param name="x">The x-value of the line</param>
        /// <param name="b">The y-intercept of the line</param>
        /// <returns>The y value of the line</returns>
        static double LineValueForY(double m, double x, double b)
        {
            double y;

            y = m * x + b;

            return y;
        }

        /// <summary>
        /// Calculates the factorial for a given number
        /// </summary>
        /// <param name="number">The number to calculate the factorial of</param>
        /// <returns>The result of the factorial</returns>
        static int Factorial(int number)
        {
            int factorial = 1;
           
            for (int i = number; i > 0; i--)
            {
                factorial = factorial * i;
            }


            return factorial;
        }

    }
}
