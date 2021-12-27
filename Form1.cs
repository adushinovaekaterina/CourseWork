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
    }
}
