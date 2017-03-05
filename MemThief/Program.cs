using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemThief
{
    class Program
    {
        #region Repostuj - Thread
        static void Repostuj()
        {
            int PageCount = 1;
            int PictureCount = 1;
            string AdressUrl = @"http://www.repostuj.pl/";

            while (true)
            {
                Download Repostuj = new Download(AdressUrl + PageCount);
                Repostuj.Url = AdressUrl + PageCount;
                Console.WriteLine(" <> " + Repostuj.Url + " <> ");
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
        #endregion

        #region Kwejk - Thread
        static void Kwejk()
        {
            int PageCount = 1;
            int PictureCount = 1;
            string AdressUrl = @"https://kwejk.pl/";

            while (true)
            {
                Download Kwejk = new Download(AdressUrl + PageCount);
                Kwejk.Url = AdressUrl + @"strona/" + PageCount;
                Console.WriteLine(Kwejk.Url);
                List<Picture> PicList = Picture.GetAllPictures(Kwejk.GetWebsite());
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
        #endregion

        #region Jbzd - Therad
        static void Jbzd()
        {
            int PageCount = 1;
            int PictureCount = 1;
            string AdressUrl = @"https://jbzd.pl/";
            while (true)
            {
                Download Jbzd = new Download(AdressUrl + PageCount);
                Jbzd.Url = AdressUrl + @"strona/" + PageCount;
                Console.WriteLine(Jbzd.Url);
                List<Picture> PicList = Picture.GetAllPictures(Jbzd.GetWebsite());
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
        #endregion

        #region Besty - Thread
        static void Besty()
        {
            int PageCount = 1;
            int PictureCount = 1;
            string AdressUrl = @"https://besty.pl/";

            while (true)
            {
                Download Besty = new Download(AdressUrl + PageCount);
                Besty.Url = AdressUrl + @"pages/" + PageCount;
                Console.WriteLine(Besty.Url);
                List<Picture> PicList = Picture.GetAllPictures(Besty.GetWebsite());
                Console.ForegroundColor = ConsoleColor.Blue;
                Print.FindNewPic(PicList.Count.ToString());
                Console.ResetColor();
                for (int i = 1; i < PicList.Count; i++)
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
        #endregion

        #region Paczaizm - Therad
        static void Paczaizm()
        {
            int PageCount = 1;
            int PictureCount = 1;
            string AdressUrl = @"https://paczaizm.pl/";

            while (true)
            {
                Download Paczaiz = new Download(AdressUrl + PageCount);
                Paczaiz.Url = AdressUrl + @"page/" + PageCount;
                Console.WriteLine(Paczaiz.Url);
                List<Picture> PicList = Picture.GetAllPictures(Paczaiz.GetWebsite());
                Console.ForegroundColor = ConsoleColor.Blue;
                Print.FindNewPic(PicList.Count.ToString());
                Console.ResetColor();
                for (int i = 1; i < PicList.Count; i++)
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
        #endregion

        #region Main
        static void Main(string[] args)
        {
            Console.WindowWidth = 120;
            Config.Load();
            
            Console.WriteLine(" <====> MemThief v1.0 <====>\n");
            Console.WriteLine("Connecting - " + Config.Website);

            if (Config.ForceMode)
            {
                #region Run All Threads
                List<Thread> ThreadList = new List<Thread>();

                ThreadList.Add(new Thread(new ThreadStart(Repostuj)));
                ThreadList.Add(new Thread(new ThreadStart(Kwejk)));
                ThreadList.Add(new Thread(new ThreadStart(Jbzd)));
                ThreadList.Add(new Thread(new ThreadStart(Besty)));
                ThreadList.Add(new Thread(new ThreadStart(Paczaizm)));

                foreach (Thread th in ThreadList)
                {
                    th.Start();
                }
                #endregion
            }
            else
            {
                #region Run Single Threads
                if (Config.Website.Contains("repostuj"))
                {
                    Thread RepostujThread = new Thread(new ThreadStart(Repostuj));
                    RepostujThread.IsBackground = true;
                    RepostujThread.Start();
                }
                else if (Config.Website.Contains("kwejk"))
                {
                    Thread RepostujThread = new Thread(new ThreadStart(Kwejk));
                    RepostujThread.IsBackground = true;
                    RepostujThread.Start();
                }
                else if (Config.Website.Contains("jbzd"))
                {
                    Thread RepostujThread = new Thread(new ThreadStart(Jbzd));
                    RepostujThread.IsBackground = true;
                    RepostujThread.Start();
                }
                else if (Config.Website.Contains("besty"))
                {
                    Thread RepostujThread = new Thread(new ThreadStart(Besty));
                    RepostujThread.IsBackground = true;
                    RepostujThread.Start();
                }
                else if (Config.Website.Contains("paczaizm"))
                {
                    Thread RepostujThread = new Thread(new ThreadStart(Paczaizm));
                    RepostujThread.IsBackground = true;
                    RepostujThread.Start();
                }
                else
                {
                    Console.WriteLine("Page Not Found 404");
                }
                #endregion
            }
            Console.Read();
        }
        #endregion
    }
}
