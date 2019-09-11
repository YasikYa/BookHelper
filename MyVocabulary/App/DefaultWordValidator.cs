using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Interfaces;

namespace MyVocabulary.App
{
    public class DefaultWordValidator : WordValidatorBase
    {
        public DefaultWordValidator(IWordValidator validatorParam = null) : base(validatorParam)
        {

        }

        public int MinWordSize { get; set; } = 2;

        public override bool Validate(string word)
        {
            return word.ToCharArray().All(s => Char.IsLetter(s)) &&
                   word.Count() > MinWordSize && base.Validate(word);
        }
    }
}