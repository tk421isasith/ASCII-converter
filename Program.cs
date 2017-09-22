using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k_periodic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a string to be checked for k-periodicity. No characters other than the English alphabet please.");
            string input = Console.ReadLine();
            for (int i = 0; i < input.Length - 1; i++)  //Go down the length of the input string. i is the index.
            {
                if (input[i] == input[i + 1])   //Look for two consecutive characters to be the same.
                {
                    if (input.Length % (i + 1) == 0)    //Check that the length of the substring up to the index divides the total length of the string. If not the substring is not a candidate for a k-periodic substring.
                    {
                        int k = i + 1;  //i + 1 is a possible candidate for k.
                        int periods = input.Length / k;

                        string running_substring = input.Substring(0, k);

                        int j = 1;
                        for (; j < periods; j++)
                        {
                            StringBuilder sb = new StringBuilder(running_substring.Substring(k - 1, 1));
                            sb.Append(running_substring.Substring(0, k - 1));
                            running_substring = sb.ToString();
                            if (!running_substring.Equals(input.Substring(j * k, k))) break;
                        }

                        if (j == periods)
                        {
                            Console.WriteLine("{0}-periodic (k = {1})", k, k);
                            Console.WriteLine("Number of periods = {0}", periods);
                            Console.WriteLine("k-periodic substring is {0}", input.Substring(0, k));
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("String is not periodic. k = {0}.", input.Length);
            Console.ReadLine();

        }
    }
}
