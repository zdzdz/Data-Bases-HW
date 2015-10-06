namespace _05.ExtractSongTitles
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractSongTitlesWithXDocument
    {
        public static void Main()
        {
            XDocument doc = XDocument.Load("../../../catalog.xml");

            var songs =
                from song in doc.Descendants("song")
                select new
                {
                    Title = song.Element("title").Value,
                };

            foreach (var song in songs)
            {
                Console.WriteLine("Song: {0}", song.Title);
            }
        }
    }
}
