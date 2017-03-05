using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using CalbucciLib;

namespace MemThief
{
    class Picture
    {
        public string Url;
        public string FilaName;
        public string FileSize;

        public Picture() { }

        public Picture(string url, string filesize, string filename)
        {
            Url = url;
            FileSize = filesize;
            FilaName = filename;
        }

        // Wyszukiwanie Wszystkich obrazkow
        public static List<Picture> GetAllPictures(string HtmlCode)
        {
            var parser = new HtmlParser(HtmlCode);
            List<Picture> PicList = new List<Picture>();

            parser.Parse(null, (HtmlElement element, bool isEmptyTag) =>
            {
                if (element.TagName == "img")
                {
                    string url = element.GetAttributeValue("src");
                    Download PicInfo = new Download(url);

                    if (!File.Exists(Config.StoragePath + PicInfo.Filename))
                    {
                        PicList.Add(new Picture(url, PicInfo.FileSize, PicInfo.Filename));
                    }
                    else
                    {
                        Print.PicInStorage(PicInfo.Filename);
                    }
                }
            });
            return PicList;
        }
    }
}
