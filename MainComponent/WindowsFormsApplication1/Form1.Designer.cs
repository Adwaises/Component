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
            this.mainComponent1 = new MainComp.MainComponent();
            this.SuspendLayout();
            // 
            // mainComponent1
            // 
            this.mainComponent1.BackColor = System.Drawing.SystemColors.Control;
            this.mainComponent1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mainComponent1.BackgroundImage")));
            this.mainComponent1.BackgroundImagePrimary = ((System.Drawing.Image)(resources.GetObject("mainComponent1.BackgroundImagePrimary")));
            this.mainComponent1.CaptchaPattern = TypesOfImages.Flower;
            this.mainComponent1.ColorLine = System.Drawing.Color.Blue;
            this.mainComponent1.CountCorrectChild = 4;
            this.mainComponent1.CountNonCorrectChild = 7;
            this.mainComponent1.ErrorNumber = 3;
            this.mainComponent1.Location = new System.Drawing.Point(13, 13);
            this.mainComponent1.MaximumSize = new System.Drawing.Size(400, 180);
            this.mainComponent1.MinimumSize = new System.Drawing.Size(400, 180);
            this.mainComponent1.Name = "mainComponent1";
            this.mainComponent1.PathNoRightChildPicture = "";
            this.mainComponent1.PathRightChildPicture = "";
            this.mainComponent1.RandomLocationChild = false;
            this.mainComponent1.Size = new System.Drawing.Size(400, 180);
            this.mainComponent1.TabIndex = 0;
            this.mainComponent1.TextHelp = "Text\r\nhelp";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(637, 308);
            this.Controls.Add(this.mainComponent1);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }



        #endregion

        private MainComp.MainComponent mainComponent1;
    }
}

