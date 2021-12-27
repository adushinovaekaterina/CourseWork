﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    public abstract class IImpactPoint
    {
        // координаты точки
        public float X;
        public float Y;

        // абстрактный метод с помощью которого будем изменять состояние частиц,
        // например, притягивать
        public abstract void ImpactParticle(Particle particle);

        // базовый метод для отрисовки точки
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }

    // точка гравитации
    public class GravityPoint : IImpactPoint
    {
        public int Power = 100; // сила притяжения

        public override void ImpactParticle(Particle particle)
        {
            // считаем вектор притяжения к точке
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            // считаем квадрат расстояния между частицей и точкой r^2
            float r2 = (float)Math.Max(100, gX * gX + gY * gY); // ограничим r2, чтобы r2 был не меньше ста

            // пересчитываем вектор скорости с учетом притяжения к точке
            particle.SpeedX += gX * Power / r2;
            particle.SpeedY += gY * Power / r2;
        }

        // переопределенный метод для отрисовки точки
        public override void Render(Graphics g)
        {
            // рисуем окружность с диаметром, равным Power
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - Power / 2,
                   Y - Power / 2,
                   Power,
                   Power
               );
        }
    }

    // точка антигравитации (вместо притяжения будет отталкивать частицы)
    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100; // сила отторжения

        public override void ImpactParticle(Particle particle)
        {
            // считаем вектор отторжения от точки
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            // считаем расстояние от центра точки до центра частицы
            double r = Math.Sqrt(gX * gX + gY * gY);

            if (r + particle.Radius < Power / 2) // если частица оказалось внутри окружности
            {
                // считаем квадрат расстояния между частицей и точкой r^2
                // то притягиваем ее
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);

                // пересчитываем вектор скорости с учетом отторжения от точки
                particle.SpeedX -= gX * Power / r2; // минусы вместо плюсов
                particle.SpeedY -= gY * Power / r2; // и тут
            }
        }
    }
}
