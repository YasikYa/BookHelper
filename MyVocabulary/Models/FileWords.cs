using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVocabulary.Models
{
    public class FileWord
    {
        [Key]
        [Column(Order =1)]
        public int FileId { get; set; }

        [Key]
        [Column(Order =2)]
        public int WordId { get; set; }

        public virtual Word Word { get; set; }

        public virtual File File { get; set; }

        public int Count { get; set; }
    }

    public class FileWordComparator : IComparer<FileWord>
    {
        public int Compare(FileWord x, FileWord y)
        {
            return x.Count.CompareTo(y.Count);
        }
    }
}