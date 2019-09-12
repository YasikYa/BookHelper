using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Interfaces;
using System.IO;

namespace MyVocabulary.App
{
    public class StopwordsWordValidator : WordValidatorBase
    {
        private readonly string _stopwordsPath = @"E:\Programming\WeB\MyVocabulary\MyVocabulary\StaticFiles\stopwords.txt";

        public List<string> Stopwords { get; private set; } = null;

        public StopwordsWordValidator(IWordValidator validatorParam) : base(validatorParam)
        {
        }

        public override bool Validate(string word)
        {
            return !IsStopword(word, GetStopwords()) && base.Validate(word);
        }

        private List<string> GetStopwords()
        {
            if(Stopwords == null)
            {
                List<string> stopwords = File.ReadAllLines(_stopwordsPath).ToList();
                stopwords.Sort();
                return stopwords;
            }
            else
            {
                return Stopwords;
            }
        }

        private bool IsStopword(string word, List<string> stopwords)
        {
            if(stopwords.BinarySearch(word) < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}