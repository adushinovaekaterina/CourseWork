
namespace Курсовая_работа
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picDisplay = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbDirection = new System.Windows.Forms.TrackBar();
            this.tbSpreading = new System.Windows.Forms.TrackBar();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.tbCount = new System.Windows.Forms.TrackBar();
            this.lblDirection = new System.Windows.Forms.Label();
            this.lblSpreading = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.tbLife = new System.Windows.Forms.TrackBar();
            this.lblLife = new System.Windows.Forms.Label();
            this.lbCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLife)).BeginInit();
            this.SuspendLayout();
            // 
            // picDisplay
            // 
            this.picDisplay.Location = new System.Drawing.Point(12, 12);
            this.picDisplay.Name = "picDisplay";
            this.picDisplay.Size = new System.Drawing.Size(626, 426);
            this.picDisplay.TabIndex = 0;
            this.picDisplay.TabStop = false;
            this.picDisplay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picDisplay_MouseMove);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 40;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tbDirection
            // 
            this.tbDirection.Location = new System.Drawing.Point(668, 44);
            this.tbDirection.Maximum = 359;
            this.tbDirection.Name = "tbDirection";
            this.tbDirection.Size = new System.Drawing.Size(174, 45);
            this.tbDirection.TabIndex = 1;
            this.tbDirection.Scroll += new System.EventHandler(this.tbDirection_Scroll);
            // 
            // tbSpreading
            // 
            this.tbSpreading.Location = new System.Drawing.Point(668, 117);
            this.tbSpreading.Maximum = 359;
            this.tbSpreading.Minimum = 10;
            this.tbSpreading.Name = "tbSpreading";
            this.tbSpreading.Size = new System.Drawing.Size(174, 45);
            this.tbSpreading.TabIndex = 3;
            this.tbSpreading.Value = 10;
            this.tbSpreading.Scroll += new System.EventHandler(this.tbSpreading_Scroll);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(668, 200);
            this.tbSpeed.Minimum = 1;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(174, 45);
            this.tbSpeed.TabIndex = 5;
            this.tbSpeed.Value = 1;
            this.tbSpeed.Scroll += new System.EventHandler(this.tbSpeed_Scroll);
            // 
            // tbCount
            // 
            this.tbCount.Location = new System.Drawing.Point(668, 282);
            this.tbCount.Maximum = 100;
            this.tbCount.Minimum = 20;
            this.tbCount.Name = "tbCount";
            this.tbCount.Size = new System.Drawing.Size(174, 45);
            this.tbCount.TabIndex = 7;
            this.tbCount.Value = 20;
            this.tbCount.Scroll += new System.EventHandler(this.tbCount_Scroll);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(671, 16);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(75, 13);
            this.lblDirection.TabIndex = 8;
            this.lblDirection.Text = "Направление";
            // 
            // lblSpreading
            // 
            this.lblSpreading.AutoSize = true;
            this.lblSpreading.Location = new System.Drawing.Point(671, 101);
            this.lblSpreading.Name = "lblSpreading";
            this.lblSpreading.Size = new System.Drawing.Size(86, 13);
            this.lblSpreading.TabIndex = 9;
            this.lblSpreading.Text = "Распределение";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(671, 170);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(55, 13);
            this.lblSpeed.TabIndex = 10;
            this.lblSpeed.Text = "Скорость";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(671, 250);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(132, 13);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = "Количество частиц в тик";
            // 
            // tbLife
            // 
            this.tbLife.Location = new System.Drawing.Point(668, 365);
            this.tbLife.Maximum = 100;
            this.tbLife.Minimum = 20;
            this.tbLife.Name = "tbLife";
            this.tbLife.Size = new System.Drawing.Size(174, 45);
            this.tbLife.TabIndex = 12;
            this.tbLife.Value = 20;
            this.tbLife.Scroll += new System.EventHandler(this.tbLife_Scroll);
            // 
            // lblLife
            // 
            this.lblLife.AutoSize = true;
            this.lblLife.Location = new System.Drawing.Point(671, 338);
            this.lblLife.Name = "lblLife";
            this.lblLife.Size = new System.Drawing.Size(146, 13);
            this.lblLife.TabIndex = 13;
            this.lblLife.Text = "Продолжительность жизни";
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(671, 413);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(115, 13);
            this.lbCount.TabIndex = 14;
            this.lbCount.Text = "Количество частиц: 0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 480);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.lblLife);
            this.Controls.Add(this.tbLife);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblSpeed);
            this.Controls.Add(this.lblSpreading);
            this.Controls.Add(this.lblDirection);
            this.Controls.Add(this.tbCount);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.tbSpreading);
            this.Controls.Add(this.tbDirection);
            this.Controls.Add(this.picDisplay);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDirection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpreading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbLife)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbDirection;
        private System.Windows.Forms.TrackBar tbSpreading;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.TrackBar tbCount;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Label lblSpreading;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TrackBar tbLife;
        private System.Windows.Forms.Label lblLife;
        private System.Windows.Forms.Label lbCount;
    }
}

