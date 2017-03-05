using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MemThief
{
    class Config
    {
        public static string FilePath = @"Config.txt";
        public static string StoragePath;
        public static string LogStorage;
        public static int MaxPage = 0;
        public static int MaxPictures = 0;
        public static int MaxStorageSize = 0;
        public static string Website;
        public static bool ForceMode;
        private static string[] ConfigData;

        public static void Load()
        {
            ConfigData = File.ReadAllLines(FilePath);
            MaxPage = Convert.ToInt32(GetValue(ConfigData[0]));
            MaxPictures = Convert.ToInt32(GetValue(ConfigData[1]));
            StoragePath = GetValue(ConfigData[2]);
            LogStorage = GetValue(ConfigData[3]);
            Website = GetValue(ConfigData[4]).Trim();
            ForceMode = Convert.ToBoolean(GetValue(ConfigData[5]));
        }

        private static string GetValue(string DataLine)
        {
            int dot = DataLine.IndexOf('=');
            string count = DataLine.Substring(dot + 1);
            return count;
        }
    }
}
