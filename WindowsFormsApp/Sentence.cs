using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp
{
    class Sentence
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
        private List<Word> words;
        public List<Word> Words_
        {
            get { return this.words; }
        }
        public Sentence()
        {
            this.words = new List<Word>();
        }

        //public void Add(Word word)
        //{
        //    this.words.Add(word);
        //}
        public Sentence(Sentence sentence)
        {
            this.content = sentence.content;
            this.words = new List<Word>(sentence.words);
        }
    }
}
