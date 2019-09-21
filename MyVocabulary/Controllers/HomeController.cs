using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using iText.Pdfa;
using iText.Kernel.Pdf;
using System.Text;
using iText.Kernel.Pdf.Canvas.Parser;
using MyVocabulary.Interfaces;
using MyVocabulary.App;
using System.IO;
using MyVocabulary.App.Factories;
using MyVocabulary.Useful;
using MyVocabulary.IdentityConfig;
using MyVocabulary.FileData.Concrete;
using MyVocabulary.Models;

namespace MyVocabulary.Controllers
{
    public class HomeController : Controller
    {
        ITextParser _parser;
        AppDbContext _context;
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Upload(HttpPostedFileBase upload)
        {
            string filePath = SaveFile(upload);
            string xmlFilePath;

            _parser = new TextWorker(new FileProcceserFactory(filePath),
                new StopwordsWordValidator(new DefaultWordValidator()),
                new Lematizator());
            
            using(_context = new AppDbContext())
            {
                string ext = Path.GetExtension(filePath);
                var user = _context.Users.First(u => u.UserName == User.Identity.Name);
                Models.File file = new Models.File
                {
                    Extension = _context.Extensions.FirstOrDefault(e => e.ExtensionString == ext),
                    FileName = Path.GetFileNameWithoutExtension(filePath),
                    UserId = user.Id
                };
                
                _context.Files.Add(file);
                _context.SaveChanges();

                xmlFilePath = ServerPath.MapDocumentPath(file.FileId.ToString());
            }

            WordInfoXmlSource source = new WordInfoXmlSource(xmlFilePath);
            source.AddRange(ConvertToWordInfo(_parser.CountWords()));
            source.Save();

            return View("Content", model: source.GetAll().ToList());
        }

        #region helpers
        private string SaveFile(HttpPostedFileBase file)
        {
            string fileName = Path.GetFileName(file.FileName);
            string physicalPath = Server.MapPath("~/Files/Documents/" + fileName);
            file.SaveAs(physicalPath);
            return physicalPath;
        }

        private List<WordInfo> ConvertToWordInfo(IEnumerable<KeyValuePair<string, int>> wordsCount)
        {
            List<WordInfo> wordsInfo = new List<WordInfo>(wordsCount.Count());
            foreach(var pair in wordsCount)
            {
                wordsInfo.Add(new WordInfo { WordString = pair.Key, Count = pair.Value });
            }
            return wordsInfo;
        }
        #endregion
    }
}