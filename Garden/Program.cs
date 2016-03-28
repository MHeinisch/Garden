using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {

            Driver driver = new Driver();

            driver.FillGardenList();

            //Console.WriteLine(driver.CheckForGardenOverlap(driver.garden3, driver.garden2));

            //Console.WriteLine(driver.DetermineGardenPerimeterWithNoOverlap(driver.gardenList));

            Console.WriteLine(driver.DetermineMinimumTotalGardenPerimeter(driver.gardenList));

            /*for (int i = 0; i < driver.gardenSqrFtDivisibleBy.Count(); i++)
            {
                Console.WriteLine(driver.gardenSqrFtDivisibleBy[i]);
            }*/

            Console.WriteLine(driver.DetermineTotalFertilizerNeeded(driver.gardenList));

            Console.ReadLine();

        }
    }
}
