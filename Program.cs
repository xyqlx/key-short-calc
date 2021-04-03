using System;

namespace key_short_calc
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO 是否需要处理中英文之外的情况？
            string text = "嘉然diaNa";
            var calculator = new ShortCalaculator(new XiaoHeEncoder());
            Console.WriteLine(String.Join(',', calculator.Calc(text)));
        }
    }
}
