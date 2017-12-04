using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem1
{
    class Program
    {   //  По коэффициентам квадратного уравнения ax^2+bx+c=0
        // найти количество действительных
        // корней уравнения и сами корни.
        //Если корней бесконечно много, вывести -1.
        static void Main(string[] args)
        {
            int  a ,b ,c , discriminant;
            double x1, x2;
            double  radicalDiscriminant; // корень из Дискриминант 
            Console.WriteLine("Функция имеет вид ax*x + bx + c = 0 ");
            Console.WriteLine("Введите значение переменной  a ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine(" Введите значение переменной b ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine(" Введите значение переменной с ");
            c = int.Parse(Console.ReadLine());
            discriminant = b * b - 4 * a * c;
            radicalDiscriminant = Math.Sqrt(discriminant);
	    // ---check--- "Если корней бесконечно много, вывести -1." - Этот вариант не обрабатываете?
            if (discriminant < 0)
                Console.WriteLine("Нет корней");
            else if (discriminant == 0)
            {
                Console.WriteLine(" Всего один корень ");
                x1 = x2 = (-b / 2 * a);
                Console.WriteLine(" Корень уравнение равен   ", x1);
            }
            else
            {
                Console.WriteLine("Уравение имеет два корня");
                x1 = (-b + radicalDiscriminant / 2 * a);
                x2 = (-b - radicalDiscriminant / 2 * a);
                string x1string = Convert.ToString(x1);
                string x2string = Convert.ToString(x2);
                Console.WriteLine("Первый корень уравнения равен  " + x1string );                
                Console.WriteLine("Второй корень уравнения равен  " + x1string);            
            }
            Console.ReadKey();
        }
    }
}
