using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace Kontr2_Ex_3
{
    /// <summary>
    /// Класс для того чтобы преобразовать json формат в него
    /// </summary>
    class Post
    {
        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
    class Control_Work
    {
        public void DowloadAndJsoning(string url)
        {
            WebClient client = new WebClient();
            // папка будет в bin/debug и там будет ссылка на сайт с которого скачивались данные 
            string directory = new Uri(url).Host;
            Directory.CreateDirectory(directory);
            // скачивание джэйсона в формате строки
            var e = client.DownloadString(new Uri(url));
            // преобразование джэйсон строк в обьекты класса
            Post[] posts = JsonConvert.DeserializeObject<Post[]>(e);
            var res = posts.Where(post => post.id % 2 == 0);
            foreach (var cl in res)
            {
                // промежуточный результат
                 int semiresult=0;
                var meas = cl.body.Split(' ');
                foreach(var word in meas)
                {
                    semiresult += word.Length;
                }
                Console.WriteLine("Длина комментария {0} равна : {1} букв", cl.id, semiresult);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Control_Work();
            test.DowloadAndJsoning("https://jsonplaceholder.typicode.com/comments?postId=1");
        }
    }
}
