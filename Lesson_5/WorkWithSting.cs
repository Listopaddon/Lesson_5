using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_5
{
    public class WorkWithSting
    {

        public List<string> FindWordWithMaxQuantityNumbers(string line)
        {
            List<string> results = new List<string>();

            string[] words = line.Split(' ');
            int[] quantityNumbers = new int[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                char[] symbols = words[i].ToCharArray();
                int quantity = 0;
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (symbols[j] >= '0' && symbols[j] <= '9')
                    {
                        quantity++;
                    }
                }
                quantityNumbers[i] = quantity;
            }

            int maxQuantity = 0;
            for (int i = 0; i < quantityNumbers.Length; i++)
            {
                if (quantityNumbers[i] > maxQuantity)
                {
                    maxQuantity = quantityNumbers[i];
                }
            }

            for (int i = 0; i < quantityNumbers.Length; i++)
            {
                if (quantityNumbers[i] == maxQuantity)
                {
                    results.Add(words[i]);
                }
            }

            return results;
        }

        public string SearchMaxWord(string line)
        {
            int searchWord = 0;
            int count = 0;

            string[] words = line.Split(' ');
            int quantityLetters = 0;

            for (int i = 0; i < words.Length; i++)
            {
                char[] letters = words[i].ToCharArray();
                if (letters.Length > quantityLetters)
                {
                    quantityLetters = letters.Length;
                    searchWord = i;
                    count = 1;
                }
                else if (letters.Length == quantityLetters)
                {
                    count++;
                }
            }

            return $"Max word is {words[searchWord]} quantity is {count}";
        }

        public string ReplaceNumbersOnWords(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                switch (line[i])
                {

                    case '0':
                        line = line.Remove(i, 1);
                        line = line.Insert(i, "ноль");
                        break;
                    case '1':
                        line = line.Remove(i, 1);
                        line = line.Insert(i, "один");
                        break;
                    case '2':
                        line = line.Remove(i, 1);
                        line = line.Insert(i, "два");
                        break;
                    case '3':
                        line = line.Remove(i, 1);
                        line = line.Insert(i, "три");
                        break;
                    case '4':
                        line = line.Remove(i, 1);
                        line = line.Insert(i, "четыре");
                        break;
                    case '5':
                        line = line.Remove(i, 1);
                        line = line.Insert(i, "пять");
                        break;
                    case '6':
                        line = line.Remove(i, 1);
                        line = line.Insert(i, "шесть");
                        break;
                    case '7':
                        line = line.Remove(i, 1);
                        line = line.Insert(i, "семь");
                        break;
                    case '8':
                        line = line.Remove(i, 1);
                        line = line.Insert(i, "восемь");
                        break;
                    case '9':
                        line = line.Remove(i, 1);
                        line = line.Insert(i, "девять");
                        break;
                }
            }

            return line;
        }

        public string[] OutputBySign(string[] checkLines)
        {
            string[] lines = checkLines;

            for (int i = 0; i < lines.Length; i++)
            {
                char[] symbol = lines[i].ToCharArray();
                if (symbol[symbol.Length - 1] != '?' &&
                    symbol[symbol.Length - 1] != '!') // провека последнего символа
                {
                    string temp = lines[i];
                    lines[i] = lines[lines.Length - 1];
                    lines[lines.Length - 1] = temp;
                    symbol = lines[i].ToCharArray();
                }

                if (symbol[symbol.Length - 1] != '?')
                {
                    for (int j = i + 1; j < lines.Length; j++)  // поиск нужного последнего символа
                    {
                        char[] symbolSecond = lines[j].ToCharArray();
                        if (symbolSecond[symbolSecond.Length - 1] == '?')
                        {
                            string temp = lines[i];
                            lines[i] = lines[j];
                            lines[j] = temp;
                            break;
                        }
                    }
                }
            }

            return lines;
        }

        public List<string> StringsWhichDontHaveCommas(string[] checkLines)
        {
            List<string> result = new List<string>();

            for (int i = 0; i < checkLines.Length; i++)
            {
                char[] symbols = checkLines[i].ToCharArray();

                if (CheckString(symbols))
                {
                    result.Add(checkLines[i]);
                }
            }

            return result;
        }

        public List<string> SearchWordsWhichStartAndEndWithOneLetter(string line)
        {
            List<string> result = new List<string>();

            string[] words = line.Split(new char[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                char[] symbols = words[i].ToCharArray();

                if (symbols[0] == symbols[symbols.Length - 1])
                {
                    result.Add(words[i]);
                }
            }

            return result;
        }

        public void Output(List<string> lines)
        {
            Console.WriteLine("Result");
            foreach (string word in lines)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }
        public void Output(string[] lines)
        {
            Console.WriteLine("Result");
            foreach (string word in lines)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }

        public void Output(string line)
        {
            Console.WriteLine(line);
            Console.WriteLine();
        }

        private bool CheckString(char[] symbols)
        {
            for (int j = 0; j < symbols.Length; j++)
            {
                if (symbols[j] == ',')
                {
                    return false;
                }
            }

            return true;
        }

    }
}
