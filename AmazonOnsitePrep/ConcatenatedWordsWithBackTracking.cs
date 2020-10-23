using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
	public class TrieNodeCon
	{
		public Dictionary<char, TrieNodeCon> Children = new Dictionary<char, TrieNodeCon>();
		public string word;
		public TrieNodeCon()
		{

		}
	}
	public class ConcatenatedWordsWithBackTracking
	{
		//Appreach2: Using Backtracking
		public List<string> findAllConcatinatedWordsInDictA2(string[] words)
		{
			List<string> ans = new List<string>();
			HashSet<string> wordSet = new HashSet<string>(words);
			Dictionary<string, bool> cache = new Dictionary<string, bool>();
			foreach (string word in words)
			{
				if (dfs(word, wordSet, cache))
					ans.Add(word);
			}
			return ans;
		}
		//Word Break
		public bool dfs(string word, HashSet<string> wordSet, Dictionary<string, bool> cache)
		{
			if (cache.ContainsKey(word))
				return cache[word];
			for (int i = 0; i < word.Length; i++)
			{
				if (wordSet.Contains(word.Substring(0, i + 1)))
				{
					string suffix = word.Substring(i + 1);
					if (wordSet.Contains(suffix) || dfs(suffix, wordSet, cache))
					{
						cache.Add(word, true);
						return true;
					}
				}
			}
			cache.Add(word, false);
			return false;
		}
	}
}
