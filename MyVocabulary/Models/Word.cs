using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyVocabulary.Models
{
    public class Word
    {
        [Index(IsUnique =true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WordId { get; set; }

        [Key]
        [StringLength(30)]
        public string WordString { get; set; }

        public virtual ICollection<AppUser> Users { get; set; }

        public virtual ICollection<FileWord> FileWords { get; set; }
    }
}