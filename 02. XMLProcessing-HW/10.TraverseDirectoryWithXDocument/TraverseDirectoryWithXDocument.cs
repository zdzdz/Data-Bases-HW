namespace _10.TraverseDirectoryWithXDocument
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Linq;

    public class TraverseDirectoryWithXDocument
    {
        public static void Main()
        {
            string directory = "M:\\GitHub\\Data-Bases-HW\\02. XMLProcessing-HW\\09.TraverseDirectoryContentToXML";
            var rootDirectory = new DirectoryInfo(directory);

            XElement directoryInfo = new XElement("root");
            directoryInfo.Add(TraverseDirectory(rootDirectory));

            directoryInfo.Save("../../directoryInfo.xml");
        }

        private static XElement TraverseDirectory(DirectoryInfo directory)
        {
            var el = new XElement("dir", new XAttribute("path", directory.Name));
            foreach (var dir in directory.GetDirectories())
            {
                el.Add(TraverseDirectory(dir));
            }

            foreach (var file in directory.GetFiles())
            {
                el.Add(new XElement("file", new XAttribute("name", file.Name)));
            }

            return el;
        }
    }
}
