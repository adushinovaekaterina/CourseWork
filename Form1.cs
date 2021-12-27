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
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter; // поле для эмиттера
        //Radar radar = new Radar(); // поле для радара      

        public Form1()
        {
            InitializeComponent();

            // привяжем изображение, для того чтобы рисовать на нем
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // создаем эмиттер и привязываем его к полю emitter
            emitter = new Emitter
            {
                Direction = 0, // вектор направления в градусах, куда сыпет эмиттер, движение вверх
                Spreading = 10, // разброс частиц относительно Direction
                SpeedMin = 1, // начальная минимальная скорость движения частицы
                SpeedMax = 10, // начальная максимальная скорость движения частицы
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(emitter); // добавляем в список emitters, чтобы эмиттер рендерился и обновлялся            
        }

        // метод, который будет вызываться по таймеру
        private void timer1_Tick(object sender, EventArgs e)
        {
            using (Graphics g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); // очистка изображения от предыдущих данных
                foreach (Emitter emitter in emitters)
                {
                    emitter.UpdateState(); // каждый тик обновляем эмиттер
                    emitter.Render(g); // рендерим через эмиттер
                    //radar.Render(g);
                }
            }
            lbCount.Text = $"Количество частиц: {emitter.particles.Count}";
            picDisplay.Invalidate(); // обновляем picDisplay
        }

        // обработчик события фиксирования положения мыши
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Emitter emitter in emitters)
            {
                // в эмиттер передаем положение мышки
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            // передаем положение мыши в положение гравитона
            //radar.X = e.X;
            //radar.Y = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value; // направлению эмиттера присваиваем значение ползунка 
        }

        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbSpreading.Value; // направлению эмиттера присваиваем значение ползунка 
        }

        private void tbSpeed_Scroll(object sender, EventArgs e)
        {
            emitter.SpeedMax = tbSpeed.Value;
        }

        private void tbCount_Scroll(object sender, EventArgs e)
        {
            emitter.ParticlesPerTick = tbCount.Value;
        }
        private void tbLife_Scroll(object sender, EventArgs e)
        {
            emitter.LifeMax = tbLife.Value;
        }
    }
}
