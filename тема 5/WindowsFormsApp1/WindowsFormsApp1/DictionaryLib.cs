using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DictionaryLib
{
    public class DictionaryService
    {
        private List<string> words = new List<string>();

        // Доступ к словам
        public List<string> Words => words;

        // Загрузка словаря из файла
        public void Load(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Файл не найден");

            words = File.ReadAllLines(path)
                        .Select(w => w.Trim().ToLower())
                        .Where(w => !string.IsNullOrEmpty(w))
                        .Distinct()
                        .ToList();
        }

        // Добавление слова (без дублей)
        public bool AddWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            word = word.Trim().ToLower();

            if (words.Contains(word))
                return false;

            words.Add(word);
            return true;
        }

        // Удаление слова
        public bool RemoveWord(string word)
        {
            return words.Remove(word.ToLower());
        }

        // Поиск по слогу (ВАРИАНТ 8)
        public List<string> FindBySubstring(string substring)
        {
            if (string.IsNullOrWhiteSpace(substring))
                return new List<string>();

            substring = substring.ToLower();

            return words
                .Where(w => w.Contains(substring))
                .ToList();
        }

        // Нечеткий поиск (Левенштейн ≤ 3)
        public List<string> FuzzySearch(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return new List<string>();

            word = word.ToLower();

            return words
                .Where(w => Levenshtein(w, word) <= 3)
                .ToList();
        }

        // Алгоритм Левенштейна
        private int Levenshtein(string s1, string s2)
        {
            int[,] d = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
                d[i, 0] = i;

            for (int j = 0; j <= s2.Length; j++)
                d[0, j] = j;

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(
                        Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
                        d[i - 1, j - 1] + cost);
                }
            }

            return d[s1.Length, s2.Length];
        }

        // Сохранение словаря
        public void Save(string path)
        {
            File.WriteAllLines(path, words.OrderBy(w => w));
        }
    }
}
