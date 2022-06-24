using System;
using System.Collections.Generic;
using System.Text;

namespace C_sharp_text_parsing
{
    class utilities
    {
        public static string Join(string[] toJoin, string connecting = "")
        {
            string result = "";

            for (int i = 0; i < toJoin.Length; i++)
            {
                result += toJoin[i] + (i < toJoin.Length - 1 ? connecting : "");
            }


            return result;
        }

        public static string Splice(string[] input, out string[] output)
        {
            string toReturn = input[0];

            output = new string[input.Length - 1];

            for (int i = 1; i < input.Length; i++)
            {
                output[i - 1] = input[i];
            }

            return toReturn;
        }
    }
}
