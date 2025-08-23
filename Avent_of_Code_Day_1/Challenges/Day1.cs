using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_of_Code.Challenges
{
    internal class Day1 : Common
    {

        private int[] _locationIdGroup1;
        private int[] _locationIdGroup2;


        public Day1()
        {
            _locationIdGroup1 = [];
            _locationIdGroup2 = [];
            GetInputData("input#day1");
        }

        
        protected sealed override void GetInputData(string fileName)
        {
            string? inputTextLine = String.Empty;
            string inputFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Input" ,$"{fileName}.txt");
            StreamReader sr = new StreamReader(inputFilePath);

            inputTextLine = sr.ReadLine();

            while (inputTextLine != null)
            {
                string[] splitValues = Regex.Split(inputTextLine, @"\s{3}");
                var parts = Array.ConvertAll(splitValues, int.Parse);
                _locationIdGroup1 = _locationIdGroup1.Append(parts[0]).ToArray();
                _locationIdGroup2 = _locationIdGroup2.Append(parts[1]).ToArray();
                inputTextLine = sr.ReadLine();
            }
        }

        
        public void PartOneCalculateTheDistanceBetweenTwoGroups()
        {
            int[] distance = [];
            // Sort by ascending order
            int[] sortedLocationIdGroup1 = _locationIdGroup1.OrderBy(x => x).ToArray();
            int[] sortedLocationIdGroup2 = _locationIdGroup2.OrderBy(x => x).ToArray();


            for (int i = 0; i < sortedLocationIdGroup1.Length; i++)
            {
                int difference = 0;
                if (sortedLocationIdGroup1[i] >= sortedLocationIdGroup2[i])
                    difference = sortedLocationIdGroup1[i] - sortedLocationIdGroup2[i];
                else
                    difference = sortedLocationIdGroup2[i] - sortedLocationIdGroup1[i];
                distance = distance.Append(difference).ToArray();
            }
            Console.WriteLine("Part One => Distances between the two groups is: {0}", distance.Sum());
        }

      
        public void PartTwoCalculateTheSimilarityScoreBetweenTwoGroups()
        {
            int[] similarityScore = [];
            foreach (var locationId in _locationIdGroup1)
            {
                var occurence = _locationIdGroup2.Count(x => x == locationId);
                similarityScore = similarityScore.Append(locationId * occurence).ToArray();
            }

            Console.WriteLine("Part Two => The similarity score is: {0}", similarityScore.Sum());
        }

       
    }
}
