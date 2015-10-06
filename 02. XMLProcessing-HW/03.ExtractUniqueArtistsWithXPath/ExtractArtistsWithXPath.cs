namespace _02.ExtractUniqueArtistsFromCatalog
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

    public class ExtractUniqueArtistsWithXPath
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            XmlNode rootNode = doc.DocumentElement;
            string xPathQuery = "/catalog/album/artist";
            XmlNodeList albums = rootNode.SelectNodes(xPathQuery);
            var uniqueArtistsInfo = new Dictionary<string, int>();

            foreach (XmlNode node in albums)
            {
                string currentArtist = node.InnerText;

                if (uniqueArtistsInfo.ContainsKey(currentArtist))
                {
                    uniqueArtistsInfo[currentArtist]++;
                }
                else
                {
                    uniqueArtistsInfo.Add(currentArtist, 1);
                }
            }

            foreach (var artist in uniqueArtistsInfo)
            {
                Console.WriteLine("Artist {0} has {1} number of albums.", artist.Key, artist.Value);
            }
        }
    }
}
