using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Mp3Downloader
{
    class Program
    {
        private static void Main(string[] args)
        {
            string htmlCode = Downloader.DownloadString("http://www.barbara-kacperska.pl/audio.html");

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(htmlCode);
            
            AudioFile[] filesToDownload = FindUrlsWithAudioFile(htmlDocument, "http://www.barbara-kacperska.pl/").ToArray();

            for (int i = 0; i < filesToDownload.Length; i++)
            {
                Console.WriteLine("Downloading {0} from {1}", i, filesToDownload.Length);
                Downloader.DownloadFile(filesToDownload[i].Url, filesToDownload[i].Name + ".mp3");
            }
            Console.WriteLine("Download is end");
        }

        private static IEnumerable<AudioFile> FindUrlsWithAudioFile(HtmlDocument htmlDocument, string urlPrefix = "")
        {
            IEnumerable<HtmlNode> nodes = htmlDocument
                .DocumentNode
                .Descendants("a")
                .Where(elem => elem.Attributes.Contains("class") && elem.Attributes["class"].Value.Contains("audioButton"));

            return nodes.Select(node => new AudioFile
            {
                Name = node.InnerText.Trim(),
                Url = urlPrefix + node.Attributes["href"].Value
            });
        }
    }
}
