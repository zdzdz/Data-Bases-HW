namespace _01.RSSFeedParser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Xml.Linq;

    using _01.RSSFeedParser.VideoComponents;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public class RSSParser
    {
        public static void Main()
        {
            string telerikAcademyRSSFeedURL = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
            string rssXMLFileToSave = "../../telerikRSSFeed.xml";

            string rssXMLFeed = DownloadRSSFeed(telerikAcademyRSSFeedURL, rssXMLFileToSave);

            string rssJSONFeed = XMLToJSON(rssXMLFeed);
            // Console.WriteLine(telerikRSSFeedJSON);

            var titles = GetAllVideoTitlesFromJSON(rssJSONFeed);
            //Console.WriteLine(string.Join(Environment.NewLine, titles));

            var videos = GetAllVideosFromJSON(rssJSONFeed);

            var htmlPage = GenerateHtml(videos);
            File.WriteAllText("../../videos.html", htmlPage, Encoding.UTF8);
        }

        private static string GenerateHtml(IEnumerable<Video> items)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<!DOCTYPE html><html><body><ul>");

            foreach (var item in items)
            {
                sb.AppendFormat("<li style=\"list-style-type:none;\"><a href=\"{0}\"><strong>{1}</strong></a></li>", item.Link.Href, item.Title);
                sb.AppendFormat("<iframe width=\"420\" height=\"315\" src=\"http://www.youtube.com/embed/{0}?autoplay=1\"></iframe>", item.Id);
            }

            sb.AppendLine("</ul></body></html>");

            return sb.ToString();
        }

        private static IEnumerable<Video> GetAllVideosFromJSON(string rssJSONFeed)
        {
            var jsonRSSObj = JObject.Parse(rssJSONFeed);
            var extractedVideos = jsonRSSObj["feed"]["entry"].Select(v => JsonConvert.DeserializeObject<Video>(v.ToString()));

            return extractedVideos;
        }

        private static IEnumerable<JToken> GetAllVideoTitlesFromJSON(string telerikRSSFeedJSON)
        {
            var jsonRSSObj = JObject.Parse(telerikRSSFeedJSON);
            var titles = jsonRSSObj["feed"]["entry"].Select(e => e["title"]);

            return titles;
        }

        private static string XMLToJSON(string rssXMLFile)
        {
            var doc = XDocument.Load(rssXMLFile);
            string telerikRSSFeedJSON = JsonConvert.SerializeXNode(doc, Formatting.Indented);

            return telerikRSSFeedJSON;
        }

        private static string DownloadRSSFeed(string telerikAcademyRSSFeedURL, string rssXMLFile)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(telerikAcademyRSSFeedURL, rssXMLFile);
            }

            return rssXMLFile;
        }
    }
}
