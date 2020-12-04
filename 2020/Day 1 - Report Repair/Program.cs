using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day_1___Report_Repair
{
    class TheGoods
    {
        private static List<int> lEntries;
        private static int nSumTarget;
        private static int nDepthTarget;
        static void Main(string[] args)
        {
            // We don't handle exceptions here, yeah!
            nSumTarget = Int32.Parse(args[0]);
            nDepthTarget = Int32.Parse(args[1]);
            StreamReader srEntries = new StreamReader(args[2]);
            lEntries = new List<int>();
            string sLine;

            while ((sLine = srEntries.ReadLine()) != null)
                lEntries.Add(Int32.Parse(sLine));

            // Having sorted elements means we can halt
            // the check process short if the sum
            // is greater than our target of 2020 (or any other target).
            lEntries.Sort();

            // Now find the sum.
            FindTargetSum();

        }

        private static int FindTargetSum()
        {
            List<int> aPotentialAdds = new List<int>();
            if (EntrySum(0, 0, nDepthTarget, nSumTarget,  aPotentialAdds, 0))
            {
                Console.Write
($@"Components of sum target {nSumTarget} found: {aPotentialAdds} 
Their Product is: { aPotentialAdds.Aggregate(1, (lhs, rhs)=> lhs * rhs) }");
            }
            else
                Console.WriteLine("Components of sum target " + nSumTarget + " not found.");
            return 0;
        }

        private static bool EntrySum(int nIndexStart, int nDepth, int nDepthTarget, int nSumTarget,  List<int> aPotentialAdds, int nSum)
        {
            int nIndexNext = nIndexStart + 1;
            int nDepthNext = nDepth + 1;

            nDepth--;

            int nEntry = lEntries[nIndexStart];

            aPotentialAdds.Add(nEntry);
            nSum += nEntry;
            // Find sum if at depth target
            if (nDepth == nDepthTarget)
            {
#if DEBUG
                Console.WriteLine($"INDEX: {nIndexStart} DEPTH: {nDepth} SUM: {nSum} ELEMENTS: {String.Join(",", aPotentialAdds)}");
#endif
                if (nSum == nSumTarget)
                    return true;
            }
            else
            {
                while (nIndexNext < lEntries.Count)
                {

                    if (nSum <= nSumTarget &&
                        EntrySum(nIndexNext, nDepthNext, nDepthTarget, nSumTarget,  aPotentialAdds, nSum))
                        return true;
                    else
                        nIndexNext++;
                    int x = 1;
                }
            }

            nSum -= nEntry;
            aPotentialAdds.RemoveAt(nDepth + 1);
            return false;
                
        }
    }
}
