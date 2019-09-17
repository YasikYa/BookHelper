using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVocabulary.Models
{
    public class Extension
    {
        public int ExtensionId { get; set; }

        public string ExtensionString { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}