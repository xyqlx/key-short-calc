using System;
using System.Collections.Generic;
using System.Linq;
using key_short_calc.Encoder;

namespace key_short_calc
{
    // 大概是过滤池一样的东西？
    // 不过这个似乎并不需要写，因为有搜索引擎嘛
    public class WordsShortCalculator
    {
        ShortCalculator calculator;
        IComparer<string> comparator;
        public WordsShortCalculator(ShortCalculator calculator, IComparer<string> comparator)
        {
            this.calculator = calculator;
            this.comparator = comparator;
        }

        
        public Dictionary<string, char> Calc(IEnumerable<string> words)
        {
            Dictionary<string, char> keys = new();
            var shorts = words.ToDictionary(w => w, w => calculator.Calc(w).ToList());
            var chosen = new HashSet<char>();
            List<string> toRemove;
            while (shorts.Count != 0)
            {
                toRemove = new List<string>();
                foreach (var key in shorts.Keys.OrderBy(x=>x, comparator))
                {
                    if (shorts[key].Count == 0)
                    {
                        toRemove.Add(key);
                        continue;
                    }
                    char first = shorts[key].First();
                    if (!chosen.Contains(first))
                    {
                        chosen.Add(first);
                        keys[key] = first;
                        toRemove.Add(key);
                    }
                    shorts[key].RemoveAt(0);
                }
                foreach (var key in toRemove)
                {
                    shorts.Remove(key);
                }
            }
            return keys;
            
        }
    }
}