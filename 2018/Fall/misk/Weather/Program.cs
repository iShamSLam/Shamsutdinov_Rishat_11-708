﻿using System;
using System.Net;
using System.Text;
namespace Weather
{
    class Program
    {

        static void Main(string[] args)
        {
            string city = Convert.ToString(Console.ReadLine());

            Wether(city);
        }

        public static void Wether(string city)
        {
            var url = "https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather." +
                "forecast%20where%20woeid%20in%20(select%20woeid%20from%20geo.places(1)%20where%20text" +
                "%3D%22" + city +
                "%22)&format=xml&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys";

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            var res = wc.DownloadString(url);
            StringBuilder q = new StringBuilder();

            string[] data = res.Split('<');
            string a = data[45];
            data = a.Split('=');
            a = data[4];
            data = a.Split('"');
            a = data[1];
            data = null;
            var b = Convert.ToInt16(a);
            var c = ((b - 32) * 5) / 9;
            Console.WriteLine("Темперетура в " + city + " : " + c);

        }
    }
}
