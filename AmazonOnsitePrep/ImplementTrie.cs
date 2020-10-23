using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class ImplementTrie
    {
        private TrieNode root;
        public ImplementTrie()
        {
            root = new TrieNode();
        }

        public void insert(string word)
        {
            //define Trie node as root
            TrieNode node = root;
            foreach(char _ch in word)
            {
                if (!node.containsKey(_ch))
                {
                    node.put(_ch, new TrieNode());
                }

                node = node.get(_ch);
            }
            node.setEnd();
        }

        private TrieNode searchPrefix(string word)
        {
            TrieNode node = root;
            foreach (var _ch in word)
            {
                if (node.containsKey(_ch))
                    node = node.get(_ch);
                else
                    return null;
            }

            return node;
        }  

        public bool search(string word)
        {
            TrieNode node = searchPrefix(word);
            return node != null && node.isEnd();
        }

        public bool startWith(string prefix)
        {
            TrieNode node = searchPrefix(prefix);
            return node != null;
        }
    }

    public class TrieNode
    {
        private TrieNode[] links;
        private const int R = 26;
        private bool _isEnd;

        public TrieNode()
        {
            links = new TrieNode[R];
        }

        public bool containsKey(char ch)
        {
            //return true/false for element at index 'ch - 'a''
            return links[ch - 'a'] != null;
        }

        public TrieNode get(char ch)
        {
            return links[ch - 'a'];
        }

        public void put(char ch, TrieNode node)
        {
            links[ch - 'a'] = node;
        }

        public void setEnd()
        {
            _isEnd = true;
        }

        public bool isEnd()
        {
            return _isEnd;
        }
    }
}
