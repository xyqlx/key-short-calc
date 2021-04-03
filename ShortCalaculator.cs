using System;
using System.Collections.Generic;
using System.Linq;

namespace key_short_calc
{
    public class ShortCalaculator
    {
        public ShortCalaculator(IChineseEncoder encoder)
        {
            this.encoder = encoder;
        }

        private IChineseEncoder encoder;

        public IEnumerable<char> Calc(string sentence)
        {
            HashSet<char> charSet = new HashSet<char>(
                sentence.Select(x => Char.IsLower(x) ? Char.ToUpper(x) : x)
                .Select(x => IsChinese(x) ? encoder.encode(x) : x)
            );
            // 表示剩余的字母按键
            HashSet<char> letterSet = new HashSet<char>(
                Enumerable.Range('A', 26).Select(x => (char)x)
            );
            // 不输出相同字符
            bool CheckYeild(char ch)
            {
                var upper = Char.IsLower(ch) ? Char.ToUpper(ch) : ch;
                if (letterSet.Contains(upper))
                {
                    letterSet.Remove(upper);
                }
                if (charSet.Contains(upper))
                {
                    charSet.Remove(upper);
                    return true;
                }
                return false;
            }
            // 大写或者非字母后的小写
            bool letterBefore = false;
            foreach (var c in sentence)
            {
                if (IsEnglishLetter(c))
                {
                    if (letterBefore)
                    {
                        if (Char.IsLower(c))
                        {
                            letterBefore = true;
                            continue;
                        }
                    }
                    letterBefore = true;
                    if (CheckYeild(c))
                    {
                        yield return Char.ToUpper(c);
                    }
                }
                else
                {
                    letterBefore = false;
                    if (IsChinese(c))
                    {
                        var letter = encoder.encode(c);
                        if (CheckYeild(letter))
                        {
                            yield return letter;
                        }
                    }
                }
            }
            // 其他字母
            foreach (var ch in charSet.Where(x => IsEnglishLetter(x)))
            {
                CheckYeild(ch);
                yield return ch;
            }
            // 剩余字母
            foreach (var letter in letterSet)
            {
                yield return letter;
            }
        }

        public static bool IsEnglishLetter(char ch)
        {
            return (
                (ch >= 'a' && ch <= 'z') ||
                (ch >= 'A' && ch <= 'Z')
            );
        }

        public static bool IsChinese(char ch)
        {
            return ch >= 0x4e00 && ch <= 0x9fbb;
        }
    }
}