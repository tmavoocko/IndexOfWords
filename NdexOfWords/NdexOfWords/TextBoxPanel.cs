using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NdexOfWords
{
    class TextBoxPanel : RichTextBox
    {
        public Dictionary<string, List<Tuple<int, int>>> validWords = new Dictionary<string, List<Tuple<int, int>>>();
        protected bool inOp = false;
        public void ParseText()
        {
            if (!inOp)
            {
                inOp = true;
                validWords.Clear();

                for (int i = 0; i < Lines.Length; i++)
                {
                    string line = Regex.Replace(Lines[i], @"\t|\n|\r", " ");
                    while (line.Contains("  ")) line = line.Replace("  ", " ");
                    string[] splitLine = line.Split(' ');
                    for (int j = 0; j < splitLine.Length; j++)
                    {
                        string word = splitLine[j].Trim(S.Separators);
                        if (word.Length > 3 && !word.Any(char.IsNumber) && word != word.ToUpper())
                        {
                            if (validWords.Keys.Contains(word))
                            {
                                Tuple<int, int> t = new Tuple<int, int>(i, j);
                                validWords[word].Add(t);
                            }
                            else
                            {
                                List<Tuple<int, int>> list = new List<Tuple<int, int>>();
                                Tuple<int, int> t = new Tuple<int, int>(i, j);
                                list.Add(t);
                                validWords.Add(word, list);
                            }
                        }
                    }
                }
                inOp = false;
            }
        }
    }
    class OutputPanel : RichTextBox
    {

    }
}