using System;
using System.IO;
using System.Collections.Generic;

namespace Day_1___Report_Repair
{
    class TheGoods
    {
        static void Main(string[] args)
        {
            // We don't handle exceptions here, yeah!
            int nSumTarget = Int32.Parse(args[0]);
            StreamReader srEntries = new StreamReader(args[1]);
            List<int> ssEntries = new List<int>();
            string sLine;

            while((sLine = srEntries.ReadLine()) != null)
                ssEntries.Add(Int32.Parse(sLine));

            // Having sorted elements means we can halt
            // the check process short if the sum
            // is greater than our target of 2020.
            ssEntries.Sort();

            // Now find the sum.
            bool bSumFound = false;
            int nSum = 0;
            int nIndex = 0;
            int nLhs = 0;
            int nRhs = 0;
            // Index will be the lhs of any sum (so limit index to be one less than
            // end of entries).
            while(!bSumFound && nSum > 2020 && nIndex < ssEntries.Count - 1)
            {
                nLhs = ssEntries[nIndex];
                nRhs = ssEntries[nIndex + 1];

                nSum = nLhs + nRhs;
            }

            if (nSum == 2020)
                Console.WriteLine
(@"Components of sum target " + nSumTarget + " found: " + nLhs + " and " + nRhs +
"Their Product is: " + nLhs * nRhs);
            else
                Console.WriteLine("Components of sum target " + nSumTarget + " not found.");
        }
    }
}
