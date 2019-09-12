using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Interfaces;
using System.IO;

namespace MyVocabulary.App.Factories
{
    public class FileProcceserFactory : IFileProccessorFactory
    {
        private readonly string _filePath;

        public FileProcceserFactory(string filePath)
        {
            _filePath = filePath;
        }

        public IFileProcceser<string> CreateFileProcceser()
        {
            if (File.Exists(_filePath))
            {
                FileInfo file = new FileInfo(_filePath);

                switch (file.Extension)
                {
                    case ".pdf":
                        return new PdfFileProcceser(_filePath);
                        break;
                    default:
                        return null;
                }
            }

            throw new Exception("file not found!");
        }
    }
}