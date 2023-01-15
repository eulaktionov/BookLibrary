using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibLib
{
    public class Author : IdName
    {
        public string FirstName { get; set; }
    }

    public class Lib
    {
        public IdNameList<Author> Authors { get; set; }
        public Lib() 
        {
            Authors = new IdNameList<Author>();
        }
    }

    public class LibSerializer 
    {
        string fileName;
        XmlSerializer serializer;

        public LibSerializer(string fileName)
        {
            this.fileName = fileName;
            serializer = new XmlSerializer(typeof(Lib));
        }

        public Lib Open()
        {
            using FileStream file = new FileStream(fileName, FileMode.Open);
            return (Lib)serializer.Deserialize(file);
        }

        public void Save(Lib lib)
        {
            using FileStream xmlFile = new FileStream(fileName, FileMode.Create);
            serializer.Serialize(xmlFile, lib);
        }
    }
}
