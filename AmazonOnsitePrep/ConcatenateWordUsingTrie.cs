using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class ConcatenateWordUsingTrie
    {
        private List<string> result = new List<string>();
        public List<string> findAllConcatenatedWordsInADict(string[] words)
        {
            Trie trie = new Trie();
            trie.buildTrie(words);
            foreach(string word in words)
            {
                if (trie.searchTrie(word,0))
                {
                    result.Add(word);
                }
            }
            return result;
        }
    }

    public class TrieNodeCC
    {
        public Dictionary<char, TrieNodeCC> children;
        public string word;
        public int len;
        public TrieNodeCC()
        {
            children = new Dictionary<char, TrieNodeCC>();
            word = null;
            len = 0;
        }
    }

    public class Trie
    {
        TrieNodeCC root = new TrieNodeCC();
        public void buildTrie(string[] words)
        {
            foreach(string word in words){
                TrieNodeCC node = root;
                foreach(char _chr in word)
                {
                    if (!node.children.ContainsKey(_chr))
                    {
                        node.children.Add(_chr, new TrieNodeCC());
                    }
                    node = node.children[_chr];
                }
                node.word = word;
                node.len = word.Length;
            }
        }

        public bool searchTrie(string word, int sp)
        {
            TrieNodeCC node = root;
            for(int i = sp; i < word.Length; i++)
            {
                char curr = word[i];
                if (!node.children.ContainsKey(curr))
                {
                    return false;
                }
                node = node.children[curr];
                if (node.word != null)
                {
                    if (i == word.Length - 1 && node.len != word.Length)
                    {
                        return true;
                    }
                    else
                    {
                        if (searchTrie(word, i + 1))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
