using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_работа
{
    public partial class Form1 : Form
    {
        Emitter emitter; // эмиттер
        public Form1()
        {
            InitializeComponent();

            // привяжем изображение, для того чтобы рисовать на нем
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // вручную создаем
            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };

            // гравитон
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.25),
                Y = picDisplay.Height / 2
            });

            // в центре антигравитон
            emitter.impactPoints.Add(new AntiGravityPoint
            {
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2
            });

            // снова гравитон
            emitter.impactPoints.Add(new GravityPoint
            {
                X = (float)(picDisplay.Width * 0.75),
                Y = picDisplay.Height / 2
            });
        }

        // метод, который будет вызываться по таймеру
        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState(); // каждый тик обновляем эмиттер

            using (Graphics g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); // очистка изображения от предыдущих данных
                emitter.Render(g); // рендерим через эмиттер
            }
            picDisplay.Invalidate(); // обновляем picDisplay
        }
        
        // обработчик события фиксирования положения мыши
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // в эмиттер передаем положение мышки
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }
    }
}
