using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyVocabulary.App;
using System.Collections.Generic;

namespace MyVocabulary.Tests
{
    [TestClass]
    public class LemmaTest
    {
        [TestMethod]
        public void CanGetLemmaFromWord()
        {
            Lematizator lematizator = new Lematizator();
            List<string> words = new List<string>()
            {
                "lists", "inflected", "sang", "singing", "songstresses", "mechanics"
            };
            List<string> results = new List<string>();

            foreach(var word in words)
            {
                results.Add(lematizator.GetLemma(word));
            }

            Assert.AreEqual("list", results[0]);
            Assert.AreEqual("inflect", results[1]);
            Assert.AreEqual("sing", results[2]);
            Assert.AreEqual("sing", results[3]);
            Assert.AreEqual("songstress", results[4]);
            Assert.AreEqual("mechanic", results[5]);
        }

        [TestMethod]
        public void CanCheckLemma()
        {
            Lematizator lematizator = new Lematizator();
            List<string> words = new List<string>()
            {
                "or", "typical", "song"
            };

            bool result = lematizator.IsLemma(words[0])
                && lematizator.IsLemma(words[1]) && lematizator.IsLemma(words[2]);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanChenNonLemma()
        {
            Lematizator lematizator = new Lematizator();
            List<string> words = new List<string>()
            {
                "lists", "sang", "analyzed"
            };

            bool result = !lematizator.IsLemma(words[0])
                && !lematizator.IsLemma(words[1]) && !lematizator.IsLemma(words[2]);

            Assert.IsTrue(result);
        }
    }
}
