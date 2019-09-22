using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Models;

namespace MyVocabulary.Models.ViewModels
{
    public class ContentViewModel
    {
        public int FileId { get; set; }

        public IEnumerable<WordInfo> Words { get; set; }
    }
}