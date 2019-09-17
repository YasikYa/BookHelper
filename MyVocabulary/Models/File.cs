using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVocabulary.Models
{
    public class File
    {
        public int FileId { get; set; }

        public string FileName { get; set; }

        public int UserId { get; set; }

        public int ExtensionId { get; set; }

        public virtual AppUser User { get; set; }

        public virtual Extension Extension { get; set; }
    }
}