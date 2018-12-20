using System.Collections.Generic;
using System.IO;

namespace Semestrovka.Objects
{
    class Car
    {
        const string CarProperties = @"Двигатель, Тип трансмиссии, Комфорт , Мощность, Крутящий момент, топлива,
            Расход, Разгон, Привод, Обьем багажника, Клиренс, Длина, Ширина, Высота, Обьём бака, Масса";
        public void PrepareCar()
        {
            var properties = CarProperties.Split(',');
            string crazy;
            using (StreamReader sr = new StreamReader(Forms.path))
            {
                crazy = sr.ReadToEnd();
            }
            var shoter = crazy.Split('\n', 'r');
            List<string> temper = new List<string>();
            for(int i = 0 ; i < shoter.Length; i++)
            {
                foreach(var property in properties)
                {
                    if(shoter[i].Contains(property))
                    {
                        temper.Add(shoter[i + 1]);
                        i++;
                    }
                }
            }

            if (temper.Count == 0)
                temper.Clear();

        }
    }
}
