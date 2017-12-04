namespace WindowsFormsApplication1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.mainComponent1 = new MainComp.MainComponent();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(522, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(522, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // mainComponent1
            // 
            this.mainComponent1.BackColor = System.Drawing.SystemColors.Control;
            this.mainComponent1.BackgroundImagePrimary = ((System.Drawing.Image)(resources.GetObject("mainComponent1.BackgroundImagePrimary")));
            this.mainComponent1.CaptchaPattern = MainComp.MainComponent.TypesOfImages.Face;
            this.mainComponent1.ColorLine = System.Drawing.Color.Blue;
            this.mainComponent1.CountCorrectChild = 3;
            this.mainComponent1.CountNonCorrectChild = 3;
            this.mainComponent1.ErrorNumber = 3;
            this.mainComponent1.Location = new System.Drawing.Point(12, 12);
            this.mainComponent1.LocationPrimary = new System.Drawing.Point(267, 3);
            this.mainComponent1.MaximumSize = new System.Drawing.Size(400, 180);
            this.mainComponent1.MinimumSize = new System.Drawing.Size(400, 180);
            this.mainComponent1.Name = "mainComponent1";
            this.mainComponent1.PathNoRightChildPicture = "";
            this.mainComponent1.PathRightChildPicture = "";
            this.mainComponent1.RandomLocationChild = false;
            this.mainComponent1.Size = new System.Drawing.Size(400, 180);
            this.mainComponent1.SizePrimary = new System.Drawing.Size(128, 128);
            this.mainComponent1.TabIndex = 0;
            this.mainComponent1.TextHelp = "Text\r\nhelp";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 356);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mainComponent1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        private MainComp.MainComponent mainComponent1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

