using System;

namespace Semmestrovka_2_variant
{
    class Programm
    {
        // Работу выполнил : Шамсутдинов Ришат 11-708
        public static void Main()
        {
            string t = null;
            var test = new WordCollection();
            test.CollectionFiller();
            Console.WriteLine("Вывод :");
            test.CollectionWrite();
            Console.WriteLine("Поиск по индексу :");
            Console.WriteLine(test.FindByIndex(test.First, 1));
            Console.WriteLine();
            test.PasteToCollection(null);
            Console.WriteLine("Провека вставки элемента :");
            test.CollectionWrite();
            Console.WriteLine();
            test.RemoveFromCollection(t);
            Console.WriteLine("Проверка удаления элемента :");
            test.CollectionWrite();
            Console.WriteLine("Провека на формирования коллекции со словами фиксированной длины :");
            test.NewCollectionWithConstValueLenght(test,0).CollectionWrite();
            Console.WriteLine();
            test.SplittingListIntoTwo(test, out WordCollection vowels, out WordCollection consonants);
            Console.WriteLine("Провека коллекции гласных :");
            vowels.CollectionWrite();
            Console.WriteLine("Провека коллекции согласных :");
            consonants.CollectionWrite();
            Console.WriteLine("Провека склеивания коллекций :");
            test.CombineCollection(vowels, consonants).CollectionWrite();
            Console.WriteLine();
            test.RemoveEqualWords(test);
            Console.WriteLine("Провека на удаление слов читающихся одинаково слева направо и справа налево");
            test.CollectionWrite();
        }
    }

    //******************************************************************************************************
    public class WordCollection
    {
        /// <summary>
        /// количество элементов в коллекции
        /// </summary>
        public int count = 0;

        /// <summary>
        /// Начало коллекции
        /// </summary>
        public ListItem First { get; set; }
        /// <summary>
        /// конец коллекции
        /// </summary>
        public ListItem Last { get; set; }
        /// <summary>
        ///  Обьект коллекции 
        /// </summary> 
        ListItem Сurrent { get; set; }
        public class ListItem
        {
            public string Value { get; set; }
            public int Index { get; set; }
            public ListItem Next { get; set; }
            public ListItem Previous { get; set; }
        }

        /// <summary>
        /// Обьединяет две коллекцию в одну сохраняя лексикографический порядок
        /// </summary>
        /// <param name="first"></param> первая коллекция для обьединения
        /// <param name="second"></param> вторая коллекция для обьединения
        /// <returns></returns>
        public WordCollection CombineCollection(WordCollection first, WordCollection second)
        {
            var buff1 = first.First; var buff2 = second.First;
            var result = new WordCollection();
            string filler = "yyyyyyyyyyyyyyyyyyy";
            var condition = (buff1 != null && buff2 != null);
            if (first.First == null)
                return second;
            if (second.First == null)
                return first;
            while (condition)
            {
                while (first.Last.Index < second.Last.Index)
                {
                    first.Add(filler, first.count);
                }
                while (first.Last.Index > second.Last.Index)
                {
                    second.Add(filler, second.count);
                }

                if (!(buff1 == null && buff2 == null))
                {
                    if (buff1 == null && buff2.Value == filler)
                        break;
                    else if (buff2 == null && buff1.Value == filler)
                        break;
                }
                if (buff1 == null && buff2 != null)
                {
                    if (buff2.Value == filler)
                        break;
                    result.Add(buff2.Value, result.count);
                    buff2 = buff2.Next;
                    break;
                }
                else if (buff2 == null && buff1 != null)
                {
                    result.Add(buff1.Value, result.count);
                    buff1 = buff1.Next;
                    break;
                }
                if (buff2 != null && buff2.Value == filler)
                    break;
                else if (buff1.Value == buff2.Value && buff2.Value == filler)
                    break;
                if (buff1.Value.CompareTo(buff2.Value) < 0 && condition)
                {
                    result.Add(buff1.Value, result.count);
                    buff1 = buff1.Next;
                    if (buff1 == null)
                        continue;
                }

                if (buff2.Value.CompareTo(buff1.Value) < 0 && condition)
                {
                    result.Add(buff2.Value, result.count);
                    buff2 = buff2.Next;
                    if (buff2 == null)
                        continue;
                }

            }
            if (result.Last.Value == filler)
            {
                result.RemoveFromCollection(filler);
            }
            return result;
        }

