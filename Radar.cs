using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Курсовая_работа
{
    public class Radar
    {
        // координаты точки
        public float X;
        public float Y;

        // базовый метод для отрисовки радара
        public void Render(Graphics g)
        {
            // рисуем окружность с диаметром, равным Power
            g.DrawEllipse(
                   new Pen(Color.Red),
                   X - 100 / 2,
                   Y - 100 / 2,
                   100,
                   100
               );
        }
    }
}
