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
        public int X; // координата X центра эмиттера, будем ее использовать вместо MousePositionX
        public int Y; // соответствующая координата Y 
        public int Direction = 0; // вектор направления в градусах, куда сыпет эмиттер
        public int Spreading = 360; // разброс частиц относительно Direction
        public int SpeedMin = 1; // начальная минимальная скорость движения частицы
        public int SpeedMax = 10; // начальная максимальная скорость движения частицы
        public int RadiusMin = 2; // минимальный радиус частицы
        public int RadiusMax = 10; // максимальный радиус частицы
        public int LifeMin = 20; // минимальное время жизни частицы
        public int LifeMax = 100; // максимальное время жизни частицы

        public int ParticlesPerTick = 1; // поле, в котором можно будет указать количество частиц в такт

        public Color ColorFrom = Color.White; // начальный цвет частицы
        public Color ColorTo = Color.FromArgb(0, Color.Black); // конечный цвет частиц

        List<Particle> particles = new List<Particle>(); // список для хранения частиц

        // переменные для хранения положения мыши
        public int MousePositionX;
        public int MousePositionY;

        public List<IImpactPoint> impactPoints = new List<IImpactPoint>(); // список для хранения точек притяжения и отторжения

        public float GravitationX = 0;
        public float GravitationY = 1; // гравитация отключена // (если = 1) пусть гравитация будет силой один пиксель за такт

        // метод для генерации частицы, который можно переопределить
        public virtual Particle CreateParticle()
        {
            ParticleColorful particle = new ParticleColorful(); // генерируем новые частицы
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }

        // метод для обновления состояния системы
        public void UpdateState()
        {
            int particlesToCreate = ParticlesPerTick; // фиксируем счетчик сколько частиц нам создавать за тик

            foreach (Particle particle in particles)
            {
                // если частица умерла
                if (particle.Life <= 0)
                {
                    // то проверяем надо ли создать частицу
                    if (particlesToCreate > 0)
                    {
                        // сброс частицы равносилен созданию частицы,
                        particlesToCreate -= 1; // поэтому уменьшаем счётчик созданных частиц на 1
                        ResetParticle(particle); // вызов метода для сброса частицы 
                    }
                }
                else
                {
                    // пересчет положения частицы в пространстве, 
                    // теперь храним вектор скорости в явном виде и его не надо пересчитывать
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;

                    particle.Life -= 1; // уменьшаем здоровье

                    // каждая точка по-своему воздействует на вектор скорости
                    foreach (IImpactPoint point in impactPoints)
                    {
                        point.ImpactParticle(particle); // так как вся логика в точках, то тут нужно только метод вызывать
                    }

                    // гравитация воздействует на вектор скорости, поэтому пересчитываем его
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;                    
                }
            }

            // цикл будет срабатывать только в самом начале работы эмиттера,
            // пока не накопится критическая масса частиц
            while (particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                Particle particle = CreateParticle(); // вызываем метод для генерации частицы
                ResetParticle(particle); // // вызов метода для сброса частицы 
                particles.Add(particle);

            }
        }

        public int ParticlesCount = 500;

        // метод для сброса частицы, можно переопределять
        public virtual void ResetParticle(Particle particle)
        {
            // восстанавливаем здоровье
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);

            // новое начальное расположение частицы — это то, куда указывает курсор
            particle.X = X;
            particle.Y = Y;

            // сброс состояния частицы
            double direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;
            int speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
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
    // эмиттер, который будет генерировать частицы, падающими сверху
    public class TopEmitter : Emitter
    {
        public int Width; // длина экрана

        public override void ResetParticle(Particle particle)
        {
            base.ResetParticle(particle); // вызываем базовый сброс частицы, там переопределяется жизнь

            // подкручиваем параметры движения
            particle.X = Particle.rand.Next(Width); // позиция X -- произвольная точка от 0 до Width
            particle.Y = 0;  // ноль -- это верх экрана 

            particle.SpeedY = 1; // падаем вниз по умолчанию
            particle.SpeedX = Particle.rand.Next(-2, 2); // разброс влево и вправа у частиц 
        }
    }
}
