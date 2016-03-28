using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden
{
    class Driver
    {

        //member variables
        public Garden garden1 = new Garden(2, 2, 10, 20);
        public Garden garden2 = new Garden(100, 10, 5, 5);
        public Garden garden3 = new Garden(5, 5, 10, 10);

        double totalSquareFootage = 0;
        double totalOverlapSquareFootage = 0;

        public List<int> gardenSqrFtDivisibleBy = new List<int>();

        public List<Garden> gardenList = new List<Garden>();





        //constructor
        public Driver()
        {

        }



        //functions
        public bool CheckForGardenOverlap(Garden Garden1, Garden Garden2)
        {
            if ((Garden2.originX > Garden1.originX && Garden2.originX < Garden1.originX + Garden1.width) || (Garden2.originX + Garden2.width > Garden1.originX && Garden2.originX + Garden2.width < Garden1.originX + Garden1.width)
                || (Garden1.originX > Garden2.originX && Garden1.originX < Garden2.originX + Garden2.width) || (Garden1.originX + Garden1.width > Garden2.originX && Garden1.originX + Garden1.width < Garden2.originX + Garden2.width))
            {
                if ((Garden2.originY > Garden1.originY && Garden2.originY < Garden1.originY + Garden1.height) || (Garden2.originY + Garden2.height > Garden1.originY && Garden2.originY + Garden2.height < Garden1.originY + Garden1.height)
                    || (Garden1.originY > Garden2.originY && Garden1.originY < Garden2.originY + Garden2.height) || (Garden1.originY + Garden1.height > Garden2.originY && Garden1.originY + Garden1.height < Garden2.originY + Garden2.height))
                {
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }

        public int DetermineGardenPerimeterWithNoOverlap(List<Garden> GardenList)
        {
            int totalPerimeter = 0;
            for (int gardenListIndex = 0; gardenListIndex < GardenList.Count(); gardenListIndex++)
            {
                totalPerimeter += (GardenList[gardenListIndex].width + GardenList[gardenListIndex].height) * 2;
            }
            return totalPerimeter;
        }

        public int DetermineMinimumTotalGardenPerimeter(List<Garden> GardenList)
        {
            int totalSquareFootage = 0;

            for (int gardenListIndex = 0; gardenListIndex < GardenList.Count(); gardenListIndex++)
            {
                totalSquareFootage += GardenList[gardenListIndex].width * GardenList[gardenListIndex].height;
            }


            int finalWidth;
            int finalHeight;
            for (int totalSquareFootageDivisor = totalSquareFootage; totalSquareFootageDivisor >= 1; totalSquareFootageDivisor--)
            {
                if (totalSquareFootage % totalSquareFootageDivisor == 0)
                {
                    gardenSqrFtDivisibleBy.Add(totalSquareFootageDivisor);
                }
            }
            if (gardenSqrFtDivisibleBy.Count() % 2 == 0)
            {
                finalWidth = gardenSqrFtDivisibleBy[(gardenSqrFtDivisibleBy.Count() / 2) - 1];
                finalHeight = gardenSqrFtDivisibleBy[gardenSqrFtDivisibleBy.Count() / 2];
            }
            else
                finalWidth = finalHeight = gardenSqrFtDivisibleBy.Count() / 2;

            return (finalWidth + finalHeight) * 2;
        }

        public double DetermineTotalFertilizerNeeded(List<Garden> GardenList)
        {
            //determine if there is any overlap between two gardens
            bool isOverlapping;
            int overlapWidth = 0;
            int overlapHeight = 0;

            for (int gardenListIndex = 0; gardenListIndex < GardenList.Count(); gardenListIndex++)
            {
                totalSquareFootage += GardenList[gardenListIndex].width * GardenList[gardenListIndex].height;
            }

            for (int gardenListIndexToCompareWith = 0; gardenListIndexToCompareWith < GardenList.Count() - 1; gardenListIndexToCompareWith++)
            {
                for (int gardenListIndexToCompareAgainst = gardenListIndexToCompareWith + 1; gardenListIndexToCompareAgainst < GardenList.Count(); gardenListIndexToCompareAgainst++)
                {
                    isOverlapping = CheckForGardenOverlap(GardenList[gardenListIndexToCompareWith], GardenList[gardenListIndexToCompareAgainst]);
                    if(isOverlapping == true)
                    {
                        //determine overlap sqaure footage
                        if (GardenList[gardenListIndexToCompareAgainst].originX > GardenList[gardenListIndexToCompareWith].originX && 
                            GardenList[gardenListIndexToCompareAgainst].originX < GardenList[gardenListIndexToCompareWith].originX + GardenList[gardenListIndexToCompareWith].width)
                        {
                            if(GardenList[gardenListIndexToCompareAgainst].originX + GardenList[gardenListIndexToCompareAgainst].width < GardenList[gardenListIndexToCompareWith].originX + GardenList[gardenListIndexToCompareWith].width)
                            {
                                overlapWidth += GardenList[gardenListIndexToCompareAgainst].width;
                            }
                            else
                            {
                                overlapWidth += GardenList[gardenListIndexToCompareWith].width - Math.Abs(GardenList[gardenListIndexToCompareAgainst].originX - GardenList[gardenListIndexToCompareWith].originX);
                            }
                        }
                        else if(GardenList[gardenListIndexToCompareAgainst].originX + GardenList[gardenListIndexToCompareAgainst].width > GardenList[gardenListIndexToCompareWith].originX &&
                                GardenList[gardenListIndexToCompareAgainst].originX + GardenList[gardenListIndexToCompareAgainst].width < GardenList[gardenListIndexToCompareWith].originX + GardenList[gardenListIndexToCompareWith].width)
                        {
                            overlapWidth += GardenList[gardenListIndexToCompareAgainst].width - Math.Abs(GardenList[gardenListIndexToCompareWith].originX - GardenList[gardenListIndexToCompareAgainst].originX);
                        }
                        if (GardenList[gardenListIndexToCompareAgainst].originY > GardenList[gardenListIndexToCompareWith].originY &&
                            GardenList[gardenListIndexToCompareAgainst].originY < GardenList[gardenListIndexToCompareWith].originY + GardenList[gardenListIndexToCompareWith].height)
                        {
                            if(GardenList[gardenListIndexToCompareAgainst].originY + GardenList[gardenListIndexToCompareAgainst].height < GardenList[gardenListIndexToCompareWith].originY + GardenList[gardenListIndexToCompareWith].height)
                            {
                                overlapHeight = GardenList[gardenListIndexToCompareAgainst].height;
                            }
                            else
                            {
                                overlapHeight += GardenList[gardenListIndexToCompareWith].height - Math.Abs(GardenList[gardenListIndexToCompareAgainst].originY - GardenList[gardenListIndexToCompareWith].originY);
                            }
                        }
                        else if(GardenList[gardenListIndexToCompareAgainst].originY + GardenList[gardenListIndexToCompareAgainst].height > GardenList[gardenListIndexToCompareWith].originY &&
                                GardenList[gardenListIndexToCompareAgainst].originY + GardenList[gardenListIndexToCompareAgainst].height < GardenList[gardenListIndexToCompareWith].originY + GardenList[gardenListIndexToCompareWith].height)
                        {
                            overlapHeight += GardenList[gardenListIndexToCompareAgainst].height - Math.Abs(GardenList[gardenListIndexToCompareWith].originY - GardenList[gardenListIndexToCompareAgainst].originY);
                        }
                        //add to running total of overlapSquareFootage
                        totalOverlapSquareFootage += (overlapWidth * overlapHeight);
                        overlapWidth = 0;
                        overlapHeight = 0;
                    }
                }
            }
            Console.WriteLine(totalOverlapSquareFootage);
            Console.WriteLine(totalSquareFootage - totalOverlapSquareFootage);
            return (totalSquareFootage - totalOverlapSquareFootage) / 2;
            //totalFertilizer = (totalSquareFootage - totalOverLapSquareFootage) / 2
        }

        public void FillGardenList()
        {
            gardenList.Add(garden1);
            gardenList.Add(garden2);
            gardenList.Add(garden3);
        }

    }
}
