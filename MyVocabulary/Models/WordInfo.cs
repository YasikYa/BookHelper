using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVocabulary.Models
{
    public class WordInfo
    {
        public string WordString { get; set; }

        public int Count { get; set; }

        public int MyProperty { get; set; }

        public WordStatus Status { get; set; }
    }

    public enum WordStatus : byte
    {
        NotLearned,
        Learning,
        Learned
    }
}