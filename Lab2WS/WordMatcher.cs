using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2WS
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            foreach (string scrambledWord in scrambledWords)
            {
                foreach (string word in wordList)
                {
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        //matchedWords.Add(BuildMatchedWord(scrambledWord, word));

                        matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });

                    }
                    else
                    {
                        //convert strings into character arrays i.e. ToCharArray()                        
                        char[] arrScWo;
                        char[] arrWo;                                 
                        arrScWo = scrambledWord.ToCharArray();
                        arrWo = word.ToCharArray();

                        //sort both character arrays                        
                        Array.Sort(arrScWo);
                        Array.Sort(arrWo);

                        //convert sorted character arrays into strings (toString)
                        string sortedScWo = new string(arrScWo);
                        string sortedWo = new string(arrWo);

                        //compare the two sorted strings. If they match, build the MatchWord
                        if (sortedScWo == sortedWo)
                        {
                            //struct and add to matchedWords list.
                            matchedWords.Add(new MatchedWord() { ScrambledWord = scrambledWord, Word = word });
                        }
                        
                    }

                }
            }

            return matchedWords;
        }

        MatchedWord BuildMatchedWord(string scrambledWord, string word)
        {
            MatchedWord matchedWord = new MatchedWord()
            {
                ScrambledWord = scrambledWord,
                Word = word
            };

            return matchedWord;
        }



    }
}
