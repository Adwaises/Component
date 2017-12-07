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
            this.mainComponent2 = new MainComp.MainComponent();
            this.SuspendLayout();
            // 
            // mainComponent2
            // 
            this.mainComponent2.BackColor = System.Drawing.SystemColors.Control;
            this.mainComponent2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainComponent2.BackgroundImage")));
            this.mainComponent2.BackgroundImagePrimary = ((System.Drawing.Image)(resources.GetObject("mainComponent2.BackgroundImagePrimary")));
            this.mainComponent2.CaptchaPattern = TypesOfImages.Face;
            this.mainComponent2.ColorLine = System.Drawing.Color.Blue;
            this.mainComponent2.CountCorrectChild = 3;
            this.mainComponent2.CountNonCorrectChild = 3;
            this.mainComponent2.ErrorNumber = 3;
            this.mainComponent2.Location = new System.Drawing.Point(12, 12);
            this.mainComponent2.MaximumSize = new System.Drawing.Size(400, 180);
            this.mainComponent2.MinimumSize = new System.Drawing.Size(400, 180);
            this.mainComponent2.Name = "mainComponent2";
            this.mainComponent2.PathNoRightChildPicture = "";
            this.mainComponent2.PathRightChildPicture = "";
            this.mainComponent2.RandomLocationChild = false;
            this.mainComponent2.Size = new System.Drawing.Size(400, 180);
            this.mainComponent2.TabIndex = 0;
            this.mainComponent2.TextHelp = "Text\r\nhelp";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(637, 308);
            this.Controls.Add(this.mainComponent2);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }



        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private MainComp.MainComponent mainComponent1;
        private MainComp.MainComponent mainComponent2;
    }
}

