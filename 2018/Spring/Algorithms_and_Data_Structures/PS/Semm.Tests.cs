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
            Example.index = temp.Index;

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
            test.Add("aberdin", test.index);
            test.Add("adler", test.index);
            test.Add("boungnuob", test.index);
            test.Add("dance", test.index);
            test.Add("dumb", test.index);
            test.Add("enjoy", test.index);
            test.Add("flag", test.index);
            test.Add("higig", test.index);
            test.Add("hower", test.index);
            test.Add("open", test.index);
            test.Add("Uzi", test.index);
            test.Add("viv", test.index);
            test.Add("wonk", test.index);

            for (int i = 0; i < test.index; i++)
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
            test.Add("aberdin", test.index);
            test.Add("adler", test.index);
            test.Add("bank", test.index);
            test.Add("boungnuob", test.index);
            test.Add("byzina", test.index);
            test.Add("dance", test.index);
            ExampleFill();
            Example.PasteToCollection("bank");
            Example.PasteToCollection("byzina");
            for (int i = 0; i < test.index; i++)
            {
                Assert.AreEqual(test.FindByIndex(test.First, i), Example.FindByIndex(Example.First, i));
            }
        }
        [TestMethod]
        public void RemoveTest()
        {
            ExampleFill();
            var test = new WordCollection();
            test.Add("aberdin", test.index);
            test.Add("boungnuob", test.index);
            test.Add("dumb", test.index);
            test.Add("enjoy", test.index);
            test.Add("flag", test.index);
            test.Add("higig", test.index);
            test.Add("hower", test.index);
            test.Add("Uzi", test.index);
            test.Add("viv", test.index);
            test.Add("wonk", test.index);
            Example.RemoveFromCollection("adler");
            Example.RemoveFromCollection("dance");
            Example.RemoveFromCollection("open");
            for (int i = 0; i < test.index; i++)
            {
                Assert.AreEqual(test.FindByIndex(test.First, i), Example.FindByIndex(Example.First, i));
            }
        }

        [TestMethod]
        public void ConstantTest()
        {
            var test = new WordCollection();
            test.Add("dumb", test.index);
            test.Add("flag", test.index);
            test.Add("open", test.index);
            test.Add("wonk", test.index);
            ExampleFill();
            var test2 = Example.NewCollectionWithConstValueLenght(Example, 4);
            for (int i = 0; i < test.index; i++)
            {
                Assert.AreEqual(test.FindByIndex(test.First, i), test2.FindByIndex(test2.First, i));
            }
        }
        [TestMethod]
        public void SplittingTest()
        {
            var test = new WordCollection();
            var test2 = new WordCollection();
            test2.Add("aberdin", test.index);
            test2.Add("adler", test.index);
            test.Add("boungnuob", test.index);
            test.Add("dance", test.index);
            test.Add("dumb", test.index);
            test2.Add("enjoy", test.index);
            test.Add("flag", test.index);
            test.Add("higig", test.index);
            test.Add("hower", test.index);
            test2.Add("open", test.index);
            test2.Add("Uzi", test.index);
            test.Add("viv", test.index);
            test.Add("wonk", test.index);
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
            test2.Add("aberdin", test.index);
            test2.Add("adler", test.index);
            test.Add("boungnuob", test.index);
            test.Add("dance", test.index);
            test.Add("dumb", test.index);
            test2.Add("enjoy", test.index);
            test.Add("flag", test.index);
            test.Add("higig", test.index);
            test.Add("hower", test.index);
            test2.Add("open", test.index);
            test2.Add("Uzi", test.index);
            test.Add("viv", test.index);
            test.Add("wonk", test.index);
            ExampleFill();
            var test3 = Example.CombineCollection(test, test2);
            for (int i = 0; i < test3.index; i++)
            {
                Assert.AreEqual(test3.FindByIndex(test3.First, i), Example.FindByIndex(Example.First, i));
            }
            var senua = new WordCollection();
            senua.Add("bank",senua.index);
            senua.Add("credo",senua.index);
            senua.Add("flow",senua.index);
            senua.Add("van",senua.index);
            senua.Add("xan",senua.index);
            var vertigo = new WordCollection();
            vertigo.Add("bump",vertigo.index);
            vertigo.Add("wanish",vertigo.index);
            vertigo.Add("yrui",vertigo.index);
            var senuvar = senua.CombineCollection(senua,vertigo);
            var fin = new WordCollection();
            fin.Add("bank", fin.index);
            fin.Add("bump", fin.index);
            fin.Add("credo", fin.index);
            fin.Add("flow", fin.index);
            fin.Add("van", fin.index);
            fin.Add("wanish", fin.index);
            fin.Add("xan", fin.index);
            fin.Add("yrui", fin.index);
            for (int i = 0; i < senuvar.index; i++)
            {
                Assert.AreEqual(fin.FindByIndex(fin.First, i), senuvar.FindByIndex(senuvar.First, i));
            }
        }
        [TestMethod]
        public void RemoveEqualsTest()
        {
            var test = new WordCollection();
            test.Add("aberdin", test.index);
            test.Add("adler", test.index);
            test.Add("dance", test.index);
            test.Add("dumb", test.index);
            test.Add("enjoy", test.index);
            test.Add("flag", test.index);
            test.Add("higig", test.index);
            test.Add("hower", test.index);
            test.Add("open", test.index);
            test.Add("Uzi", test.index);            
            test.Add("wonk", test.index);
            var test2 = new WordCollection();
            test2.Add("aaaaaaa", test2.index);
            test2.Add("aberdin", test2.index);
            test2.Add("adler", test2.index);
            test2.Add("boungnuob", test2.index);
            test2.Add("dance", test2.index);
            test2.Add("dumb", test2.index);
            test2.Add("enjoy", test2.index);
            test2.Add("flag", test2.index);
            test2.Add("higig", test2.index);
            test2.Add("hower", test2.index);
            test2.Add("open", test2.index);
            test2.Add("Uzi", test2.index);
            test2.Add("viv", test2.index);
            test2.Add("wonk", test2.index);
            test2.RemoveEqualWords(test2);

            for (int i = 0; i < test2.index; i++)
            {
                Assert.AreEqual(test2.FindByIndex(test2.First, i), test.FindByIndex(test.First, i));
            }
        }
    }
}
