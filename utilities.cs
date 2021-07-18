using System;
using System.Collections.Generic;
using System.Text;

namespace C_sharp_text_parsing
{
    class utilities
    {
        public string Join(string[] toJoin, string connecting = "")
        {
            string sesult = "";

            for (int i = 0; i < toJoin.Length; i++)
            {
                sesult += toJoin[i] + connecting;
            }


            return sesult;
        }
    }
}
