using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.FileData.Interfaces;
using System.Xml.Serialization;
using System.IO;

namespace MyVocabulary.FileData.Concrete
{
    public abstract class XmlSourceBase<T> : ISource<T>
    {
        private ICollection<T> internalState;
        private XmlSerializer _serializer;
        private string _filePath;

        protected ICollection<T> items
        {
            get
            {
                if (internalState != null)
                {
                    return internalState;
                }
                else
                {
                    internalState = Load();
                    return internalState;
                }
            }
        }

        protected XmlSourceBase(string filePath)
        {
            _filePath = filePath;
            _serializer = new XmlSerializer(typeof(List<T>));
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach(T item in items)
            {
                this.items.Add(item);
            }
        }

        public T Get(Func<T, bool> predicate)
        {
             return items.Where(predicate).FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            foreach(T item in items)
            {
                yield return item;
            }
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public virtual void Save()
        {
            List<T> obj = items.ToList();
            using (var stream = System.IO.File.Open(_filePath, FileMode.Create))
            {
                _serializer.Serialize(stream, obj);
            }
        }

        protected virtual ICollection<T> Load()
        {
            if (System.IO.File.Exists(_filePath))
            {
                using (var stream = System.IO.File.Open(_filePath, FileMode.Open))
                {
                    return _serializer.Deserialize(stream) as List<T>;
                }
            }
            else
            {
                return new List<T>();
            }
        }

    }
}