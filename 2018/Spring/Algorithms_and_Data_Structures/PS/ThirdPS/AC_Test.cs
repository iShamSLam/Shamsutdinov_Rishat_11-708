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
        public void TestMethod2()
        {
            string text = "hello and welcome to this beautiful world!";

            Aho_Corasick.Trie trie = new Aho_Corasick.Trie();
            trie.Add("hello");
            trie.Add("world");
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
