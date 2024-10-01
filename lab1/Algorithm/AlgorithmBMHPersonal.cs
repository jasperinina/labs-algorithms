using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    // Алгоритм Бойера-Мура-Хорспула
    class AlgorithmBMHPersonal
    {
        public List<int> Indexes = new List<int>();
        private Dictionary<char, int> _tableOffset = new Dictionary<char, int>();
        public AlgorithmBMHPersonal(string text, string pattern)
        {
            _tableOffset = GetTableOffset(pattern);
            Indexes = GetIndexes(text, pattern);
        }

        // Метод для создания таблицы смещений
        private static Dictionary<char, int> GetTableOffset(string pattern)
        {
            Dictionary<char, int> table = new Dictionary<char, int>();
            string alf = string.Empty;

            for (int i = pattern.Length - 2; i > -1; i--)
            {
                if (!alf.Contains(pattern[i]))
                {
                    table[pattern[i]] = pattern.Length - i - 1;
                    alf += pattern[i];
                }
            }

            if (!alf.Contains(pattern[pattern.Length - 1]))
            {
                table[pattern[pattern.Length - 1]] = pattern.Length;
            }

            table.Add('*', pattern.Length);
            return table;
        }

        // Метод для поиска индексов
        public List<int> GetIndexes(string text, string pattern)
        {
            List<int> result = new List<int>();
            int textLen = text.Length;
            int patternLen = pattern.Length;

            int currentPosition = 0;
            while (currentPosition <= textLen - patternLen)
            {
                int indexPattern = patternLen - 1;
                while (indexPattern >= 0 && text[currentPosition + indexPattern] == pattern[indexPattern])
                {
                    indexPattern--;
                }
                if (indexPattern < 0)
                {
                    result.Add(currentPosition);
                    currentPosition++;
                }
                else
                {
                    if (_tableOffset.ContainsKey(text[currentPosition + patternLen - 1]))
                    {
                        currentPosition += _tableOffset[text[currentPosition + patternLen - 1]];
                    }
                    else
                    {
                        currentPosition += pattern.Length;
                    }
                }
            }
            return result;
        }
    }
}
