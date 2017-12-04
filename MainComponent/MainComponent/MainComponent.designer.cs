using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainComp
{
    partial class MainComponent
    {
        /// <summary> 
        /// Требуется переменная конструктора.
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



        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainComponent));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.childComponent8 = new ChildComponent.ChildComponent();
            this.childComponent5 = new ChildComponent.ChildComponent();
            this.childComponent4 = new ChildComponent.ChildComponent();
            this.childComponent3 = new ChildComponent.ChildComponent();
            this.childComponent2 = new ChildComponent.ChildComponent();
            this.childComponent1 = new ChildComponent.ChildComponent();
            this.primaryComponent1 = new PrimaryComponent.PrimaryComponent();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.childComponent6 = new ChildComponent.ChildComponent();
            this.childComponent7 = new ChildComponent.ChildComponent();
            this.childComponent9 = new ChildComponent.ChildComponent();
            this.childComponent10 = new ChildComponent.ChildComponent();
            this.childComponent11 = new ChildComponent.ChildComponent();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.primaryComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // childComponent8
            // 
            this.childComponent8.Accessory = false;
            this.childComponent8.BackColor = System.Drawing.Color.Transparent;
            this.childComponent8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent8.Location = new System.Drawing.Point(79, 41);
            this.childComponent8.Name = "childComponent8";
            this.childComponent8.RandomLocation = false;
            this.childComponent8.Size = new System.Drawing.Size(32, 32);
            this.childComponent8.TabIndex = 14;
            this.childComponent8.TabStop = false;
            // 
            // childComponent5
            // 
            this.childComponent5.Accessory = false;
            this.childComponent5.BackColor = System.Drawing.Color.Transparent;
            this.childComponent5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent5.Location = new System.Drawing.Point(41, 41);
            this.childComponent5.Name = "childComponent5";
            this.childComponent5.RandomLocation = false;
            this.childComponent5.Size = new System.Drawing.Size(32, 32);
            this.childComponent5.TabIndex = 13;
            this.childComponent5.TabStop = false;
            // 
            // childComponent4
            // 
            this.childComponent4.Accessory = false;
            this.childComponent4.BackColor = System.Drawing.Color.Transparent;
            this.childComponent4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent4.Location = new System.Drawing.Point(3, 41);
            this.childComponent4.Name = "childComponent4";
            this.childComponent4.RandomLocation = false;
            this.childComponent4.Size = new System.Drawing.Size(32, 32);
            this.childComponent4.TabIndex = 12;
            this.childComponent4.TabStop = false;
            // 
            // childComponent3
            // 
            this.childComponent3.Accessory = false;
            this.childComponent3.BackColor = System.Drawing.Color.Transparent;
            this.childComponent3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent3.Location = new System.Drawing.Point(79, 3);
            this.childComponent3.Name = "childComponent3";
            this.childComponent3.RandomLocation = false;
            this.childComponent3.Size = new System.Drawing.Size(32, 32);
            this.childComponent3.TabIndex = 11;
            this.childComponent3.TabStop = false;
            // 
            // childComponent2
            // 
            this.childComponent2.Accessory = false;
            this.childComponent2.BackColor = System.Drawing.Color.Transparent;
            this.childComponent2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent2.Location = new System.Drawing.Point(41, 3);
            this.childComponent2.Name = "childComponent2";
            this.childComponent2.RandomLocation = false;
            this.childComponent2.Size = new System.Drawing.Size(32, 32);
            this.childComponent2.TabIndex = 10;
            this.childComponent2.TabStop = false;
            // 
            // childComponent1
            // 
            this.childComponent1.Accessory = false;
            this.childComponent1.BackColor = System.Drawing.Color.Transparent;
            this.childComponent1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent1.Location = new System.Drawing.Point(3, 3);
            this.childComponent1.Name = "childComponent1";
            this.childComponent1.RandomLocation = false;
            this.childComponent1.Size = new System.Drawing.Size(32, 32);
            this.childComponent1.TabIndex = 9;
            this.childComponent1.TabStop = false;
            // 
            // primaryComponent1
            // 
            this.primaryComponent1.BackColor = System.Drawing.Color.Transparent;
            this.primaryComponent1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.primaryComponent1.InitialImage = ((System.Drawing.Image)(resources.GetObject("primaryComponent1.InitialImage")));
            this.primaryComponent1.Location = new System.Drawing.Point(267, 19);
            this.primaryComponent1.Name = "primaryComponent1";
            this.primaryComponent1.Size = new System.Drawing.Size(128, 128);
            this.primaryComponent1.TabIndex = 8;
            this.primaryComponent1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::MainComponent.Properties.Resources.help_web_button;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(375, 155);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // childComponent6
            // 
            this.childComponent6.Accessory = false;
            this.childComponent6.BackColor = System.Drawing.Color.Transparent;
            this.childComponent6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent6.Location = new System.Drawing.Point(3, 79);
            this.childComponent6.Name = "childComponent6";
            this.childComponent6.RandomLocation = false;
            this.childComponent6.Size = new System.Drawing.Size(32, 32);
            this.childComponent6.TabIndex = 15;
            this.childComponent6.TabStop = false;
            // 
            // childComponent7
            // 
            this.childComponent7.Accessory = true;
            this.childComponent7.BackColor = System.Drawing.Color.Transparent;
            this.childComponent7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent7.Location = new System.Drawing.Point(157, 4);
            this.childComponent7.Name = "childComponent7";
            this.childComponent7.RandomLocation = false;
            this.childComponent7.Size = new System.Drawing.Size(32, 32);
            this.childComponent7.TabIndex = 16;
            this.childComponent7.TabStop = false;
            // 
            // childComponent9
            // 
            this.childComponent9.Accessory = true;
            this.childComponent9.BackColor = System.Drawing.Color.Transparent;
            this.childComponent9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent9.Location = new System.Drawing.Point(196, 4);
            this.childComponent9.Name = "childComponent9";
            this.childComponent9.RandomLocation = false;
            this.childComponent9.Size = new System.Drawing.Size(32, 32);
            this.childComponent9.TabIndex = 17;
            this.childComponent9.TabStop = false;
            // 
            // childComponent10
            // 
            this.childComponent10.Accessory = true;
            this.childComponent10.BackColor = System.Drawing.Color.Transparent;
            this.childComponent10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent10.Location = new System.Drawing.Point(196, 43);
            this.childComponent10.Name = "childComponent10";
            this.childComponent10.RandomLocation = false;
            this.childComponent10.Size = new System.Drawing.Size(32, 32);
            this.childComponent10.TabIndex = 18;
            this.childComponent10.TabStop = false;
            // 
            // childComponent11
            // 
            this.childComponent11.Accessory = true;
            this.childComponent11.BackColor = System.Drawing.Color.Transparent;
            this.childComponent11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent11.Location = new System.Drawing.Point(157, 43);
            this.childComponent11.Name = "childComponent11";
            this.childComponent11.RandomLocation = false;
            this.childComponent11.Size = new System.Drawing.Size(32, 32);
            this.childComponent11.TabIndex = 19;
            this.childComponent11.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox2.Location = new System.Drawing.Point(347, 155);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // MainComponent
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.childComponent11);
            this.Controls.Add(this.childComponent10);
            this.Controls.Add(this.childComponent9);
            this.Controls.Add(this.childComponent7);
            this.Controls.Add(this.childComponent6);
            this.Controls.Add(this.childComponent8);
            this.Controls.Add(this.childComponent5);
            this.Controls.Add(this.childComponent4);
            this.Controls.Add(this.childComponent3);
            this.Controls.Add(this.childComponent2);
            this.Controls.Add(this.childComponent1);
            this.Controls.Add(this.primaryComponent1);
            this.Controls.Add(this.pictureBox1);
            this.MaximumSize = new System.Drawing.Size(400, 180);
            this.MinimumSize = new System.Drawing.Size(400, 180);
            this.Name = "MainComponent";
            this.Size = new System.Drawing.Size(400, 180);
            ((System.ComponentModel.ISupportInitialize)(this.childComponent8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.primaryComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }
        private PictureBox pictureBox1;
        private ToolTip toolTip1;
        private PrimaryComponent.PrimaryComponent primaryComponent1;
        private ChildComponent.ChildComponent childComponent1;
        private ChildComponent.ChildComponent childComponent2;
        private ChildComponent.ChildComponent childComponent3;
        private ChildComponent.ChildComponent childComponent4;
        private ChildComponent.ChildComponent childComponent5;
        private ChildComponent.ChildComponent childComponent8;
        private ChildComponent.ChildComponent childComponent6;
        private ChildComponent.ChildComponent childComponent7;
        private ChildComponent.ChildComponent childComponent9;
        private ChildComponent.ChildComponent childComponent10;
        private ChildComponent.ChildComponent childComponent11;
        private PictureBox pictureBox2;
    }
}

