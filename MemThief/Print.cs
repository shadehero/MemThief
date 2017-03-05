using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemThief
{
    class Print
    {
        public static void Pic(Picture pic)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("# Downloading Picture ");
            Console.ResetColor();
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(pic.FilaName);
            Console.ResetColor();
            Console.Write("] ");
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(pic.FileSize);
            Console.ResetColor();
            Console.Write("]\n");

            Logger.Add("# Downloading Picture [" + pic.FilaName + "]" + "[" + pic.FileSize + "]");
        }

        public static void PicInStorage(string filename)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("# Picture");
            Console.ResetColor();
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(filename);
            Console.ResetColor();
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" In Storage\n");
            Console.ResetColor();

            Logger.Add("# Picture [" + filename + "] In Storage");
        }

        public static void FindNewPic(string count)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("# Find ");
            Console.ResetColor();
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(count);
            Console.ResetColor();
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" New Pictures\n");
            Console.ResetColor();

            Logger.Add("# Find [" + count + "] New Pictures");
        }

        public static void DownloadPage(string count)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("# Download ");
            Console.ResetColor();
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(count);
            Console.ResetColor();
            Console.Write("] ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" Page\n");
            Console.ResetColor();

            Logger.Add("# Download [" + count + "] Page");
        }
    }
}
