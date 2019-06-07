using System;

namespace Exam
{
    class Program
    {
       
        static int Row,Col;
        static bool isSafe(int[,] area, int x, int y)
        {
            return (x >= 0 && x < Row && y >= 0 && y < Col && area[x, y] == 1);
        }
        static int ReachDestination(int[,] area)
        {
            int distance = -1;
            // checks the available route, i.e if 1 is available in either side
            // passing x,y as 0,0 because the truck is starting at the top left position
            if (FindPath(area, 0, 0, ref distance) == false)
            {
                //Cannot reach destination, if at top,down,right and left 0 exists
                return -1;
            }
            return distance;
        }
        static bool FindPath(int[,] area, int x, int y,ref int distance)
        {
            // Row - 1 and Col -1 is the position where 9 exists 
            if (x == Row - 1 && y == Col - 1)
            {
                // incrementing 
                distance++;
                return true;
            }

            // Check if area[x][y] is valid 
            if (isSafe(area, x, y) == true)
            {
                // mark x, y as part of solution path 
                distance++;

                // moving horizontally right side ( x -axis)
                if (FindPath(area, x + 1, y,ref distance))
                    return true;

                // moving vertically downwards (y-axis)
                if (FindPath(area, x, y + 1,ref distance))
                    return true;

                // if none of the above movememts works that means truck 
                //is blocked or corresponding cells have 0's
                return false;
            }

            return false;
        }
        public static int minimumDistance(int numRows, int numColumns, int[,] area)
        {
            int i=0, j=0;
            bool isNine = false;
            // finding the position of 9 in the array
            for(i=0;i<numRows && !isNine; i++)
            {
                for(j=0;j<numColumns && !isNine; j++)
                {
                    if (area[i, j] == 9)
                    {
                        isNine = true;
                        break;
                    }
                }
                if (isNine)
                    break;
            }
            Row = i + 1;
            Col = j + 1;
            // this is solved by backtracking
            return ReachDestination(area);
           
        }
        static void Main(string[] args)
        {

            int[,] area = new int[,]
                            {{ 1, 1, 1, 1 },
                             { 0, 1, 1, 1 },
                             { 0, 1, 0, 1 },
                             { 1, 1, 9, 1 },
                             { 0, 0, 1, 1 }};
          

            Console.WriteLine(minimumDistance(5, 4, area));
            Console.Read();
        }      
    }
}
