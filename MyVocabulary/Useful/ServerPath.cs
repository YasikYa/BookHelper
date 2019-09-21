using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyVocabulary.Useful
{
    //TODO: Enum with file extensions
    public static class ServerPath
    {
        public static string MapDocumentPath(string docId)
        {
            return @"E:\Programming\WeB\MyVocabulary\MyVocabulary\Files\" + docId + ".xml";
        }
    }
}