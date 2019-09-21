using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Interfaces;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace MyVocabulary.Data
{
    public class XmlSource<T> : ISource<T> where T : class
    {
        private XmlSerializer _serializer = new XmlSerializer(typeof(T));
        private string physicalPath;
        private T internalState;

        public XmlSource(string filePath)
        {
            physicalPath = filePath;
        }

        public T Item
        {
            get
            {
                if (internalState != null)
                {
                    return internalState;
                }
                using (var stream = File.Open(physicalPath, FileMode.Open))
                {
                    internalState = (T)_serializer.Deserialize(stream);
                    return internalState;
                }
            }
            set
            {
                internalState = value;
            }
        }

        public void Save()
        {
            if(internalState != null)
            {
                using(var stream = File.Open(physicalPath, FileMode.OpenOrCreate))
                {
                    _serializer.Serialize(stream, internalState);
                    internalState = null;
                }
            }
        }
    }
}