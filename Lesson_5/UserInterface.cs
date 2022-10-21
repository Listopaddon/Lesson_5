using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    public class UserInterface
    {
        string line = string.Empty;
        List<string> lines = new List<string>();
        WorkWithSting work = new WorkWithSting();

        public void UI()
        {
            for (; ; )
            {
                Console.WriteLine("Choose some action");
                Console.WriteLine("1 - Search in string words with max number is digit");
                Console.WriteLine("2 - Search the longest word and how ofen then have you meet");
                Console.WriteLine("3 - Replace numbers on words");
                Console.WriteLine("4 - Print first with a question mark, then with an exclamation mark");
                Console.WriteLine("5 - Sentence without commas");
                Console.WriteLine("6 - Find words that begin and end with the same letter");
                Console.WriteLine("0 - Exit");
                int numerSecondChoose = int.Parse(Console.ReadLine());

                switch (numerSecondChoose)
                {
                    case 0:
                        Console.WriteLine("Good buy");
                        return;
                    case 1:
                        EnterString();
                        work.Output(work.FindWordWithMaxQuantityNumbers(line));
                        break;
                    case 2:
                        EnterString();
                        work.Output(work.SearchMaxWord(line));
                        break;
                    case 3:
                        EnterString();
                        work.Output(work.ReplaceNumbersOnWords(line));
                        break;
                    case 4:
                        EnterData();
                        work.Output(work.OutputBySign(lines.ToArray()));
                        break;
                    case 5:
                        EnterData();
                        work.Output(work.StringsWhichDontHaveCommas(lines.ToArray()));
                        break;
                    case 6:
                        EnterString();
                        work.Output(work.SearchWordsWhichStartAndEndWithOneLetter(line));
                        break;
                    default:
                        Console.WriteLine("wrong choose");
                        Console.WriteLine();
                        break;

                }
            }
        }

        private void EnterData()
        {
            Console.WriteLine("To choose action");
            Console.WriteLine("1 - Enter by hand");
            Console.WriteLine("2 - Enter with file");
            int number = int.Parse(Console.ReadLine());

            if (number == 1)
            {
                int quantityStrings = 0;
                Console.WriteLine("Enter some strings");
                Console.Write("How much strings?");
                string data = Console.ReadLine();
                Console.WriteLine();
                for (; ; )
                {
                    if (CheckWrongData(data))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Try again");
                        Console.WriteLine();
                    }
                }
                quantityStrings = int.Parse(data);

                for (int i = 0; i < quantityStrings; i++)
                {
                    lines.Add(Console.ReadLine());

                }
                Console.WriteLine();
            }
            else if (number == 2)
            {
                using (StreamReader reader = new StreamReader("D:\\TMS\\Lesson_5\\Lesson_5\\SomeStrings.txt"))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
        }

        public bool CheckWrongData(string check)
        {
            if (!int.TryParse(check, out int result))
            {
                return false;
            }
            return true;
        }

        private void EnterString()
        {
            Console.WriteLine("Enter some string");
            line = Console.ReadLine();
        }
    }
}
