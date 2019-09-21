using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyVocabulary.App.Factories;
using MyVocabulary.Interfaces;
using MyVocabulary.App;

namespace MyVocabulary.Tests
{
    [TestClass]
    public class FileFactoryTest
    {
        [TestMethod]
        public void CanCreatePdfFileProcceser()
        {
            string fileName = "test.pdf";
            FileProcceserFactory target = new FileProcceserFactory(fileName);

            IFileProcceser<string> fileProcceser = target.CreateFileProcceser();
            bool result = fileProcceser is PdfFileProcceser;

            Assert.IsTrue(result);
        }
    }
}
