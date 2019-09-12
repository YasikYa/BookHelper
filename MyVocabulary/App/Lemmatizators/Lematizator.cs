using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Interfaces;
using LemmaSharp;

namespace MyVocabulary.App
{
    public class Lematizator : ILemmatizator
    {
        private readonly ILemmatizer lemmatizer = new LemmatizerPrebuiltFull(LanguagePrebuilt.English);

        public SortedDictionary<string, string> LemmasTable { get; } = new SortedDictionary<string, string>();

        public string GetLemma(string word)
        {
            if (LemmasTable.ContainsKey(word))
            {
                return LemmasTable[word];
            }
            else
            {
                string lemma = lemmatizer.Lemmatize(word);
                LemmasTable.Add(word, lemma);
                return lemma;
            }
        }

        public bool IsLemma(string word)
        {
            string lemma = GetLemma(word);
            return lemma.Equals(word);
        }
    }
}