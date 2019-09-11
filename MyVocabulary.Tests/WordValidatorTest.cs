using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyVocabulary.App;
using MyVocabulary.Interfaces;

namespace MyVocabulary.Tests
{
    [TestClass]
    public class WordValidatorTest
    {
        [TestMethod]
        public void CanValidateWord()
        {
            bool resultTrue, resultFalse;
            WordValidatorBase target = new DefaultWordValidator();

            string word1 = "hello";
            string word2 = "hello.";

            resultTrue = target.Validate(word1);
            resultFalse = target.Validate(word2);

            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
        }

        [TestMethod]
        public void CanValidateBaseDecorator()
        {
            bool resultTrue, resultFalse, resultFalse2;
            IWordValidator target = new StopwordsWordValidator(new DefaultWordValidator());

            string word1 = "hello";
            string word2 = "hello.";
            string word3 = "about";

            resultTrue = target.Validate(word1);
            resultFalse = target.Validate(word2);
            resultFalse2 = target.Validate(word3);

            Assert.IsTrue(resultTrue);
            Assert.IsFalse(resultFalse);
            Assert.IsFalse(resultFalse2);
        }
    }
}
