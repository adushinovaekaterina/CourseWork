using System;
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
        
        public float SpeedX; // скорость перемещения по оси X
        public float SpeedY; // скорость перемещения по оси Y
        public float Life; // запас здоровья частицы

        public static Random rand = new Random(); // генератор случайных чисел
                                                  
        // конструктор по умолчанию будет создавать кастомную частицу
        public Particle()
        {
            // генерируем произвольное направление и скорость
            double direction = (double)rand.Next(360);
            int speed = 1 + rand.Next(10);

            // рассчитываем вектор скорости
            SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            Radius = 2 + rand.Next(10); // радиус от 2 до 12
            Life = 20 + rand.Next(100); // исходный запас здоровья от 20 до 120
        }

        // virtual нужно чтобы переопределить метод
        // метод для отрисовки частицы
        public virtual void Draw(Graphics g)
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

    // класс для цветных частиц
    public class ParticleColorful : Particle
    {
        public Color FromColor; // начальный цвет
        public Color ToColor; // конечный цвет

        // метод для смеси цветов
        public static Color MixColor(Color color1, Color color2, float k)
        {
            return Color.FromArgb(
                (int)(color2.A * k + color1.A * (1 - k)),
                (int)(color2.R * k + color1.R * (1 - k)),
                (int)(color2.G * k + color1.G * (1 - k)),
                (int)(color2.B * k + color1.B * (1 - k))
            );
        }

        // переопределенный метод отрисовки частицы
        public override void Draw(Graphics g)
        {
            float k = Math.Min(1f, Life / 100);

            // так как k уменьшается от 1 до 0, то порядок цветов обратный
            var color = MixColor(ToColor, FromColor, k);
            var b = new SolidBrush(color);

            // нарисуем залитый кружок радиусом Radius с центром в X, Y
            g.FillEllipse(b, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            b.Dispose(); // удаляем кисть из памяти
        }
    }
}
