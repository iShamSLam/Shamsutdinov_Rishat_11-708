using Semestrovka.Core;
using Semestrovka.Site;
using System;
using System.IO;
using System.Windows.Forms;
using Semestrovka.Objects;

namespace Semestrovka
{    
    public partial class Forms : Form
    {
        ParserWorker<string[]> parser;
       public const string path = @"C:\Users\User\Desktop\NewData.txt";
        Car car = new Car();
        public Forms()
        {
            InitializeComponent();           
            parser = new ParserWorker<string[]>(
                    new SiteParser(),
                    new SiteSettings("https://www.honda.co.ru/cars", "cr-v_2017")
                );

            parser.OnComplete += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            String temp;
                using (StreamWriter sw = new StreamWriter(path, false))
                {
                    foreach (var e in arg2)
                    {
                        if (e.Length > 1)
                            sw.WriteLine(e);
                    }
                }
            using (StreamReader sr = new StreamReader(path))
            {
                temp = sr.ReadToEnd();
            }
            car.PrepareCar();
            var temp2 = temp.Split('\n', '\r'); 
                listBox1.Items.AddRange(temp2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("All works done!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            parser.Start();            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void cARToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void hONDACRVToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            parser = new ParserWorker<string[]>(
                    new SiteParser(),
                    new SiteSettings("https://www.honda.co.ru/cars", "cr-v_2017")
                );

            parser.OnComplete += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void hYNDAISOLARISToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parser = new ParserWorker<string[]>(
                   new SiteParser(),
                   new SiteSettings("https://www.mitsubishi-motors.ru", "auto/pajero-iv/price/#tech")
               );

            parser.OnComplete += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }
    }
}