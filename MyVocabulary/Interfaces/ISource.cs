using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVocabulary.Interfaces
{
    interface ISource<T> where T: class
    {
        T Item {get;set;}
        void Save();
    }
}
