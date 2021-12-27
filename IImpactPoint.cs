using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        //// базовый метод для отрисовки точки
        //public virtual void Render(Graphics g)
        //{
        //    g.FillEllipse(
        //            new SolidBrush(Color.Red),
        //            X - 5,
        //            Y - 5,
        //            10,
        //            10
        //        );
        //}
    }
}