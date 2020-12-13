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

            while ((sLine = srEntries.ReadLine()) != null)
                ssEntries.Add(Int32.Parse(sLine));

            // Having sorted elements means we can halt
            // the check process short if the sum
            // is greater than our target of 2020.
            ssEntries.Sort();

            // Now find the sum.
            bool bSumFound = false;
            int nSum = 0;
            int nIndex1 = 0;
            int nIndex2 = 0;
            int nIndex3 = 0;
            int nAdd1 = 0;
            int nAdd2 = 0;
            int nAdd3 = 0;
            int acc = 0;
            // Index will be the lhs of any sum (so limit index to be one less than
            // end of entries).
            while (!bSumFound && nIndex1 < ssEntries.Count - 2)
            {
                nIndex2 = nIndex1 + 1;
                while (!bSumFound && nIndex2 < ssEntries.Count - 1)
                {
                    nIndex3 = nIndex2 + 1;
                    while (!bSumFound && nIndex3 < ssEntries.Count)
                    {
                        nAdd1 = ssEntries[nIndex1];
                        nAdd2 = ssEntries[nIndex2];
                        nAdd3 = ssEntries[nIndex3];

                        nSum = nAdd1 + nAdd2 + nAdd3;

                        bSumFound = nSum == nSumTarget;

                        nIndex3++;
                        acc++;
                    }
                    nIndex2++;
                }
                nIndex1++;
            }

            if (nSum == nSumTarget)
                Console.WriteLine
(@"Components of sum target " + nSumTarget + " found: " + nAdd1 + ", " + nAdd2 + ", and " + nAdd3 +
"Their Product is: " + nAdd1 * nAdd2 * nAdd3);
            else
                Console.WriteLine("Components of sum target " + nSumTarget + " not found.");
        }
    }
}
