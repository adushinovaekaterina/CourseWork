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
        List<Particle> particles = new List<Particle>(); // список для хранения частиц
        public Form1()
        {
            InitializeComponent();

            // привяжем изображение, для того чтобы рисовать на нем
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            // генерируем 500 частиц
            for (var i = 0; i < 500; ++i)
            {
                Particle particle = new Particle();

                // переносим частицы в центр изображения
                particle.X = picDisplay.Image.Width / 2;
                particle.Y = picDisplay.Image.Height / 2;

                particles.Add(particle); // добавляем список
            }
        }

        // метод для обновления состояния системы
        private void UpdateState()
        {
            foreach (Particle particle in particles)
            {
                particle.Life -= 1; // уменьшаем здоровье

                // если здоровье кончилось
                if (particle.Life < 0)
                {
                    // восстанавливаем здоровье
                    particle.Life = 20 + Particle.rand.Next(100);

                    // перемещаем частицу в центр
                    particle.X = picDisplay.Image.Width / 2;
                    particle.Y = picDisplay.Image.Height / 2;

                    // делаю рандомное направление, скорость и размер
                    particle.Direction = Particle.rand.Next(360);
                    particle.Speed = 1 + Particle.rand.Next(10);
                    particle.Radius = 2 + Particle.rand.Next(10);
                }
                else
                {
                    // пересчитываем положение частиц в соответствии с их направлением движения и скоростью
                    var directionInRadians = particle.Direction / 180 * Math.PI;
                    particle.X += (float)(particle.Speed * Math.Cos(directionInRadians));
                    particle.Y -= (float)(particle.Speed * Math.Sin(directionInRadians));
                }
            }
        }

        // метод для рендеринга
        private void Render(Graphics g)
        {
            // отрисовка частиц
            foreach (Particle particle in particles)
            {
                particle.Draw(g);
            }
        }

        // метод для обработки тика таймера
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState(); // каждый тик обновляем систему

            using (Graphics g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.White); // очистка изображения от предыдущих данных
                Render(g); // рендерим систему
            }

            picDisplay.Invalidate(); // обновляем picDisplay
        }
    }
}
