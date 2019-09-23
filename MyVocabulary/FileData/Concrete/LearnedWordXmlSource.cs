using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Models;
using MyVocabulary.FileData.Interfaces;
using System.Xml.Serialization;

namespace MyVocabulary.FileData.Concrete
{
    public class LearnedWordXmlSource : XmlSourceBase<LearnWord>, ILearnedWordXmlSource
    {
        //XmlSerializer _serializer;

        public LearnedWordXmlSource(string filePath) : base(filePath)
        {
            //_serializer = new XmlSerializer(typeof(List<LearnWord>));
        }

        public bool IsLearned(string word, out LearnWord result)
        {
            return ((SortedSet<LearnWord>)items).TryGetValue(new LearnWord { WordString = word },out result);
        }

        //public override void Save()
        //{
        //    List<LearnWord> obj = items.ToList();
        //    using (var stream = System.IO.File.Open(_filePath, System.IO.FileMode.Create))
        //    {
        //        _serializer.Serialize(stream, obj);
        //    }
        //}

        protected override ICollection<LearnWord> Load()
        {
            var listLearnWord = base.Load();
            return new SortedSet<LearnWord>(listLearnWord, new LearnWordComparer());
        }
    }
}