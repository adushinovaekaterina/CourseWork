using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    class Particle
    {
        public int Radius; // радуис частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве
        
        public float Direction; // направление движения, если 0 градусов, то двигается вправо, 90 градусов - вверх
        public float Speed; // скорость перемещения
                          
        public static Random rand = new Random(); // генератор случайных чисел
                                                  
        // конструктор по умолчанию будет создавать кастомную частицу
        public Particle()
        {
            // не трогаем координаты X, Y, чтобы все частицы возникали из одного места
            Direction = rand.Next(360);
            Speed = 1 + rand.Next(10);
            Radius = 2 + rand.Next(10);
        }
    }
}
