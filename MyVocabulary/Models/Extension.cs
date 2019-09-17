using System.Collections.Generic;

namespace MyVocabulary.Models
{
    public class Extension
    {
        public Extension()
        {
            Files = new List<File>();
        }

        public int ExtensionId { get; set; }

        public string ExtensionString { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}