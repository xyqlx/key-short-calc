using System;
using System.Collections.Generic;
using System.Linq;
using key_short_calc.Encoder;

namespace key_short_calc
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO 是否需要处理中英文之外的情况？
            var comparator = StringComparer.CurrentCulture;
            var calculator = new WordsShortCalculator(
                new ShortCalculator(new XiaoHeEncoder()),
                comparator
            );
            var keys = calculator.Calc(new[]{
                    "欢迎来到世界",
                    "七海千秋",
                    "七海Nana7mi",
                    "Nanana"
                });
            foreach(var key in keys.Keys.OrderBy(x=>x, comparator)){
                System.Console.WriteLine($"{key}: {keys[key]}");
            }
        }
    }
}
