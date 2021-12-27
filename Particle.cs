﻿using System;
using System.Drawing; // чтобы исплоьзовать Graphics
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    public class Particle
    {
        public int Radius; // радуис частицы
        public float X; // X координата положения частицы в пространстве
        public float Y; // Y координата положения частицы в пространстве
        
        public float Direction; // направление движения, если 0 градусов, то двигается вправо, 90 градусов - вверх
        public float Speed; // скорость перемещения
        public float Life; // запас здоровья частицы

        public static Random rand = new Random(); // генератор случайных чисел
                                                  
        // конструктор по умолчанию будет создавать кастомную частицу
        public Particle()
        {
            // не трогаем координаты X, Y, чтобы все частицы возникали из одного места
            Direction = rand.Next(360); // направление движения от 0 градусов до 360 градусов
            Speed = 1 + rand.Next(10); // скорость от 1 до 11
            Radius = 2 + rand.Next(10); // радиус от 2 до 12
            Life = 20 + rand.Next(100); // исходный запас здоровья от 20 до 120
        }

        public void Draw(Graphics g)
        {            
            float k = Math.Min(1f, Life / 100); // рассчитываем коэффициент прозрачности по шкале от 0 до 1.0

            // рассчитываем значение альфа канала в шкале от 0 до 255,
            // по аналогии с RGB, он используется для задания прозрачности
            int alpha = (int)(k * 255);

            // создаем цвет из уже существующего, но привязываем к нему еще и значение альфа канала
            var color = Color.FromArgb(alpha, Color.Black);

            SolidBrush b = new SolidBrush(color); // создаем кисть для рисования

            // нарисуем залитый кружок радиусом Radius с центром в X, Y
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            
            b.Dispose(); // удаляем кисть из памяти
        }
    }
}
