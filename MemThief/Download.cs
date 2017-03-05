using System;
using MemThief;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;

namespace MemThief
{
    class Download
    { 

        public WebClient Client;
        public string Filename;
        public string FileSize;
        public string FilePath;
        public string Url;

        public Download()
        {
            Client = new WebClient();
        }

        public Download(string url, string filepath)
        {
            Client = new WebClient();
            Url = url;
            Filename = GetFileName(Url);
            FileSize = GetFileSize(new Uri(Url));
            FilePath = filepath;  
        }

        public Download(string url)
        {
            Client = new WebClient();
            Url = url;
            Filename = GetFileName(Url);
            FileSize = GetFileSize(new Uri(Url));
        }

        // Sprawdza Czy Link jest OK
        public static bool CheckUrl(string url)
        {
            try
            {
                Uri t = new Uri(url);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Pobieranie Strony 
        public string GetWebsite()
        {
            try
            {
                return Client.DownloadString(Url);
            }
            catch(WebException e)
            {
                Console.WriteLine(e.Message);
                Logger.Add(e.Message);
                return string.Empty;
            } 
        }

        // Pobieranie Pliku
        public void GetFile()
        {
            if (Directory.Exists(FilePath))
            {
                try
                {
                    Client.DownloadFile(Url, FilePath + GetFileName(Url));
                }
                catch (WebException e)
                {
                    Console.WriteLine(e.Message);
                    Logger.Add(e.Message);
                }
            }
            else
            {
                Console.WriteLine("Lokalizacja " + FilePath + "Nie Istnieje");
                Logger.Add("Lokalizacja " + FilePath + "Nie Istnieje");
            }
        }

        // Generowanie Nazwy Pliku
        public string GetFileName(string Url)
        {

            Uri uri = new Uri(Url);
            return Path.GetFileName(uri.LocalPath);
        }

        // Generowanie Rozmiaru Pliku
        public string GetFileSize(Uri Url)
        {
            var webRequest = HttpWebRequest.Create(Url);
            webRequest.Method = "HEAD";

            try
            {
                using (var webResponse = webRequest.GetResponse())
                {
                    var fileSize = webResponse.Headers.Get("Content-Length");
                    var fileSizeInMegaByte = Math.Round(Convert.ToDouble(fileSize) / 1024.0, 2);
                    return fileSizeInMegaByte + " KB";
                }
            }
            catch (WebException e)
            {
                return "0";
                Logger.Add(e.Message);
            }
        }
    }
}
