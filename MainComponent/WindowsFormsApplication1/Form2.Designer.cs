namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.mainComponent1 = new MainComp.MainComponent();
            this.SuspendLayout();
            // 
            // mainComponent1
            // 
            this.mainComponent1.BackColor = System.Drawing.SystemColors.Control;
            this.mainComponent1.BackgroundImagePrimary = ((System.Drawing.Image)(resources.GetObject("mainComponent1.BackgroundImagePrimary")));
            this.mainComponent1.ClildNumber = 5;
            this.mainComponent1.ColorLine = System.Drawing.Color.Blue;
            this.mainComponent1.ErrorNumber = 3;
            this.mainComponent1.Location = new System.Drawing.Point(12, 26);
            this.mainComponent1.LocationPrimary = new System.Drawing.Point(267, 19);
            this.mainComponent1.MaximumSize = new System.Drawing.Size(400, 180);
            this.mainComponent1.MinimumSize = new System.Drawing.Size(400, 180);
            this.mainComponent1.Name = "mainComponent1";
            this.mainComponent1.RandomLocationChild = false;
            this.mainComponent1.Size = new System.Drawing.Size(400, 180);
            this.mainComponent1.SizePrimary = new System.Drawing.Size(128, 128);
            this.mainComponent1.TabIndex = 0;
            this.mainComponent1.TextHelp = "Text\r\nhelp";
            this.mainComponent1.TypeImage = MainComp.TypesOfImages.Face;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 364);
            this.Controls.Add(this.mainComponent1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private MainComp.MainComponent mainComponent1;
    }
}