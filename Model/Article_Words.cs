using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Model
{
 public class Article_Words
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string wordPattern;

        public string WordPattern
        {
            get { return wordPattern; }
            set { wordPattern = value; }
        }
        private bool isForbid;

        public bool IsForbid
        {
            get { return isForbid; }
            set { isForbid = value; }
        }
        private bool isMod;

        public bool IsMod
        {
            get { return isMod; }
            set { isMod = value; }
        }
        private string replaceWord;

        public string ReplaceWord
        {
            get { return replaceWord; }
            set { replaceWord = value; }
        }
    }
}
