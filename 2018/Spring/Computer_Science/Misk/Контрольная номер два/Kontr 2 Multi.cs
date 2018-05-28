using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.IO;

namespace Kontr2_1_exersize
{
    // Вспомогательный класс соответсвующий джэйсон представлению
    class OnceFile
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public Uri url { get; set; }
        public Uri thumbnailUrl { get; set; }
    }
    class Control_Work
    {
        public void DowloadAndJsoning(string url)
        {
            WebClient client = new WebClient();
            // файл проекта бин дебаг там папка с урл ссылкой там будут все файлы
            string directory = new Uri(url).Host;
            Directory.CreateDirectory(directory);
            // скачивание джэйсон представления в формате строки
            var e = client.DownloadString(new Uri(url));
            // преобразование джэйсона в обьекты вспом класса
            OnceFile[] inform = JsonConvert.DeserializeObject<OnceFile[]>(e);
            foreach (var inf in inform)
            {
                // скачивание файликов по ссылкам
              client.DownloadFile(inf.thumbnailUrl, Path.Combine(directory,String.Format("Album: {0} Song: {1}", inf.albumId, inf.id)));
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Control_Work();
            test.DowloadAndJsoning("https://jsonplaceholder.typicode.com/photos");
        }
    }
}
