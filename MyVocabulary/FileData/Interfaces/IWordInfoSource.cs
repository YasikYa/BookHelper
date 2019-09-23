using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVocabulary.Models;

namespace MyVocabulary.FileData.Interfaces
{
    interface IWordInfoSource : ISource<WordInfo>
    {
        IEnumerable<WordInfo> GetNotLearned();
    }
}
