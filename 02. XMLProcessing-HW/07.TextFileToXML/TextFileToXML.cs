namespace _07.TextFileToXML
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    public class TextFileToXML
    {
        public static void Main()
        {
            var person = new Person();

            using (StreamReader reader = new StreamReader("../../personTxt.txt"))
            {
                person.Name = reader.ReadLine();
                person.PhoneNumber = reader.ReadLine();
                person.City = reader.ReadLine();
            }

            XElement personElement = new XElement("person",
                new XElement("name", person.Name),
                new XElement("phoneNumber", person.PhoneNumber),
                new XElement("city", person.City));

            personElement.Save("../../personXML.xml");
            Console.WriteLine("Information transfered from text file to XML.");
        }
    }
}
