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
        Emitter emitter = new Emitter(); // эмиттер
        public Form1()
        {
            InitializeComponent();

            // привяжем изображение, для того чтобы рисовать на нем
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
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
