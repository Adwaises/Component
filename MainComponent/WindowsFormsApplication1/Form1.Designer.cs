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
            this.childComponent1 = new ChildComponent.ChildComponent();
            this.mainComponent1 = new MainComp.MainComponent();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // childComponent1
            // 
            this.childComponent1.Accessory = false;
            this.childComponent1.BackColor = System.Drawing.Color.Red;
            this.childComponent1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent1.Location = new System.Drawing.Point(0, 0);
            this.childComponent1.Name = "childComponent1";
            this.childComponent1.RandomLocation = false;
            this.childComponent1.Size = new System.Drawing.Size(25, 25);
            this.childComponent1.TabIndex = 0;
            this.childComponent1.TabStop = false;
            // 
            // mainComponent1
            // 
            this.mainComponent1.BackColor = System.Drawing.SystemColors.Control;
            this.mainComponent1.BackgroundImagePrimary = ((System.Drawing.Image)(resources.GetObject("mainComponent1.BackgroundImagePrimary")));
            this.mainComponent1.ChildRightNumber = 3;
            this.mainComponent1.ClildNumber = 5;
            this.mainComponent1.ColorLine = System.Drawing.Color.Blue;
            this.mainComponent1.CustomChildImages = null;
            this.mainComponent1.ErrorNumber = 3;
            this.mainComponent1.Location = new System.Drawing.Point(12, 12);
            this.mainComponent1.LocationPrimary = new System.Drawing.Point(255, 19);
            this.mainComponent1.MaximumSize = new System.Drawing.Size(400, 180);
            this.mainComponent1.MinimumSize = new System.Drawing.Size(400, 180);
            this.mainComponent1.Name = "mainComponent1";
            this.mainComponent1.RandomLocationChild = false;
            this.mainComponent1.Size = new System.Drawing.Size(400, 180);
            this.mainComponent1.SizePrimary = new System.Drawing.Size(128, 128);
            this.mainComponent1.TabIndex = 0;
            this.mainComponent1.TextHelp = "Text help\r\nHelp text";
            this.mainComponent1.TypeImage = MainComp.MainComponent.TypesOfImages.Refrigerator;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 404);
            this.Controls.Add(this.mainComponent1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ChildComponent.ChildComponent childComponent1;
        private MainComp.MainComponent mainComponent1;
    }
}

