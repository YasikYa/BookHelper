using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVocabulary.Models
{
    public class LearnWord
    {
        public string WordString { get; set; }

        public List<int> Documents { get; set; }
    }

    public class LearnWordComparer : IComparer<LearnWord>
    {
        public int Compare(LearnWord x, LearnWord y)
        {
            return x.WordString.CompareTo(y.WordString);
        }
    }
}