        /// <summary>
        /// Даётся отправная точка с которой начинается пробежка и индекс
        /// в соответсвии c которым возвращается обьект коллекции
        /// </summary>
        /// <param name="temp"></param>отправная точка
        /// <param name="index"></param> индекс начала поиска
        /// <returns></returns> 
        public string FindByIndex(ListItem temp, int index)
        {
            string result = null;
            while ((temp.Index <= index))
            {
                if (temp.Index == index)
                {
                    result = temp.Value;
                    break;
                }
                temp = temp.Next;

            }
            return result;
        }
        /// <summary>
        /// Проверка на то, содержится ли хотя бы 1 элемент
        /// </summary>
        public bool IsEmpty { get { return (First == Last) && (Last == null); } }

        /// <summary>
        ///  Добавление нового элемента в коллекцию и создание соответсвующего ему обьекта
        /// </summary>
        /// <param name="value"></param> значение
        /// <param name="index"></param> индекс последнего элемента
        public void Add(string value, int index)
        {
            if (value.Substring(value.Length - 1, 1) == " ")
                value = value.Substring(0, value.Length - 2);
            if (IsEmpty)
            {
                First = Last = new ListItem { Value = value, Index = index };
                Сurrent = First;
                this.count++;
            }
            else
            {
                var item = new ListItem
                {
                    Value = value,
                    Index = index,
                    Previous = Сurrent,
                };
                Сurrent.Next = item;
                Сurrent = item;
                Last = item;
                this.count++;
            }
        }

        /// <summary>
        /// Так называемое кодирование которое вы разрешили упростить до считывания с консоли
        /// </summary>
        public void CollectionFiller()
        {
            string word;
            Console.WriteLine(@"Начинается считывание слов, если хотите прекратить вбейте ""end""");
            do
            {
                word = Console.ReadLine();
                if (word != "end")
                {
                    Add(word, count);
                }
            }
            while (word != "end");
            Console.WriteLine();
        }

        /// <summary>
        /// Вывод коллекции на консоль
        /// </summary>
        public void CollectionWrite()
        {
            var temp = First;

            do
            {
                if (temp == null)
                {
                    Console.WriteLine("Нет результата");
                    break;
                }
                Console.WriteLine(temp.Value);
                temp = temp.Next;
            }
            while (temp != null);
            Console.WriteLine();
        }

        /// <summary>
        /// Вставка произвольной строки в коллекцию с сохранением порядка
        /// </summary>
        /// <param name="temp"></param>слово для вставки 
        public void PasteToCollection(string temp)
        {
            if (temp == null)
            {
                Console.WriteLine("Введите слово для вставки");
                temp = Console.ReadLine();
            }
            var buffer = First;
            if (temp == "")
                throw new Exception("You just don't write word, try again later");
            while (buffer != null)
            {
                if (Equals(temp, buffer.Value))
                {
                    Console.WriteLine("Такое слово уже присутсвует");
                    break;
                }
                if (buffer == Last)
                {
                    var item = new ListItem
                    {
                        Value = temp,
                        Index = buffer.Index + 1,
                        Previous = buffer,
                        Next = null,

                    };
                    buffer.Next = item;
                    Last = item;
                    count++;
                    break;
                }
                if ((temp.CompareTo(buffer.Value) > 0 && temp.CompareTo(buffer.Next.Value) < 0))
                {
                    var item = new ListItem
                    {
                        Value = temp,
                        Next = buffer.Next
                    };
                    if (buffer == First)
                    {
                        buffer.Next.Previous = item;
                        item.Previous = First;
                        First.Next = item;
                        item.Index = First.Index + 1;
                    }
                    else
                    {
                        item.Previous = buffer;
                        buffer.Next.Previous = item;
                        item.Index = buffer.Index + 1;
                    }
                    buffer.Next = item;
                    var buff = item.Next;
                    for (int i = item.Next.Index; i < count; i++)
                    {
                        buff.Index = i + 1;
                        if (buff.Next != null)
                            buff = buff.Next;
                    }
                    Last = buff;
                    break;
                }
                else
                    buffer = buffer.Next;
            }
        }


