﻿using System;
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

            _parser = new TextWorker(new FileProcceserFactory(filePath),
                new StopwordsWordValidator(new DefaultWordValidator()),
                new Lematizator());
            

            return View("Content", model: _parser.CountWords());
        }

        #region helpers
        private string SaveFile(HttpPostedFileBase file)
        {
            string fileName = Path.GetFileName(file.FileName);
            string physicalPath = Server.MapPath("~/Files/" + fileName);
            file.SaveAs(physicalPath);
            return physicalPath;
        }
        #endregion
    }
}