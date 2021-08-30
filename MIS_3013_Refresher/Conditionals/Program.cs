using System;

namespace Conditionals
{
    class Program
    {
        const double COG_COST = 79.99;
        const double GEAR_COST = 250.00;
        const double FULL_MARKUP_PERCENT = 0.15;
        const double DISCOUNT_MARKUP_PERCENT = 0.125;
        const double SALES_TAX = .089;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Non-Procedural Programming Sales Department");
            Console.WriteLine("How many cogs do you want to purchase? >>");
            string answer = Console.ReadLine();

            int cogs, gears;

            if (int.TryParse(answer, out cogs) == false)
            {
                Console.WriteLine("Invalid number for cogs.  Goodbye.");
                Environment.Exit(-5);
            }

            Console.WriteLine("How many gears do you want to purchase? >>");
            answer = Console.ReadLine();

            if (int.TryParse(answer, out gears) == false)
            {
                Console.WriteLine("Invalid number for gears.  Goodbye.");
                Environment.Exit(-5);
            }

            double totalCost, discountAmount, taxAmount;

            
            double markupPercent;

            //if (cogs >= 10)
            //{
            //    markupPercent = DISCOUNT_MARKUP_PERCENT;
            //}
            //else if (gears >= 10)
            //{
            //    markupPercent = DISCOUNT_MARKUP_PERCENT;
            //}
            //else
            //{
            //    if (gears + cogs >= 16)
            //    {
            //        markupPercent = DISCOUNT_MARKUP_PERCENT;
            //    }
            //    else
            //    {
            //        markupPercent = FULL_MARKUP_PERCENT;
            //    }
            //}

            if (cogs >= 10 || gears >= 10 || (gears + cogs) >= 16)
            {
                totalCost = (cogs * COG_COST) * (1 + DISCOUNT_MARKUP_PERCENT) + (gears * GEAR_COST) * (1 + DISCOUNT_MARKUP_PERCENT);
                discountAmount = totalCost * FULL_MARKUP_PERCENT - totalCost * DISCOUNT_MARKUP_PERCENT;
            }
            else
            {
                discountAmount = 0;
                totalCost = (cogs * COG_COST) * (1+FULL_MARKUP_PERCENT) + (gears * GEAR_COST) * (1 + FULL_MARKUP_PERCENT);
            }

            double tax = totalCost * SALES_TAX;
            totalCost += tax;

            Console.WriteLine($"Cogs @ {COG_COST.ToString("C")} x {cogs.ToString("N0")} = {(cogs*COG_COST).ToString("C2")}");
            Console.WriteLine($"Gears @ {GEAR_COST.ToString("C")} x {gears.ToString("N0")} = {(gears * GEAR_COST).ToString("C")}");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Total Cost: {totalCost.ToString("C")}");
            Console.ForegroundColor = ConsoleColor.Gray;
            if (discountAmount > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            Console.WriteLine($"Discount : {discountAmount.ToString("C")}");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Sales Tax : {tax.ToString("C")}");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
