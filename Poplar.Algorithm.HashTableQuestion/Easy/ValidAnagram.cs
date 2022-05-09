using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.HashTableQuestion.Easy
{
    internal class ValidAnagram
    {
        /// <summary>
        /// 双循环  2n
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagramTwo(string s, string t)
        {
            var dic = new Dictionary<char, int>();
            foreach (var item in s)
            {
                if (dic.ContainsKey(item)) dic[item] += 1;
                else dic[item] = 1;
            }
            foreach (var item in t)
            {
                if (!dic.ContainsKey(item)) return false;
                dic[item]--;
                if (dic[item] == 0) dic.Remove(item);
            }
            return dic.Count == 0;
        }

        /// <summary>
        /// 简单粗暴，排序、重新组成字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagramOne(string s, string t)
        {
            return new string(s.ToCharArray().OrderBy(item => item).ToArray()) == new string(t.ToCharArray().OrderBy(item => item).ToArray());
        }
    }
}
