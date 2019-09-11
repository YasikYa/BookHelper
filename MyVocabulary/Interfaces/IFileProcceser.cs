using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVocabulary.Interfaces
{
    public interface IFileProcceser<T> 
    {
        T ProccesFile();
    }
}
