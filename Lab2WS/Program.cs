using System;
using System.Collections.Generic;
using System.IO;

namespace Lab2WS
{
    class Program
    {
        private static readonly FileReader fileReader = new FileReader();
        private static readonly WordMatcher wordMatcher = new WordMatcher();

        static void Main(string[] args)
        {
            bool contin = true;

            while (contin == true)
            {
                bool exit = false;
                while (exit == false)
                {
                    try
                    {
                        Console.WriteLine("Enter the scrambled words manually or as a file: f - file, m = manual");

                        string option = Console.ReadLine() ?? throw new Exception("String is null");


                        switch (option.ToUpper())
                        {
                            case "F":
                                Console.WriteLine("Enter the full path and filename >");
                                ExecuteScrambledWordsInFileScenario();
                                exit = true;
                                break;
                            case "M":
                                Console.WriteLine("Enter word(s) separated by a comma");
                                ExecuteScrambledWordsManualEntryScenario();
                                exit = true;
                                break;
                            default:
                                Console.WriteLine("The entered option was not recognized");
                                break;
                        }

                        // Optional for now (when you have no loop)  (Take out when finished)
                        Console.ReadKey();

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Sorry an error has occurred.. " + e.Message);
                    }
                }

                Console.WriteLine($"Would you like to continue? Y / N");
                string YesOrNo = Console.ReadLine();

                switch (YesOrNo.ToUpper())
                {
                    case "Y":
                        contin = true;
                        break;
                    case "YES":
                        contin = true;
                        break;
                    case "N":
                        contin = false;
                        break;
                    case "NO":
                        contin = false;
                        break;
                }

            }
        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string fileName = Console.ReadLine();
            string[] scrambledWords = fileReader.Read(fileName);
            DisplayMatchedScrambledWords(scrambledWords);
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            // 1 get the user's input - comma separated string containing scrambled words
            string wordsFromUser = Console.ReadLine();

            // 2 Extract the words into a string (red,blue,green) 
            string[] arrFromUser = wordsFromUser.Split(' ', ',');

            // 3 Call the DisplayMatchedUnscrambledWords method passing the scrambled words string array
            DisplayMatchedScrambledWords(arrFromUser);
        }

        private static void DisplayMatchedScrambledWords(string[] scrambledWords)
        {
            string[] wordList = fileReader.Read(Constants.WORDLIST); // Put in a constants file. CAPITAL LETTERS.  READONLY.
            
            List<MatchedWord> matchedWords = wordMatcher.Match(scrambledWords, wordList);

            // Rule:  Use a formatter to display ... eg:  {0}{1}
            // Rule:  USe an IF to determine if matchedWords is empty or not......
            if (matchedWords != null)
            {
                foreach (MatchedWord wd in matchedWords)
                {
                    Console.WriteLine("Match found for {0} : {1}", wd.ScrambledWord, wd.Word);
                }
            }
            else
            {
                Console.WriteLine("No matches found");
            }

            //            if empty - display no words found message.
            //            if NOT empty - Display the matches.... use "foreach" with the list (matchedWords)
        }
    }
}
