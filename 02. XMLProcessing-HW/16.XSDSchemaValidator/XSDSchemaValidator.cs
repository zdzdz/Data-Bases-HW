namespace _16.XSDSchemaValidator
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class XSDSchemaValidator
    {
        public static void Main()
        {
            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, "../../catalog.xsd");
            XDocument correctDoc = XDocument.Load("../../../catalog.xml");
            XDocument invalidDoc = XDocument.Load("../../invalidCatalog.xml");

            ValidateXML(schema, correctDoc);
            ValidateXML(schema, invalidDoc);
        }

        private static void ValidateXML(XmlSchemaSet schema, XDocument correctDoc)
        {
            Console.WriteLine("Validating...");
            bool hasError = false;

            correctDoc.Validate(schema, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                hasError = true;
            });

            Console.WriteLine("XML document {0}", hasError ? "did not validate" : "validated");
            Console.WriteLine();
        }
    }
}
