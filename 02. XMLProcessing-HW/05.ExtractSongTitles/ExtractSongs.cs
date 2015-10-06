namespace _05.ExtractSongTitles
{
    using System;
    using System.Xml;

    public class ExtractSongs
    {
        public static void Main()
        {
            using (XmlReader reader = XmlReader.Create("../../../catalog.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "title"))
                    {
                        Console.WriteLine("Song: {0}", reader.ReadElementString());
                    }
                }
            }
        }
    }
}
