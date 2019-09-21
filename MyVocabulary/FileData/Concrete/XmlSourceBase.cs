using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.FileData.Interfaces;

namespace MyVocabulary.FileData.Concrete
{
    public abstract class XmlSourceBase<T> : ISource<T>
    {
        private ICollection<T> internalState;

        protected string _filePath;

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

        public XmlSourceBase(string filePath)
        {
            _filePath = filePath;
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

        public abstract void Save();

        protected abstract ICollection<T> Load();

    }
}