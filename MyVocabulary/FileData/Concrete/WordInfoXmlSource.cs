using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Models;
using MyVocabulary.FileData.Interfaces;
using System.Xml.Serialization;
using System.IO;

namespace MyVocabulary.FileData.Concrete
{
    public class WordInfoXmlSource : XmlSourceBase<WordInfo>, IWordInfoSource
    {
        private XmlSerializer _serializer;

        public WordInfoXmlSource(string filePath) : base(filePath)
        {
            _serializer = new XmlSerializer(typeof(List<WordInfo>));
        }

        public IEnumerable<WordInfo> GetNotLearned()
        {
            return items.Where(i => i.Status == WordStatus.NotLearned).ToList();
        }

        public override void Save()
        {
            using(var stream = System.IO.File.Open(_filePath, FileMode.Create))
            {
                _serializer.Serialize(stream, (List<WordInfo>)items);
            }
        }

        protected override ICollection<WordInfo> Load()
        {
            if (System.IO.File.Exists(_filePath))
            {
                using (var stream = System.IO.File.Open(_filePath, FileMode.Open))
                {
                    return _serializer.Deserialize(stream) as List<WordInfo>;
                }
            }
            else
            {
                //var stream = System.IO.File.Create(_filePath);
                //stream.Close();
                return new List<WordInfo>();
            }
        }
    }
}