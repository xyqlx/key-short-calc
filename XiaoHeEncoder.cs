using System;
using System.Collections.Generic;

namespace key_short_calc
{
    public class XiaoHeEncoder: IChineseEncoder{
        private static Dictionary<string, string> table = new Dictionary<string, string>{
            ["ZH"] = "V",
            ["CH"] = "I",
            ["SH"] = "U"
        };
        public char encode(char ch){
            var pinyin = NPinyin.Pinyin.GetPinyin(ch).ToUpper();
            foreach (var prefix in table.Keys)
            {
                if(pinyin.StartsWith(prefix)){
                    return table[prefix][0];
                }
            }
            return pinyin[0];
        }
    }
}