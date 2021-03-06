﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Interfaces;
using MyVocabulary.App.Factories;

namespace MyVocabulary.App
{
    public class TextWorker : ITextParser
    {
        #region dependecies
        private readonly IFileProcceser<string> _fileProc;
        private readonly ILemmatizator _lemmatizator;
        public IWordValidator WordValidator { get; set; } = new DefaultWordValidator();
        #endregion

        #region ctors
        public TextWorker(IFileProccessorFactory factory)
        {
            _fileProc = factory.CreateFileProcceser();
        }

        public TextWorker(IFileProccessorFactory factory, IWordValidator wordValidator) : this(factory)
        {
            if(wordValidator != null)
            {
                WordValidator = wordValidator;
            }
        }

        public TextWorker(IFileProccessorFactory factory,
            IWordValidator wordValidator,
            ILemmatizator lemmatizator) : this(factory, wordValidator)
        {
            _lemmatizator = lemmatizator;
        }
        #endregion
        
        public IEnumerable<KeyValuePair<string, int>> CountWords()
        {
            Dictionary<string, int> wordsCount = new Dictionary<string, int>();

            string currentWord = string.Empty;
            string text = _fileProc.ProccesFile();

            string[] words = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach(string word in words)
            {
                currentWord = word.ToLower().Trim(new char[] { '.', '(', ')', ',' });

                if (wordsCount.ContainsKey(currentWord))
                {
                    wordsCount[currentWord]++;
                }
                else
                {
                    wordsCount.Add(currentWord, 1);
                }
            }

            DeleteInvalidEnties(wordsCount);
            LemmatizeWords(wordsCount);

            return wordsCount.OrderByDescending(k => k.Value);
        }

        private void DeleteInvalidEnties(Dictionary<string, int> wordsCount)
        {
            var keyWords = wordsCount.Keys.ToList();

            foreach (var keyWord in keyWords)
            {
                if (!IsValidWord(keyWord))
                {
                    wordsCount.Remove(keyWord);
                }
            }
        }

        private bool IsValidWord(string word)
        {
            return WordValidator.Validate(word);
        }

        private void LemmatizeWords(Dictionary<string, int> wordsCount)
        {
            int nonLemmaEntries;
            var keyWords = wordsCount.Keys.ToList();

            foreach(var word in keyWords)
            {
                if (!_lemmatizator.IsLemma(word))
                {
                    nonLemmaEntries = wordsCount[word];
                    wordsCount.Remove(word);
                    string lemma = _lemmatizator.GetLemma(word);

                    if (wordsCount.ContainsKey(lemma))
                    {
                        wordsCount[lemma] += nonLemmaEntries;
                    }
                    else
                    {
                        wordsCount.Add(lemma, nonLemmaEntries);
                    }
                }
            }
        }
    }
}