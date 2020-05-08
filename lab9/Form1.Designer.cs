namespace lab9
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cirs_count_slider = new System.Windows.Forms.TrackBar();
            this.av_time_slider = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cirs_count_slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.av_time_slider)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(969, 408);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(169, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "остановить";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(278, 442);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "запустить";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // cirs_count_slider
            // 
            this.cirs_count_slider.Location = new System.Drawing.Point(389, 442);
            this.cirs_count_slider.Maximum = 14;
            this.cirs_count_slider.Minimum = 1;
            this.cirs_count_slider.Name = "cirs_count_slider";
            this.cirs_count_slider.Size = new System.Drawing.Size(104, 50);
            this.cirs_count_slider.TabIndex = 3;
            this.cirs_count_slider.Value = 1;
            this.cirs_count_slider.Scroll += new System.EventHandler(this.cirs_count_slider_Scroll);
            // 
            // av_time_slider
            // 
            this.av_time_slider.Location = new System.Drawing.Point(389, 498);
            this.av_time_slider.Minimum = 2;
            this.av_time_slider.Name = "av_time_slider";
            this.av_time_slider.Size = new System.Drawing.Size(104, 50);
            this.av_time_slider.TabIndex = 4;
            this.av_time_slider.Value = 2;
            this.av_time_slider.Scroll += new System.EventHandler(this.av_time_slider_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(499, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 498);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 585);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.av_time_slider);
            this.Controls.Add(this.cirs_count_slider);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cirs_count_slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.av_time_slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar cirs_count_slider;
        private System.Windows.Forms.TrackBar av_time_slider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

