﻿namespace WindowsFormsApplication1
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.mainComponent1 = new MainComp.MainComponent();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(442, 231);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // mainComponent1
            // 
            this.mainComponent1.BackColor = System.Drawing.SystemColors.Control;
            this.mainComponent1.BackgroundImagePrimary = null;
            this.mainComponent1.ClildNumber = 5;
            this.mainComponent1.ColorLine = System.Drawing.Color.Blue;
            this.mainComponent1.ErrorNumber = 3;
            this.mainComponent1.Location = new System.Drawing.Point(0, 0);
            this.mainComponent1.LocationMode = MainComp.MainComponent.LocationChild.Face;
            this.mainComponent1.LocationPrimary = new System.Drawing.Point(283, 32);
            this.mainComponent1.MaximumSize = new System.Drawing.Size(400, 180);
            this.mainComponent1.MinimumSize = new System.Drawing.Size(400, 180);
            this.mainComponent1.Name = "mainComponent1";
            this.mainComponent1.RandomLocationChild = false;
            this.mainComponent1.Size = new System.Drawing.Size(400, 180);
            this.mainComponent1.SizePrimary = new System.Drawing.Size(100, 100);
            this.mainComponent1.TabIndex = 0;
            this.mainComponent1.TextHelp = "Text\r\nhelp\r\nhelp";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 404);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.mainComponent1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MainComp.MainComponent mainComponent1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

