namespace _11.ExtractPricesOfOldAlbums
{
    using System;
    using System.Xml;

    public class ExtractPrice
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("../../../catalog.xml");
            XmlNode rootNode = doc.DocumentElement;
            string xPathYearQuery = "/catalog/album[year<2010]/price";
            XmlNodeList albumPrices = rootNode.SelectNodes(xPathYearQuery);

            foreach (XmlNode currentAlbumPrice in albumPrices)
            {
                Console.WriteLine("Price: {0}", currentAlbumPrice.InnerText);
            }
        }
    }
}
