﻿using System;
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
        public Form1()
        {
            InitializeComponent();

            // привяжем изображение, для того чтобы рисовать на нем
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height); 
        }
    }
}