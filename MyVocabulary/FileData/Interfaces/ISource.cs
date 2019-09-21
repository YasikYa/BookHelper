using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVocabulary.FileData.Interfaces
{
    interface ISource<T>
    {
        void Add(T item);
        void AddRange(IEnumerable<T> items);

        T Get(Func<T, bool> predicate);
        IEnumerable<T> GetAll();

        void Remove(T item);

        void Save();
    }
}
