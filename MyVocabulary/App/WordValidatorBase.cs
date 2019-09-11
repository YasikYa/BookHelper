using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyVocabulary.Interfaces;

namespace MyVocabulary.App
{
    public abstract class WordValidatorBase : IWordValidator
    {
        protected IWordValidator _validator;

        public WordValidatorBase(IWordValidator validatorParam)
        {
            _validator = validatorParam;
        }

        public virtual bool Validate(string word)
        {
            if(_validator != null)
            {
                return _validator.Validate(word);
            }
            else
            {
                return true;
            }
        }
    }
}