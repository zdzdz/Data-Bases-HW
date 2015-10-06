namespace _04.RemoveHighPricedAlbums
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Xml;

    public class RemoveAlbums
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            var rootNode = doc.DocumentElement;

            foreach (XmlNode node in rootNode.SelectNodes("album"))
            {
                double currentAlbumPrice = double.Parse(node["price"].InnerText);
                if (currentAlbumPrice > 20)
                {
                    rootNode.RemoveChild(node);
                }
            }
            
            doc.Save("../../catalogWithoutHighPricedAlbums.xml");
            Console.WriteLine("Catalog changes saved");
        }
    }
}
