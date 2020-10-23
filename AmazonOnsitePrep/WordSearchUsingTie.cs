using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOnsitePrep
{
    public class WordSearchUsingTie
    {
        private char[][] _board = null;
        private List<string> _result = new List<string>();
        public WordSearchUsingTie()
        {

        }

        public List<string> findWords(char[][] board, string[] words)
        {
            //Step 1: Construct a trie with words list
            Trie root = buildTrie(words);

            this._board = board;

            //Step 2: Perform backtracking
            for (int row = 0; row < board.Length; row++)
            {
                for (int column = 0; column < board[row].Length; column++)
                {
                    if (root.containsKey(board[row][column]))
                    {
                        backTracking(row, column, root);
                    }
                }
            }

            return this._result;
        }

        private void backTracking(int row, int column, Trie parent)
        {
            char letter = this._board[row][column];
            Trie currNode = parent.get(letter);

            //Check if there is any match
            if (currNode.GetWord() != null)
            {
                this._result.Add(currNode.GetWord());
                currNode.AssignWord(null);
            }

            //Mark current letter before EXPLORATION
            this._board[row][column] = '#';

            //explore each neighbour of the cell in around-clock direction: up, right, down, left
            int[] rowOffSet = new int[] { -1, 0, 1, 0};
            int[] columnOffSet = new int[] { 0, 1, 0, -1};

            for(int i = 0; i < 4; i ++)
            {
                int newRow = row + rowOffSet[i];
                int newColumn = column + columnOffSet[i];
                if (newRow < 0 || newColumn < 0 || newRow >= this._board.Length ||
                    newColumn >= this._board[0].Length)
                {
                    continue;
                }
                if (currNode.containsKey(this._board[newRow][newColumn]))
                {
                    backTracking(newRow, newColumn, currNode);
                }
            }

            //End of EXPLORATION, restore the original letter in the board
            this._board[row][column] = letter;

            //OPTIMIZATION: Incrementally remove leaf node
            if (currNode.isChildrenEmpty())
            {
                parent.remove(letter);
            }
        }

        private static Trie buildTrie(string[] words)
        {
            Trie root = new Trie();
            foreach (string word in words)
            {
                Trie node = root;
                foreach (char _ch in word)
                {
                    if (node.containsKey(_ch))
                    {
                        node = node.get(_ch);
                    }
                    else
                    {
                        Trie newNode = new Trie();
                        node.put(_ch, newNode);
                        node = newNode;
                    }
                }
                node.AssignWord(word);
            }

            return root;
        }
        public class Trie
        {
            private Dictionary<char, Trie> children;
            private string _word = null;

            public Trie()
            {
                children = new Dictionary<char, Trie>();
            }

            public bool containsKey(char ch)
            {
                return children.ContainsKey(ch);
            }

            public Trie get(char ch)
            {
                return children[ch];
            }

            public void put(char ch, Trie node)
            {
                children.Add(ch, node);
            }

            public void AssignWord(string word)
            {
                _word = word;
            }

            public string GetWord()
            {
                return _word;
            }

            public bool isChildrenEmpty()
            {
                return children.Count > 0;
            }

            public void remove(char letter)
            {
                children.Remove(letter);
            }
        }
    }
}
