using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KONTR
{
    class Program
    {
        /*1. Даны последовательности B, D и E, включающие следующие поля:
        B: <Артикул товара> <Страна-производитель> <Категория>
        D: <Название магазина> <Артикул товара> <Цена (в рублях)> 
        E: <Название магазина> <Код потребителя> <Артикул товара>
        Свойства последовательностей описаны в преамбуле. 
        Для каждой страны-производителя определить количество приобретенных товаров из данной страны и суммарную стоимость приобретенных товаров
        (вначале выводится название страны, затем количество товаров, затем суммарная стоимость). 
        Если сведения о проданных товарах для некоторой страны-производителя отсутствуют, то информация об этой стране не выводится. 
        Сведения о каждой стране выводить на новой строке и упорядочивать по названиям стран в алфавитном порядке.
         */
         class B
        {
           public string Article { get; set; }
            public string WhereMade { get; set; }
            public string Category { get; set; }
        }
        class D
        {
            public string Shop { get; set; }
            public string Article { get; set; }
            public long Price { get; set; }
        }
        class E
        {
           public string Shop { get; set; }
           public int ConsCode { get; set; }
           public string Article { get; set; }
        }

        static void Main(string[] args)
        {
            B one = new B { Article = "maslo", WhereMade = "belorus", Category = "milkthings" };
            B one1 = new B { Article = "xleb", WhereMade = "russia", Category = "muchnoe" };
            B one2 = new B { Article = "gleb", WhereMade = "ukraine", Category = "meat" };
            List<B> b = new List<B>(); b.Add(one); b.Add(one1); b.Add(one2);
            D one3 = new D { Shop = "back", Article = "maslo", Price = 32 };
            D one4 = new D { Shop = "white", Article = "gleb", Price = 32000 };
            E one5 = new E { Shop = "white", Article = "gleb", ConsCode = (new Random().Next(1, 235))};
            E one6 = new E { Shop = "white", Article = "gleb", ConsCode = (new Random().Next(1, 235)) };
            E one7 = new E { Shop = "white", Article = "gleb", ConsCode = (new Random().Next(1, 235)) };
            E one8 = new E { Shop = "white", Article = "gleb", ConsCode = (new Random().Next(1, 235)) };
            E one9 = new E { Shop = "back", Article = "maslo", ConsCode = (new Random().Next(1, 235)) };
            List<D> d = new List<D>(); d.Add(one3); d.Add(one4);
            List<E> e = new List<E>(); e.Add(one5); e.Add(one6); e.Add(one7); e.Add(one8); e.Add(one9);
            var end = e.SelectMany(en => d.Where(em => em.Article == en.Article).Select(em => em.Article)).GroupBy(ee=>ee);
            // кол-во товаров считал
            var ben1 = end.ElementAt(0).Count() * (d.Where(rean => rean.Article == end.ElementAt(0).ElementAt(0)).Take(1).ElementAt(0).Price);
            foreach (var f in end.ElementAt(0))
                Console.WriteLine(f);
        }
    }
}
