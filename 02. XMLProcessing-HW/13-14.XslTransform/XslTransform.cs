namespace _14.XslTransform
{
    using System;
    using System.Xml.Xsl;

    public class XslTransform
    {
        public static void Main()
        {
            var xslt = new XslCompiledTransform();
            xslt.Load("../../../catalog.xsl");
            xslt.Transform("../../../catalog.xml", "../../catalog.html");
        }
    }
}
