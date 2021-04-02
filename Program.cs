using System;

namespace key_short_calc
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO 按照方案将中文转换为拼音
            // TODO 是否需要处理中英文之外的情况？
            string text = "嘉然diaNa";
            Console.WriteLine(String.Join(',', ShortCalaculator.Calc(text)));
        }
    }
}
