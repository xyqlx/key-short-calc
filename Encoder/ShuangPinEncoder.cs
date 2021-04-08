using System;

namespace key_short_calc.Encoder
{
    public class PinYinEncoder: IChineseEncoder{
        public char encode(char ch){
            var pinyin = NPinyin.Pinyin.GetInitials(new string(ch, 1));
            return pinyin[0];
        }
    }
}