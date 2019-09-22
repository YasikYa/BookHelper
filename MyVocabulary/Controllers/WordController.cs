using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyVocabulary.FileData.Interfaces;
using MyVocabulary.FileData.Concrete;
using MyVocabulary.Useful;
using MyVocabulary.Models;

namespace MyVocabulary.Controllers
{
    [Authorize]
    public class WordController : Controller
    {
        ILearnedWordXmlSource _learnedWords;
        IWordInfoSource _documentWords;
        // GET: Word

        public ActionResult Index()
        {
            _learnedWords = new LearnedWordXmlSource(ServerPath.MapUserVocabularyPath(UserName));
            var words = _learnedWords.GetAll().ToList();
            return View(words);
        }

        public ActionResult AddToLearned(int fileId, string[] words)
        {
            _documentWords = new WordInfoXmlSource(ServerPath.MapDocumentPath(fileId.ToString()));
            _learnedWords = new LearnedWordXmlSource(ServerPath.MapUserVocabularyPath(UserName));
            foreach(string word in words)
            {
                var wordInfo = _documentWords.Get(w => w.WordString == word);
                wordInfo.Status = Models.WordStatus.Learned;

                LearnWord outValue;
                bool learned = _learnedWords.IsLearned(word,out outValue);

                if (learned)
                {
                    outValue.Documents.Add(fileId);
                }
                else
                {
                    outValue = new LearnWord { WordString = word, Documents = new List<int> { fileId } };
                    _learnedWords.Add(outValue);
                }
            }

            _documentWords.Save();
            _learnedWords.Save();
            return RedirectToAction("Load", "Home", new { fileId = fileId });
        }

        //TODO: change remove logic in XmlSource
        public ActionResult Remove(int fileId, string[] words)
        {
            _documentWords = new WordInfoXmlSource(ServerPath.MapDocumentPath(fileId.ToString()));
            foreach(var word in words)
            {
                var wordToRemove = _documentWords.Get(w => w.WordString == word);
                _documentWords.Remove(wordToRemove);
            }
            _documentWords.Save();
            return RedirectToAction("Load", "Home", new { fileId = fileId });
        }

        #region helpers
        private string UserName
        {
            get
            {
                return User.Identity.Name;
            }
        }
        #endregion
    }
}