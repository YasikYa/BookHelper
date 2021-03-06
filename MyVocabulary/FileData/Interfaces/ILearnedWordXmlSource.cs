﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyVocabulary.Models;

namespace MyVocabulary.FileData.Interfaces
{
    interface ILearnedWordXmlSource : ISource<LearnWord>
    {
        bool IsLearned(string word, out LearnWord result);
    }
}
