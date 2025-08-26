using Advent_of_Code.Challenges;
using System;

namespace Advent_of_Code
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            
            //Day 1 Challenge part 1 and part 2
           Day1 newDay1Challenge = new Day1();
           Console.WriteLine("Day 1 Challenge");
            newDay1Challenge.PartOneCalculateTheDistanceBetweenTwoGroups();
           newDay1Challenge.PartTwoCalculateTheSimilarityScoreBetweenTwoGroups();
            Console.WriteLine("\n----------------------*End*---------------------------\n");

            //Day 2 Challenge part 1
            Day2 newDay2Challenge = new Day2();
            Console.WriteLine("Day 2 Challenge");
            newDay2Challenge.FindSafeReports();
            newDay2Challenge.TryRemoveUnsafeLevelsAndCalculateNewSafeReport();
            Console.WriteLine("\n----------------------*End*---------------------------\n");

            Day3 newDay3Challenge = new Day3();
            Console.WriteLine("Day 3 Challenge");
            newDay3Challenge.ScanMemory();
            Console.WriteLine("\n----------------------*End*---------------------------\n");

            Day4 newDay4Challenge = new Day4();
            Console.WriteLine("Day 4 Challenge");
            newDay4Challenge.FindWords();
            newDay4Challenge.FindWordXMas();
            Console.WriteLine("\n----------------------*End*---------------------------\n");

            Console.WriteLine("Day 5 Challenge");
            Day5 newDay5Challenge = new Day5();
            newDay5Challenge.GetMiddlePageFromOrderedPages();
            Console.ReadLine();
        }

    }
}
