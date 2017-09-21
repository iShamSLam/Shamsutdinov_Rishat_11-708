using System;
using System.Diagnostics;
using System.Drawing;

namespace RefactorMe
{
    // ## Прочитайте! ##
    //
    // Ваша задача привести код в этом файле в порядок. 
    // Для начала запустите эту программу.
    // Переименуйте всё, что называется неправильно. Это можно делать комбинацией клавиш Ctrl+R, Ctrl+R (дважды нажать Ctrl+R).
    // Повторяющиеся части кода вынесите во вспомогательные методы. Это можно сделать выделив несколько строк кода и нажав Ctrl+R, Ctrl+M
    // Избавьтесь от всех зашитых в коде числовых констант — положите их в переменные с понятными именами.
    // 
    // После наведения порядка проверьте, что ваш код стал лучше. 
    // На сколько проще после ваших переделок стало изменить размер фигуры? Повернуть её на некоторый угол? 
    // Научиться рисовать невозможный треугольник, вместо квадрата?

       
    class Risovatel
    {
        static Bitmap image = new Bitmap(800, 600);
        static float x, y;

        static Graphics graphics;
       
       
           


        public static void Initialize()
        {
            image = new Bitmap(800, 600);
            graphics = Graphics.FromImage(image);
        }

        public static void SetPos(float x0, float y0)
        {
            x = x0;
            y = y0;
        }
        public static void Drawly1(float d, float s) // параметры для СетПрос внутри метода 
        {
            float dv = d;
            float sv = s;
            Risovatel.SetPos(dv, sv);
            Risovatel.Go(100, 0);
            Risovatel.Go(10 * Math.Sqrt(2), Math.PI / 4);
            Risovatel.Go(100, Math.PI);
            Risovatel.Go(100 - (double)10, Math.PI / 2);
        }
        public static void Drawly2(float d1, float s1)
        {
            float d1v = d1;
            float s1v = s1;
            Risovatel.SetPos(d1, s1);
            Risovatel.Go(100, Math.PI / 2);
            Risovatel.Go(10 * Math.Sqrt(2), Math.PI / 2 + Math.PI / 4);
            Risovatel.Go(100, Math.PI / 2 + Math.PI);
            Risovatel.Go(100 - (double)10, Math.PI / 2 + Math.PI / 2);
        }

        public static void Drawly3(float d2, float s2)
        {
            float d2v = d2;
            float s2v = s2;
            Risovatel.SetPos(d2, s2);
            Risovatel.Go(100, Math.PI);
            Risovatel.Go(10 * Math.Sqrt(2), Math.PI + Math.PI / 4);
            Risovatel.Go(100, Math.PI + Math.PI);
            Risovatel.Go(100 - (double)10, Math.PI + Math.PI / 2);
        }

            public static void Drawly4(float d3 , float s3)
            {
            float d3v = d3;
            float s3v = s3;
                Risovatel.SetPos(d3, s3);
                Risovatel.Go(100, -Math.PI / 2);
                Risovatel.Go(10 * Math.Sqrt(2), -Math.PI / 2 + Math.PI / 4);
                Risovatel.Go(100, -Math.PI / 2 + Math.PI);
                Risovatel.Go(100 - (double)10, -Math.PI / 2 + Math.PI / 2);

            }
       

    public static void Go(double l, double angle)
        {
            //Делает шаг длиной L в направлении angle и рисует пройденную траекторию
            var x1 = (float)(x + l * Math.Cos(angle));
            var y1 = (float)(y + l * Math.Sin(angle));
            graphics.DrawLine(Pens.Red, x, y, x1, y1);
            x = x1;
            y = y1;
        }

        public static void ShowResult()
        {
            image.Save("result.bmp");
            Process.Start("result.bmp");
        }
        
    }
    // ***************************************************************************************************
   // Я так и не нашел каких то общих черт в переменных указанных в скобках метода Го внутри метода Драули
   // *****************************************************************************************************

    public class StrangeThing
    {
        private static float d;

        public static void Main()
        {   
            Risovatel.Initialize();


            //Рисуем четыре одинаковые части невозможного квадрата.
            // Часть первая:
            Risovatel.Drawly1( 10, 0);
            // Часть вторая:
            Risovatel.Drawly2(120, 10);
            // Часть третья:
            Risovatel.Drawly3(110, 120);
            // Часть четвертая:
            Risovatel.Drawly4(0, 110);
            Risovatel.ShowResult();
        }
    }
} 