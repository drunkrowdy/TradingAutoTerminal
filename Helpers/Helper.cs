using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingAutoTerminal.Helpers
{
    static class Helper
    {
        public static string ReadStringFromFile(string file)
        {
            string res = "";
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    res = sr.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                res = null;
                Console.WriteLine(e.Message);
            }
            return res;
        }
    }
}
