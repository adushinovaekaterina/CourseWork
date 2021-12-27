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

        GravityPoint point1; // поле под первую точку
        GravityPoint point2; // поле под вторую точку

        public Form1()
        {
            InitializeComponent();

            // привяжем изображение, для того чтобы рисовать на нем
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // создаем эмиттер и привязываем его к полю emitter
            this.emitter = new Emitter
            {
                Direction = 0, // вектор направления в градусах, куда сыпет эмиттер
                Spreading = 10, // разброс частиц относительно Direction
                SpeedMin = 10, // начальная минимальная скорость движения частицы
                SpeedMax = 10, // начальная максимальная скорость движения частицы
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter); // добавляем в список emitters, чтобы эмиттер рендерился и обновлялся

            // привязываем гравитоны к полям
            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };

            point2 = new GravityPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };

            // привязываем поля к эмиттеру
            emitter.impactPoints.Add(point1);
            emitter.impactPoints.Add(point2);

            //// в центре антигравитон
            //emitter.impactPoints.Add(new AntiGravityPoint
            //{
            //    X = picDisplay.Width / 2,
            //    Y = picDisplay.Height / 2
            //});

            //// снова гравитон
            //emitter.impactPoints.Add(new GravityPoint
            //{
            //    X = (float)(picDisplay.Width * 0.75),
            //    Y = picDisplay.Height / 2
            //});
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
            foreach (Emitter emitter in emitters)
            {
                // в эмиттер передаем положение мышки
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            // передаем положение мыши в положение гравитона
            point2.X = e.X;
            point2.Y = e.Y;
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value; // направлению эмиттера присваиваем значение ползунка 
            lblDirection.Text = $"{tbDirection.Value}°"; // вывод значения
        }
        private void tbSpreading_Scroll(object sender, EventArgs e)
        {
            emitter.Spreading = tbSpreading.Value; // направлению эмиттера присваиваем значение ползунка 
            lblSpreading.Text = $"{tbSpreading.Value}°"; // вывод значения
        }

        private void tbGraviton_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGraviton.Value;
        }

        private void tbGraviton2_Scroll(object sender, EventArgs e)
        {
            point2.Power = tbGraviton2.Value;
        }
    }
}
