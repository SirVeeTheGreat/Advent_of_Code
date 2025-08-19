using System.Text.RegularExpressions;

namespace Avent_of_Code_Day_1
{
    internal class Program
    {
        static void Main(string[] args)



        {
            string? inputTextLine = String.Empty;
            int[] locationId_group1 = [];
            int[] locationId_group2 = [];

           
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
            StreamReader sr = new StreamReader(inputFilePath);

            inputTextLine = sr.ReadLine();

            while (inputTextLine != null)
            {
                var parts = SplitBySpaceCharacter(inputTextLine);
                locationId_group1 = locationId_group1.Append(parts[0]).ToArray();
                locationId_group2 = locationId_group2.Append(parts[1]).ToArray();
                inputTextLine = sr.ReadLine();
            }

           
            int[] distance = [];
            // Sort by ascending order
            int[] sortedLocationId_group1 = locationId_group1.OrderBy(x => x).ToArray();
            int[] sortedLocationId_group2 = locationId_group2.OrderBy(x => x).ToArray();


            for (int i = 0; i < sortedLocationId_group1.Length; i++)
            {
                int difference = 0;
                if (sortedLocationId_group1[i] >= sortedLocationId_group2[i])
                    difference = sortedLocationId_group1[i] - sortedLocationId_group2[i];
                else
                    difference = sortedLocationId_group2[i] - sortedLocationId_group1[i];
                distance = distance.Append(difference).ToArray();
            }

        
            Console.WriteLine("Distances between the two groups is: {0}", distance.Sum());


        }

        public static int[] SplitBySpaceCharacter(string input)
        {
            string[] parts = Regex.Split(input, @"\s{3}");
            return Array.ConvertAll(parts, int.Parse);
        }
    }
}
