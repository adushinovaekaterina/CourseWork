using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    // класс для создания нескольких систем частиц,
    // каждая из которых будет вести себя по-разному,
    // а рисовать можно будет все разом
    public class Emitter
    {     
        List<Particle> particles = new List<Particle>(); // список для хранения частиц

        // переменные для хранения положения мыши
        public int MousePositionX;
        public int MousePositionY;

        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // список для хранения точек притяжения и отторжения

        public float GravitationX = 0;
        public float GravitationY = 0; // гравитация отключена // (если = 1) пусть гравитация будет силой один пиксель за такт

        // метод для обновления состояния системы
        public void UpdateState()
        {
            foreach (Particle particle in particles)
            {
                particle.Life -= 1; // уменьшаем здоровье

                // если здоровье кончилось
                if (particle.Life < 0)
                {
                    // восстанавливаем здоровье
                    particle.Life = 20 + Particle.rand.Next(100);

                    // новое начальное расположение частицы — это то, куда указывает курсор
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;

                    // сброс состояния частицы
                    var direction = (double)Particle.rand.Next(360);
                    var speed = 1 + Particle.rand.Next(10);

                    particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
                    particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

                    particle.Radius = 2 + Particle.rand.Next(10);
                }
                else
                {
                    // каждая точка по-своему воздействует на вектор скорости
                    foreach (IImpactPoint point in impactPoints)
                    {
                        point.ImpactParticle(particle); // так как вся логика в точках, то тут нужно только метод вызывать
                    }

                    // гравитация воздействует на вектор скорости, поэтому пересчитываем его
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;

                    // пересчет положения частицы в пространстве, 
                    // теперь храним вектор скорости в явном виде и его не надо пересчитывать
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                }
            }

            // генерация частиц, не более 10 штук за тик
            for (int i = 0; i < 10; ++i)
            {
                if (particles.Count < 500) // пока частиц меньше 500 
                {
                    ParticleColorful particle = new ParticleColorful(); // генерируем новые
                    particle.FromColor = Color.Yellow;
                    particle.ToColor = Color.FromArgb(0, Color.Magenta);
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;
                    particles.Add(particle);
                }
                else
                {
                    break; // иначе ничего не генерируем
                }
            }
        }

        // метод для рендеринга
        public void Render(Graphics g)
        {
            // отрисовка частиц
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            // рисуем точки притяжения красными кружочками
            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }
    }
}
