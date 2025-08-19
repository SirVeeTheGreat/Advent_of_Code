using System.Text.RegularExpressions;

namespace Avent_of_Code_Day_1
{
    internal class Program
    {
        static void Main(string[] args)



        {
            var (locationId_group1,locationId_group2) = GetInputData();

            PartOne(locationId_group1, locationId_group2);
            PartTwo(locationId_group1, locationId_group2);

        }

      

        public static void PartOne(int[]locationId_group1, int[]locationId_group2)
        {
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
            Console.WriteLine("Part One => Distances between the two groups is: {0}", distance.Sum());
        }


        public static void PartTwo(int[] locationId_group1, int[] locationId_group2)
        {
            int[] similarityScore = [];
            foreach (var locationId in locationId_group1)
            {
                var occurence = locationId_group2.Count(x => x == locationId);
                similarityScore = similarityScore.Append(locationId * occurence).ToArray();
            }

            Console.WriteLine("Part Two => The similarity score is: {0}", similarityScore.Sum());
        }


        public static (int[], int[]) GetInputData()
        {
            string? inputTextLine = String.Empty;
            int[] locationId_group1 = [];
            int[] locationId_group2 = [];

            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
            StreamReader sr = new StreamReader(inputFilePath);

            inputTextLine = sr.ReadLine();

            while (inputTextLine != null)
            {
                string[] splitValues = Regex.Split(inputTextLine, @"\s{3}");
                var parts = Array.ConvertAll(splitValues, int.Parse);
                locationId_group1 = locationId_group1.Append(parts[0]).ToArray();
                locationId_group2 = locationId_group2.Append(parts[1]).ToArray();
                inputTextLine = sr.ReadLine();
            }
            return (locationId_group1, locationId_group2);
        }


    }
}
