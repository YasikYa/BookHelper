using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Interfaces;
using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;

namespace MyVocabulary.App
{
    public class PdfFileProcceser : IFileProcceser<string>
    {
        #region properties
        public string FileName { get; }
        #endregion

        public PdfFileProcceser(string path)
        {
            FileName = path;
        }

        public string ProccesFile()
        {
            StringBuilder content = new StringBuilder();

            using (PdfReader reader = new PdfReader(FileName))
            {
                PdfDocument doc = new PdfDocument(reader);
                
                for (int i = 1; i < doc.GetNumberOfPages(); i++)
                {
                    content.Append(PdfTextExtractor.GetTextFromPage(doc.GetPage(i)));
                }
                return content.ToString();
            }

            
        }
    }
}