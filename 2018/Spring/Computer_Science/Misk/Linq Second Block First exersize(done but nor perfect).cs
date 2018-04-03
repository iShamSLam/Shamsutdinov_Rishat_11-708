using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_Exersise_Second_Block_First_Exersise
{
    /*Для каждого потребителя, указанно-
    го в A, определить количество магазинов, в которых ему пре-
    доставляется скидка (вначале выводится количество магази-
    нов, затем код потребителя, затем его улица проживания). 
    Если у некоторого потребителя нет скидки ни в одном мага-
    зине, то для него выводится количество магазинов, равное 0.
    Сведения о каждом потребителе выводить на новой строке и
    упорядочивать по возрастанию количества магазинов, а при
    равном количестве — по возрастанию кодов потребителей
    */

    public class Comparator : WriterFormer
    {
        public List<Buyer> Compare(IEnumerable<Buyer> buyers, IEnumerable<DiscountInformation> informs)
        {
            foreach (var man in buyers)
            {
                foreach (var info in informs)
                {
                    if (man.ConsumerCode == info.ConsumerCode)
                        man.CountOfShopsWithDiscount++;
                }
            }
            return buyers
            .OrderByDescending(buyer => buyer.CountOfShopsWithDiscount)
            .ThenBy(buyer => buyer.ConsumerCode)
            .ToList();
        }
    }

    public class WriterFormer
    {
        public void Writer(List<Buyer> buyers)
        {
            foreach (var consumer in buyers)
            {
                Console.WriteLine(String.Format(@"
                CountOfShopsWithDiscount - {0} 
                ConsumerCode - {1} 
                StreetOfResidence - {2} ",
                consumer.CountOfShopsWithDiscount,
                consumer.ConsumerCode,
                consumer.StreetOfResidence
                ));
            }
            Console.WriteLine();
        }
    }

    public class Buyer
    {
        public long ConsumerCode { get; set; }
        public string StreetOfResidence { get; set; }
        public DateTime Birthday { get; set; }
        public int CountOfShopsWithDiscount { get; set; }
    }

    public class DiscountInformation
    {
        public double Discount { get; set; }
        public long ConsumerCode { get; set; }
        public string NameOfShop { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var one = new Buyer { ConsumerCode = 1356, StreetOfResidence = "Downtown", Birthday = Convert.ToDateTime("23.01.1996") };
            var two = new Buyer { ConsumerCode = 1245, StreetOfResidence = "Wickley", Birthday = Convert.ToDateTime("22.11.1967") };
            var three = new Buyer { ConsumerCode = 1124, StreetOfResidence = "Cramsy", Birthday = Convert.ToDateTime("13.06.1976") };
            var ber = new DiscountInformation { Discount = 0.12, ConsumerCode = 1356, NameOfShop = "Lulali" };
            var ike = new DiscountInformation { Discount = 0.32, ConsumerCode = 1356, NameOfShop = "Manue" };
            var ech = new DiscountInformation { Discount = 0.55, ConsumerCode = 1124, NameOfShop = "Kalimaru" };
            var durt = new DiscountInformation { Discount = 0.36, ConsumerCode = 1245, NameOfShop = "Guenama" };
            List<Buyer> buyer = new List<Buyer>();
            List<DiscountInformation> inform = new List<DiscountInformation>();
            buyer.Add(one); buyer.Add(two); buyer.Add(three);
            inform.Add(ber); inform.Add(ike); inform.Add(ech); inform.Add(durt);
            var result = new Comparator();
            result.Writer(result.Compare(buyer, inform));
        }
    }
}
