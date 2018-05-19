using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Aho_Corasick
{
    public class Trie : Trie<string>
    {
        /// <summary>
        /// Добавление строки в бор 
        /// </summary>
        /// <param name="s"></param>
        public void Add(string s)
        {
            Add(s, s);
        }

        /// <summary>
        /// Добавление нескольких строк
        /// </summary>
        /// <param name="strings"></param>
        public void Add(IEnumerable<string> strings)
        {
            foreach (string s in strings)
            {
                Add(s);
            }
        }
    }

    /// <summary>
    /// Бор который находит каждую строку и возвращает её тип для каждой найденной строки
    /// </summary>
    /// <typeparam name="TValue"></typeparam>
    public class Trie<TValue> : Trie<char, TValue>
    {
    }

    /// <summary>
    /// Реализация бора которая будет находить соотвествия и возвращать их 
    /// </summary>
    /// <remarks>
    /// <typeparamref name="T"/> может быть как символом так и строкой в зависимости от длины ответа
    /// </remarks>
    /// <typeparam name="T">Тип найденной буквы(вершины)</typeparam>
    /// <typeparam name="TValue">Тип который будет возвращен в качестве ответа</typeparam>
    public class Trie<T, TValue>
    {
        /// <summary>
        /// Корень бора
        /// </summary>
        private readonly Node<T, TValue> root = new Node<T, TValue>();

        /// <summary>
        /// Добавление слова в бор
        /// </summary>
        /// <remarks>
        /// Для каждой буквы строится вершина
        /// Каждая вершина это символ их результирующая есть строка
        /// Но если слово состоит из одной буквы оно так же будет являтся строкой
        /// </remarks>
        /// <param name="word">слово которое будет найдено</param>
        /// <param name="value">возвращаемое значение </param>
        public void Add(IEnumerable<T> word, TValue value)
        {
            var node = root;

            // строит веть для слова
            // если такой вершины нет, или к ней нет пути, строит новую вершину
            foreach (T c in word)
            {
                var child = node[c];

                if (child == null)
                    child = node[c] = new Node<T, TValue>(c, node);

                node = child;
            }

            // ставит флаг в конце ветви - значит слово закончено
            // происходит при нахождении слова во строке поиска
            node.Values.Add(value);
        }

        public void Build()
        {
            var queue = new Queue<Node<T, TValue>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                // смотрим на потомков нашей вершину
                foreach (var child in node)
                    queue.Enqueue(child);

                // если возвращаемся к корню, переходим к следующей буковке 
                if (node == root)
                {
                    root.Fail = root;
                    continue;
                }

                var fail = node.Parent.Fail;

                while (fail[node.Word] == null && fail != root)
                    fail = fail.Fail;

                node.Fail = fail[node.Word] ?? root;
                if (node.Fail == node)
                    node.Fail = root;
            }
        }

        /// <summary>
        /// Находит все слова из шаблока которые есть в тексте
        /// </summary>
        /// <param name="text"></param>        
        public IEnumerable<TValue> Find(IEnumerable<T> text)
        {
            var node = root;

            foreach (T c in text)
            {
                while (node[c] == null && node != root)
                    node = node.Fail;

                node = node[c] ?? root;

                for (var t = node; t != root; t = t.Fail)
                {
                    foreach (TValue value in t.Values)
                        yield return value;
                }
            }
        }

        /// <summary>
        /// Реализация вершины бора
        /// </summary>      
        private class Node<TNode, TNodeValue> : IEnumerable<Node<TNode, TNodeValue>>
        {
            private readonly TNode word;
            private readonly Node<TNode, TNodeValue> parent;
            private readonly Dictionary<TNode, Node<TNode, TNodeValue>> children = new Dictionary<TNode, Node<TNode, TNodeValue>>();
            private readonly List<TNodeValue> values = new List<TNodeValue>();

            /// <summary>
            /// Корень
            /// </summary>
            public Node()
            {
            }

            /// <summary>
            /// Вершина
            /// </summary>
            /// <param name="word"></param>
            /// <param name="parent"></param>
            public Node(TNode word, Node<TNode, TNodeValue> parent)
            {
                this.word = word;
                this.parent = parent;
            }

            /// <summary>
            /// Слово или символ по которому мы до этой вершины добираемся
            /// </summary>
            public TNode Word
            {
                get { return word; }
            }

            /// <summary>
            /// Отцовская вершина
            /// </summary>
            public Node<TNode, TNodeValue> Parent
            {
                get { return parent; }
            }

            /// <summary>
            /// Префикс 
            /// </summary>
            public Node<TNode, TNodeValue> Fail
            {
                get;
                set;
            }

            /// <summary>
            /// Дочерние вершины
            /// </summary>            
            public Node<TNode, TNodeValue> this[TNode c]
            {
                get { return children.ContainsKey(c) ? children[c] : null; }
                set { children[c] = value; }
            }

            /// <summary>
            /// Значения
            /// </summary>
            public List<TNodeValue> Values
            {
                get { return values; }
            }

            public IEnumerator<Node<TNode, TNodeValue>> GetEnumerator()
            {
                return children.Values.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            public override string ToString()
            {
                return Word.ToString();
            }
        }
    }
    public class Programm
    {
        public static void Main()
        {
            var trie = new Trie();
            string text = "match the collabory in the fall of man's end album almost";
            trie.Add("match");
            trie.Add("man");
            trie.Add("fa");
            trie.Add("a");
            trie.Build();
            string[] mathes = trie.Find(text).ToArray();
            foreach (var e in mathes)
                Console.WriteLine(e);
        }
    }
}

