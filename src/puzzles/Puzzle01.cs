using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AOC2024
{
    internal class  Puzzle01 : Puzzle
    {
        public override void Solve()
        {
            // setup

            var input = File.OpenText("../../../input/day01/input.txt");
            List<int> locationsA = new List<int>();
            List<int> locationsB = new List<int>();

            while (!input.EndOfStream)
            {
                string[] lineLocations = input.ReadLine().Split(' ');
                locationsA.Add(Convert.ToInt32(lineLocations[0]));   
                locationsB.Add(Convert.ToInt32(lineLocations[3]));
            }

            input.Close();

            locationsA.Sort();
            locationsB.Sort();


            // part 1

            {
                int totalDistance = 0;

                for (int i = 0; i < locationsA.Count; i++)
                {
                    totalDistance += Math.Max(locationsA[i], locationsB[i]) - Math.Min(locationsA[i], locationsB[i]);
                }

                Console.WriteLine($"day one part 1: {totalDistance}");
            }

            // part 2

            {
                int similarityScore = 0;

                int iterationB = 0;
                int currentLocation = -1;
                int currentACount = 0;
                int currentBCount = 0;

                for (int iterationA = 0; iterationA < locationsA.Count; iterationA++)
                {

                    // count current amount in A
                    if (locationsA[iterationA] == currentLocation)
                    {

                        currentACount++;
                        continue;

                    }
                    // count current amount in B
                    while (iterationB < locationsB.Count())
                    {
                        if (locationsB[iterationB] > currentLocation)
                            break;

                        if (locationsB[iterationB] == currentLocation)
                            currentBCount++;

                        iterationB++;
                    }

                    // calculate score
                    similarityScore += currentLocation * currentBCount * currentACount;

                    // continue to next number
                    currentLocation = locationsA[iterationA];
                    currentACount = 1;
                    currentBCount = 0;
                }

                Console.WriteLine($"day one part 2: {similarityScore}");
            }
        }
    }
}