        /// <summary>
        /// Удаление выбранного слова из коллекции 
        /// </summary>
        public void RemoveFromCollection(string temp)
        {
            if (temp == null)
            {
                Console.WriteLine("Введите слово что хотите удалить");
                temp = Console.ReadLine();
            }
            if (temp == "")
                throw new Exception("You just don't write word, try again later");
            var buffer = First;
            while (buffer != null)
            {
                if (Equals(temp, buffer.Value))
                {
                    if (buffer == First)
                    {
                        buffer.Next.Previous = null;
                        First = buffer.Next;
                        buffer.Next.Index = buffer.Index;
                    }
                    else if (buffer == Last)
                    {
                        buffer.Previous.Next=null;
                        buffer.Previous = null;
                        buffer.Value = null;
                        count--;
                        break;
                    }
                    else
                    {
                        buffer.Previous.Next = buffer.Next;
                        buffer.Next.Previous = buffer.Previous;
                        buffer.Next.Index = buffer.Index;
                    }
                    var buff = First;
                    buffer = null;
                    count--;
                    for (int i = 0; i < count; i++)
                    {
                        buff.Index = i;
                        buff = buff.Next;
                    }
                    break;
                }
                else
                    buffer = buffer.Next;
                if (buffer == null)
                    Console.WriteLine("Такого слова нет в коллекции");
            }
        }

        /// <summary>
        /// Принимает длину в соответсвии с которой элементы с длиной равной принятой забиваются в новую коллекцию с фиксированной длиной эллементов
        /// </summary>
        /// <param name="test"></param> Изначальная коллекция из которой формируется новая коллекция
        public WordCollection NewCollectionWithConstValueLenght(WordCollection test, int lenght)
        {
           
            var buffer = test.First;
            var result = new WordCollection();
            if (lenght == 0)
            {
                Console.WriteLine("Введите нужную длину слов");
                lenght = int.Parse(Console.ReadLine());
            }
            for (int i = 0; i <= test.count; i++)
            {
                if (buffer.Value.Length == lenght)
                {
                    result.Add(buffer.Value,result.count);
                }
                if (buffer.Next != null)
                    buffer = buffer.Next;
                else
                    break;
            }
            if (result == null)
            {
                Console.WriteLine("Cлов такой длины нет в словаре");
            }
            return result;
        }

        /// <summary>
        /// Разбивает поданную коллекцию на коллекцию из слов с начинающихся гласной буквы и на коллекцию из слов с согласной 
        /// </summary>
        /// <param name="test"></param> изначальная коллекция
        /// <param name="vowels"></param> коллекция гласных
        /// <param name="consonant"></param> коллекция согласных
        public void SplittingListIntoTwo(WordCollection test, out WordCollection vowels, out WordCollection consonant)
        {
            vowels = new WordCollection();
            consonant = new WordCollection();
            string vowelAlph = "AaEeIiOoUuYyАаОоИиЕеЁёЭэЫыУуЮюЯя"; string consonantAlph = "BbCcDdFfGgHhJjKkLlMmNnPpQqRrSsTtVvWwZzБбВвГгДдЖжЗзЙйКкЛлМмНнПпРрСсТтФфХхЦцЧчШшЩщ";
            var buffer = test.First;
            for (int i = 0; i <= test.count; i++)
            {
                if (vowelAlph.Contains(buffer.Value.Substring(0, 1)))
                {
                    vowels.Add(buffer.Value, vowels.count);
                    if (buffer.Next != null)
                    {
                        buffer = buffer.Next;
                        continue;
                    }
                    else
                        break;
                }
                if (consonantAlph.Contains(buffer.Value.Substring(0, 1)))
                {
                    consonant.Add(buffer.Value, consonant.count);
                    if (buffer.Next != null)
                    {
                        buffer = buffer.Next;
                        continue;
                    }
                    else
                        break;
                }
            }
        }
        /// <summary>
        /// удаляет из коллекции слова которые читаются одинаково слева направо и справа налево
        /// </summary>
        /// <param name="temp"></param> редактируемая коллекция
        public void RemoveEqualWords(WordCollection temp)
        {
            var test = First;
            var word = test.Value;
            while (true)
            {
                if (Equals(word.Substring(0, 1), word.Substring(word.Length - 1, 1)))
                {
                    word = word.Substring(1, word.Length - 2);
                    if  (word.Length == 2 && word[0] == word[1] || word.Length == 1)
                    {
                        temp.RemoveFromCollection(test.Value);
                        if (test.Next == null)
                            break;
                        test = test.Next;
                        word = test.Value;
                    }
                }
                else
                {
                    if (test.Next == null)
                        break;
                    test = test.Next;
                    word = test.Value;
                }
            }
        }
    }
}

