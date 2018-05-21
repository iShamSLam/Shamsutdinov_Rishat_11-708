using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AC_Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string text = "world in a flame, my great comrad";
            Aho_Corasick.Trie trie = new Aho_Corasick.Trie();
            trie.Add("a");
            trie.Add("fla");
            trie.Add("flame");
            trie.Build();
            string[] mathes = trie.Find(text).ToArray();
            Assert.AreEqual(6, mathes.Length);
            Assert.AreEqual("a", mathes[0]);
            Assert.AreEqual("fla", mathes[1]);
            Assert.AreEqual("a", mathes[2]);
            Assert.AreEqual("flame", mathes[3]);
            
        }
        [TestMethod]
        public void LineNumbers()
        {
            string text = "world, i hello you!";
            string[] words = new[] { "hello", "world" };

            Aho_Corasick.Trie<int> trie = new Aho_Corasick.Trie<int>();
            for (int i = 0; i < words.Length; i++)
                trie.Add(words[i], i);
            trie.Build();

            int[] lines = trie.Find(text).ToArray();

            Assert.AreEqual(2, lines.Length);
            Assert.AreEqual(1, lines[0]);
            Assert.AreEqual(0, lines[1]);
        }
        [TestMethod]
        public void TestMethod2()
        {
            string text = "welcome to the our great society my comrad";

            Aho_Corasick.Trie trie = new Aho_Corasick.Trie();
            trie.Add("to");
            trie.Add("comrad");
            trie.Build();

            Assert.IsTrue(trie.Find(text).Any());
        }
        [TestMethod]
        public void TestMethod3()
        {
            string[] text = "one two three four".Split(' ');

        Aho_Corasick.Trie<string, bool> trie = new Aho_Corasick.Trie<string, bool>();
        trie.Add(new[] { "three", "four" }, true);
            trie.Build();

            Assert.IsTrue(trie.Find(text).Any());
        }
    }
}
