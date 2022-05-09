using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poplar.Algorithm.HashTableQuestion
{
    /// <summary>
    /// https://leetcode.cn/problems/group-anagrams/  字母异位词分组
    /// </summary>
    internal class GroupAnagrams
    {
        /// <summary>
        /// 对于数组中的每个字符串，都计算这个字符串中的每个字母出现的次数。
        /// 最后按照字母顺序和出现次数这样组成一个key，类似a_1,b_2,c_3，再根据这个key将数据放入字典中。
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagramsTwp(string[] strs)
        {
            var map = new Dictionary<string, IList<string>>();
            foreach (var item in strs)
            {
                var chars = new char[26];
                foreach (var c in item) chars[c - 'a']++;
                var arr = new List<string>();
                for (var i = 0; i < chars.Length; i++) if (chars[i] != 0) arr.Add($"{i + 'a'}_{chars[i]}");
                var key = string.Join(",", arr);
                if (map.ContainsKey(key)) map[key].Add(item);
                else map.Add(key, new List<string>() { item });
            }
            return map.Select(item => item.Value).ToList();
        }

        /// <summary>
        /// 对数组中的每个字符串的长度排序，排完序之后再放字典中。
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public IList<IList<string>> GroupAnagramsOne(string[] strs)
        {
            var map = new Dictionary<string, IList<string>>();
            foreach (var item in strs)
            {
                var s = new string(item.OrderBy(c => c).ToArray());
                if (map.ContainsKey(s)) map[s].Add(item);
                else map.Add(s, new List<string>() { item });
            }
            return map.Select(item => item.Value).ToList();
        }
    }
}
