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
            this.button1 = new System.Windows.Forms.Button();
            this.humanVerification1 = new HumanVerification.HumanVerification();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(476, 72);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(476, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // humanVerification1
            // 
            this.humanVerification1.BackColor = System.Drawing.SystemColors.Control;
            this.humanVerification1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("humanVerification1.BackgroundImage")));
            this.humanVerification1.BackgroundImagePrimary = ((System.Drawing.Image)(resources.GetObject("humanVerification1.BackgroundImagePrimary")));
            this.humanVerification1.CaptchaPattern = TypesOfImages.Face;
            this.humanVerification1.ColorLine = System.Drawing.Color.Blue;
            this.humanVerification1.CountRightChild = 3;
            this.humanVerification1.CountWrongChild = 3;
            this.humanVerification1.ErrorNumber = 3;
            this.humanVerification1.Location = new System.Drawing.Point(12, 12);
            this.humanVerification1.MaximumSize = new System.Drawing.Size(400, 180);
            this.humanVerification1.MinimumSize = new System.Drawing.Size(400, 180);
            this.humanVerification1.Name = "humanVerification1";
            this.humanVerification1.PathRightChildPicture = "";
            this.humanVerification1.PathWrongChildPicture = "";
            this.humanVerification1.RandomLocationChild = false;
            this.humanVerification1.Size = new System.Drawing.Size(400, 180);
            this.humanVerification1.TabIndex = 3;
            this.humanVerification1.TextHelp = "С помощью мыши перетащите элементы, чтобы собрать изображение лица";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(673, 299);
            this.Controls.Add(this.humanVerification1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HumanVerification.HumanVerification mainComponent1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private HumanVerification.HumanVerification humanVerification1;
    }
}