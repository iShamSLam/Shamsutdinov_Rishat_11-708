using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Semmestrovka_2_variant;

namespace Testing
{
    [TestClass]
    public class WordCollectionTest
    {
        public WordCollection Example = new WordCollection();
        public void ExampleFill()
        {
            Example.First = new WordCollection.ListItem { Value = "aberdin", Index = 0 };
            var temp = Example.First;
            temp.Next = new WordCollection.ListItem { Value = "adler", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "boungnuob", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "dance", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "dumb", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "enjoy", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "flag", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "higig", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "hower", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "open", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "Uzi", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "viv", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "wonk", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next;
            temp.Next = new WordCollection.ListItem { Value = "yanki", Index = temp.Index + 1, Previous = temp, };
            temp = temp.Next; Example.Last = temp;
            Example.count = temp.Index;

        }

        [TestMethod]
        public void FindTest()
        {
            ExampleFill();
            Assert.AreEqual(Example.FindByIndex(Example.First, 1), "adler");
            Assert.AreEqual(Example.FindByIndex(Example.First, 4), "dumb");
            Assert.AreEqual(Example.FindByIndex(Example.First, 6), "flag");
            Assert.AreEqual(Example.FindByIndex(Example.First, 7), "higig");
            Assert.AreEqual(Example.FindByIndex(Example.First, 9), "open");
            Assert.AreEqual(Example.FindByIndex(Example.First, 12), "wonk");
            Assert.AreEqual(Example.FindByIndex(Example.First, Example.Last.Index), "yanki");
        }
        [TestMethod]
        public void AddTest()
        {
            ExampleFill();
            var test = new WordCollection();
            test.Add("aberdin", test.count);
            test.Add("adler", test.count);
            test.Add("boungnuob", test.count);
            test.Add("dance", test.count);
            test.Add("dumb", test.count);
            test.Add("enjoy", test.count);
            test.Add("flag", test.count);
            test.Add("higig", test.count);
            test.Add("hower", test.count);
            test.Add("open", test.count);
            test.Add("Uzi", test.count);
            test.Add("viv", test.count);
            test.Add("wonk", test.count);

            for (int i = 0; i < test.count; i++)
            {
                Assert.AreEqual(test.FindByIndex(test.First, i), Example.FindByIndex(Example.First, i));
            }
        }

        [TestMethod]
        public void IsEmptyTest()
        {
            Assert.AreEqual(Example.IsEmpty, true);
            ExampleFill();
            Assert.AreEqual(Example.IsEmpty, false);
        }

        [TestMethod]
        public void PasteTest()
        {
            var test = new WordCollection();
            test.Add("aberdin", test.count);
            test.Add("adler", test.count);
            test.Add("bank", test.count);
            test.Add("boungnuob", test.count);
            test.Add("byzina", test.count);
            test.Add("dance", test.count);
            ExampleFill();
            Example.PasteToCollection("bank");
            Example.PasteToCollection("byzina");
            for (int i = 0; i < test.count; i++)
            {
                Assert.AreEqual(test.FindByIndex(test.First, i), Example.FindByIndex(Example.First, i));
            }
        }
        [TestMethod]
        public void RemoveTest()
        {
            ExampleFill();
            var test = new WordCollection();
            test.Add("aberdin", test.count);
            test.Add("boungnuob", test.count);
            test.Add("dumb", test.count);
            test.Add("enjoy", test.count);
            test.Add("flag", test.count);
            test.Add("higig", test.count);
            test.Add("hower", test.count);
            test.Add("Uzi", test.count);
            test.Add("viv", test.count);
            test.Add("wonk", test.count);
            Example.RemoveFromCollection("adler");
            Example.RemoveFromCollection("dance");
            Example.RemoveFromCollection("open");
            for (int i = 0; i < test.count; i++)
            {
                Assert.AreEqual(test.FindByIndex(test.First, i), Example.FindByIndex(Example.First, i));
            }
        }

        [TestMethod]
        public void ConstantTest()
        {
            var test = new WordCollection();
            test.Add("dumb", test.count);
            test.Add("flag", test.count);
            test.Add("open", test.count);
            test.Add("wonk", test.count);
            ExampleFill();
            var test2 = Example.NewCollectionWithConstValueLenght(Example, 4);
            for (int i = 0; i < test.count; i++)
            {
                Assert.AreEqual(test.FindByIndex(test.First, i), test2.FindByIndex(test2.First, i));
            }
        }
        [TestMethod]
        public void SplittingTest()
        {
            var test = new WordCollection();
            var test2 = new WordCollection();
            test2.Add("aberdin", test.count);
            test2.Add("adler", test.count);
            test.Add("boungnuob", test.count);
            test.Add("dance", test.count);
            test.Add("dumb", test.count);
            test2.Add("enjoy", test.count);
            test.Add("flag", test.count);
            test.Add("higig", test.count);
            test.Add("hower", test.count);
            test2.Add("open", test.count);
            test2.Add("Uzi", test.count);
            test.Add("viv", test.count);
            test.Add("wonk", test.count);
            ExampleFill();
            var vowels = new WordCollection();
            var consonant = new WordCollection();
            Example.SplittingListIntoTwo(Example, out vowels, out consonant);
        }

        [TestMethod]
        public void CombineTest()
        {
            var test = new WordCollection();
            var test2 = new WordCollection();
            test2.Add("aberdin", test.count);
            test2.Add("adler", test.count);
            test.Add("boungnuob", test.count);
            test.Add("dance", test.count);
            test.Add("dumb", test.count);
            test2.Add("enjoy", test.count);
            test.Add("flag", test.count);
            test.Add("higig", test.count);
            test.Add("hower", test.count);
            test2.Add("open", test.count);
            test2.Add("Uzi", test.count);
            test.Add("viv", test.count);
            test.Add("wonk", test.count);
            ExampleFill();
            var test3 = Example.CombineCollection(test, test2);
            for (int i = 0; i < test3.count; i++)
            {
                Assert.AreEqual(test3.FindByIndex(test3.First, i), Example.FindByIndex(Example.First, i));
            }
            var senua = new WordCollection();
            senua.Add("bank",senua.count);
            senua.Add("credo",senua.count);
            senua.Add("flow",senua.count);
            senua.Add("van",senua.count);
            senua.Add("xan",senua.count);
            var vertigo = new WordCollection();
            vertigo.Add("bump",vertigo.count);
            vertigo.Add("wanish",vertigo.count);
            vertigo.Add("yrui",vertigo.count);
            var senuvar = senua.CombineCollection(senua,vertigo);
            var fin = new WordCollection();
            fin.Add("bank", fin.count);
            fin.Add("bump", fin.count);
            fin.Add("credo", fin.count);
            fin.Add("flow", fin.count);
            fin.Add("van", fin.count);
            fin.Add("wanish", fin.count);
            fin.Add("xan", fin.count);
            fin.Add("yrui", fin.count);
            for (int i = 0; i < senuvar.count; i++)
            {
                Assert.AreEqual(fin.FindByIndex(fin.First, i), senuvar.FindByIndex(senuvar.First, i));
            }
        }
        [TestMethod]
        public void RemoveEqualsTest()
        {
            var test = new WordCollection();
            test.Add("aberdin", test.count);
            test.Add("adler", test.count);
            test.Add("dance", test.count);
            test.Add("dumb", test.count);
            test.Add("enjoy", test.count);
            test.Add("flag", test.count);
            test.Add("higig", test.count);
            test.Add("hower", test.count);
            test.Add("open", test.count);
            test.Add("Uzi", test.count);            
            test.Add("wonk", test.count);
            var test2 = new WordCollection();
            test2.Add("aaaaaaa", test2.count);
            test2.Add("aberdin", test2.count);
            test2.Add("adler", test2.count);
            test2.Add("boungnuob", test2.count);
            test2.Add("dance", test2.count);
            test2.Add("dumb", test2.count);
            test2.Add("enjoy", test2.count);
            test2.Add("flag", test2.count);
            test2.Add("higig", test2.count);
            test2.Add("hower", test2.count);
            test2.Add("open", test2.count);
            test2.Add("Uzi", test2.count);
            test2.Add("viv", test2.count);
            test2.Add("wonk", test2.count);
            test2.RemoveEqualWords(test2);

            for (int i = 0; i < test2.count; i++)
            {
                Assert.AreEqual(test2.FindByIndex(test2.First, i), test.FindByIndex(test.First, i));
            }
        }
    }
}
