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
            this.mainComp2 = new MainComponent.MainComp();
            ((System.ComponentModel.ISupportInitialize)(this.mainComp2)).BeginInit();
            this.SuspendLayout();
            // 
            // mainComp2
            // 
            this.mainComp2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mainComp2.ColorLine = System.Drawing.Color.Blue;
            this.mainComp2.InitialImage = null;
            this.mainComp2.Location = new System.Drawing.Point(12, 12);
            this.mainComp2.MaximumSize = new System.Drawing.Size(400, 180);
            this.mainComp2.MinimumSize = new System.Drawing.Size(400, 180);
            this.mainComp2.Name = "mainComp2";
            this.mainComp2.Size = new System.Drawing.Size(400, 180);
            this.mainComp2.TabIndex = 0;
            this.mainComp2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 430);
            this.Controls.Add(this.mainComp2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainComp2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MainComponent.MainComp mainComp2;
    }
}

