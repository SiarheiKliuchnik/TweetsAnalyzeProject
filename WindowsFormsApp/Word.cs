using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    class Word
    {
        private string content;
        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                if (value != null)
                    this.content = value;
            }
        }
        private char PunctuationMark;
        public char PunctuationMark_
        {
            get
            {
                return this.PunctuationMark;
            }
            set
            {
                this.PunctuationMark = value;
            }
        }
        public Word()
        {
        }
        public Word(Word word)
        {
            this.content = word.content;
            this.PunctuationMark = word.PunctuationMark;
        }
    }
}
