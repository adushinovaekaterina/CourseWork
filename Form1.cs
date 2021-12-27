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

                    // новое начальное расположение частицы — это то, куда указывает курсор
                    particle.X = MousePositionX;
                    particle.Y = MousePositionY;

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
        private void Render(Graphics g)
        {
            // отрисовка частиц
            foreach (Particle particle in particles)
            {
                particle.Draw(g);
            }
        }

        // метод, который будет вызываться по таймеру
        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateState(); // каждый тик обновляем систему

            using (Graphics g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black); // очистка изображения от предыдущих данных
                Render(g); // рендерим систему
            }

            picDisplay.Invalidate(); // обновляем picDisplay
        }

        // переменные для хранения положения мыши
        private int MousePositionX = 0;
        private int MousePositionY = 0;
        
        // обработчик события фиксирования положения мыши
        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            // заносим положение мыши в переменные для хранения положения мыши
            MousePositionX = e.X;
            MousePositionY = e.Y;
        }
    }
}
