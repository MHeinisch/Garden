using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garden
{
    class Garden
    {

        //member variables
        List<Garden> gardenList = new List<Garden>();
        public List<int> gardenSqrFtDivisibleBy = new List<int>();

        public int originX;
        public int originY;
        public int width;
        public int height;

        int squareFootage;

        public int totalOverlapSquareFootage = 0;



        //constructor
        public Garden(int X, int Y, int Width, int Height)
        {
            originX = X;
            originY = Y;
            width = Width;
            height = Height;
        }



        //functions
        public bool CheckForGardenOverlap(Garden Garden1, Garden Garden2)
        {
            if ((Garden2.originX > Garden1.originX && Garden2.originX < Garden1.originX + Garden1.width) || (Garden2.originX + Garden2.width > Garden1.originX && Garden2.originX + Garden2.width < Garden1.originX + Garden1.width))
            {
                if ((Garden2.originY > Garden1.originY && Garden2.originY < Garden1.originY + Garden1.height) || (Garden2.originY + Garden2.height > Garden1.originY && Garden2.originY + Garden2.height < Garden1.originY + Garden1.height))
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
            int finalWidth;
            int finalHeight;
            for (int gardenListIndex = 0; gardenListIndex < GardenList.Count(); gardenListIndex++)
            {
                totalSquareFootage += GardenList[gardenListIndex].width * GardenList[gardenListIndex].height;
            }
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

        public void DetermineTotalFertilizerNeeded(List<Garden> GardenList)
        {
            //determine if there is any overlap between two gardens
            bool isOverlapping;
            int overlapWidth = 0;
            int overlapHeight = 0;
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
                                overlapWidth += GardenList[gardenListIndexToCompareWith].width - GardenList[gardenListIndexToCompareAgainst].originX;
                            }
                        }
                        else if(GardenList[gardenListIndexToCompareAgainst].originX + GardenList[gardenListIndexToCompareAgainst].width > GardenList[gardenListIndexToCompareWith].originX &&
                                GardenList[gardenListIndexToCompareAgainst].originX + GardenList[gardenListIndexToCompareAgainst].width < GardenList[gardenListIndexToCompareWith].originX + GardenList[gardenListIndexToCompareWith].width)
                        {
                            overlapWidth += GardenList[gardenListIndexToCompareAgainst].width - GardenList[gardenListIndexToCompareWith].originX;
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
                                overlapHeight += GardenList[gardenListIndexToCompareWith].height - GardenList[gardenListIndexToCompareAgainst].originY;
                            }
                        }
                        else if(GardenList[gardenListIndexToCompareAgainst].originY + GardenList[gardenListIndexToCompareAgainst].height > GardenList[gardenListIndexToCompareWith].originY &&
                                GardenList[gardenListIndexToCompareAgainst].originY + GardenList[gardenListIndexToCompareAgainst].height < GardenList[gardenListIndexToCompareWith].originY + GardenList[gardenListIndexToCompareWith].height)
                        {
                            overlapHeight += GardenList[gardenListIndexToCompareAgainst].height - GardenList[gardenListIndexToCompareWith].originY;
                        }
                        //add to running total of overlapSquareFootage
                        totalOverlapSquareFootage += (overlapWidth * overlapHeight);
                        overlapWidth = 0;
                        overlapHeight = 0;
                    }
                }
            }
            //totalFertilizer = (totalSquareFootage - totalOverLapSquareFootage) / 2
        }

    }
}
