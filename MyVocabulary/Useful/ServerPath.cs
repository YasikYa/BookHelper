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
            return @"E:\Programming\WeB\MyVocabulary\MyVocabulary\Files\Documents\" + docId + ".xml";
        }

        public static string MapUserVocabularyPath(string userName)
        {
            return @"E:\Programming\WeB\MyVocabulary\MyVocabulary\Files\UserVocabulares\" + userName + ".xml";
        }
    }
}