using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemThief
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 100;
            Config.Load();
            int PageCount = 1;
            int PictureCount = 1;

            Console.WriteLine(" <====> MemThief v1.0 <====>\n");
            Console.WriteLine("# Connecting... Please Wait...\n");
            Download Repostuj = new Download(@"http://www.repostuj.pl/" + PageCount);

            while (true)
            {
                Repostuj.Url = @"http://www.repostuj.pl/" + PageCount;

                Print.DownloadPage(PageCount.ToString());
                List<Picture> PicList = Picture.GetAllPictures(Repostuj.GetWebsite());
                Console.ForegroundColor = ConsoleColor.Blue;
                Print.FindNewPic(PicList.Count.ToString());
                Console.ResetColor();
                for (int i = 0; i < PicList.Count; i++)
                {
                    Download Pic = new Download(PicList[i].Url, Config.StoragePath);
                    Print.Pic(PicList[i]);
                    Pic.GetFile();
                    PictureCount++;
                }
                PageCount++;

                if (PageCount > Config.MaxPage || PictureCount > Config.MaxPictures)
                { return; }
            }
        }
    }
}
