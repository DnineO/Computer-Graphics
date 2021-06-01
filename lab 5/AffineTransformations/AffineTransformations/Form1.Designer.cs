namespace AffineTransformations
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
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.rb_StraightLine = new System.Windows.Forms.RadioButton();
            this.rb_CurvedLine = new System.Windows.Forms.RadioButton();
            this.textBox_Angle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(9, 331);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(155, 30);
            this.button_Start.TabIndex = 0;
            this.button_Start.Text = "Начать поворот";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Enabled = false;
            this.button_Stop.Location = new System.Drawing.Point(9, 367);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(155, 30);
            this.button_Stop.TabIndex = 1;
            this.button_Stop.Text = "Остановить";
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // rb_StraightLine
            // 
            this.rb_StraightLine.AutoSize = true;
            this.rb_StraightLine.Checked = true;
            this.rb_StraightLine.Location = new System.Drawing.Point(9, 244);
            this.rb_StraightLine.Name = "rb_StraightLine";
            this.rb_StraightLine.Size = new System.Drawing.Size(155, 17);
            this.rb_StraightLine.TabIndex = 2;
            this.rb_StraightLine.TabStop = true;
            this.rb_StraightLine.Text = "Рисование прямых линий";
            this.rb_StraightLine.UseVisualStyleBackColor = true;
            this.rb_StraightLine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rb_StraightLine_MouseClick);
            // 
            // rb_CurvedLine
            // 
            this.rb_CurvedLine.AutoSize = true;
            this.rb_CurvedLine.Location = new System.Drawing.Point(9, 267);
            this.rb_CurvedLine.Name = "rb_CurvedLine";
            this.rb_CurvedLine.Size = new System.Drawing.Size(153, 17);
            this.rb_CurvedLine.TabIndex = 3;
            this.rb_CurvedLine.Text = "Рисование кривых линий";
            this.rb_CurvedLine.UseVisualStyleBackColor = true;
            this.rb_CurvedLine.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rb_CurvedLine_MouseClick);
            // 
            // textBox_Angle
            // 
            this.textBox_Angle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Angle.Location = new System.Drawing.Point(116, 293);
            this.textBox_Angle.Name = "textBox_Angle";
            this.textBox_Angle.Size = new System.Drawing.Size(46, 20);
            this.textBox_Angle.TabIndex = 4;
            this.textBox_Angle.Text = "5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(75, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Угол:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(650, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 419);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Angle);
            this.Controls.Add(this.rb_CurvedLine);
            this.Controls.Add(this.rb_StraightLine);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.MaximumSize = new System.Drawing.Size(715, 458);
            this.MinimumSize = new System.Drawing.Size(715, 458);
            this.Name = "Form1";
            this.Text = "Афинные преобразования";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.RadioButton rb_StraightLine;
        private System.Windows.Forms.RadioButton rb_CurvedLine;
        private System.Windows.Forms.TextBox textBox_Angle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
    }
}

