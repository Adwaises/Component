namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.mainComponent2 = new MainComp.MainComponent();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(445, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
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
            this.mainComponent2.PathRightChildPicture = "C:\\Users\\Sergey\\Documents\\PictureForCaptcha\\1";
            this.mainComponent2.PathWrongChildPicture = "";
            this.mainComponent2.RandomLocationChild = false;
            this.mainComponent2.Size = new System.Drawing.Size(400, 180);
            this.mainComponent2.TabIndex = 0;
            this.mainComponent2.TextHelp = "С помощью мыши перетащите элементы, чтобы собрать изображение лица";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(673, 299);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.mainComponent2);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MainComp.MainComponent mainComponent1;
        private MainComp.MainComponent mainComponent2;
        private System.Windows.Forms.TextBox textBox1;
    }
}