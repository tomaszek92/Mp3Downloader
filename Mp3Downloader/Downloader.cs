using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mp3Downloader
{
    public class Downloader
    {
        public static string DownloadString(string path)
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                return client.DownloadString(path);
            }
        }

        public static void DownloadFile(string pathToDownload, string pathToSave)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(pathToDownload, pathToSave);
            }
        }
    }
}
