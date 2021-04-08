using System;
using System.Collections.Generic;
using System.Linq;
using key_short_calc.Encoder;

namespace key_short_calc
{
    // 大概是过滤池一样的东西？
    // 不过这个似乎并不需要写，因为有搜索引擎嘛
    public class WordPool
    {
        ShortCalculator calculator;
        HashSet<string> words;
        Dictionary<string, HashSet<char>> keys;
        public WordPool(ShortCalculator calculator, IEnumerable<string> words = null)
        {
            this.calculator = calculator;
            this.words = words?.ToHashSet() ?? new();
            this.keys = words.ToDictionary(w=>w, w=>calculator.Calc(w).ToHashSet());
        }
    }
}