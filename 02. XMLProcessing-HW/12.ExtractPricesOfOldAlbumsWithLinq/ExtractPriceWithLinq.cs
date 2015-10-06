namespace _12.ExtractPricesOfOldAlbumsWithLinq
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractPriceWithLinq
    {
        public static void Main()
        {
            XDocument doc = XDocument.Load("../../../catalog.xml");

            var albumPrices =
                from album in doc.Descendants("album")
                where int.Parse(album.Element("year").Value) < 2010
                select new
                {
                    Price = album.Element("price").Value,
                };

            foreach (var currentAlbumPrice in albumPrices)
            {
                Console.WriteLine("Price: {0}", currentAlbumPrice.Price);
            }
        }
    }
}
