﻿using System;
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


            //            this.childComponent1 = new ChildComponent.ChildComponent(true);
            //this.childComponent2 = new ChildComponent.ChildComponent(true);
            //this.childComponent3 = new ChildComponent.ChildComponent(true);
            //this.childComponent4 = new ChildComponent.ChildComponent(false);
            //this.childComponent5 = new ChildComponent.ChildComponent(false);
            //this.childComponent8 = new ChildComponent.ChildComponent(false);


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainComponent));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.primaryComponent1 = new PrimaryComponent.PrimaryComponent();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.primaryComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.childComponent1 = new ChildComponent.ChildComponent(true);
            this.childComponent2 = new ChildComponent.ChildComponent(true);
            this.childComponent3 = new ChildComponent.ChildComponent(true);
            this.childComponent4 = new ChildComponent.ChildComponent(false);
            this.childComponent5 = new ChildComponent.ChildComponent(false);
            this.childComponent8 = new ChildComponent.ChildComponent(false);
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent8)).BeginInit();
            this.SuspendLayout();
            // 
            // primaryComponent1
            // 
            this.primaryComponent1.BackColor = System.Drawing.Color.Transparent;
            this.primaryComponent1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.primaryComponent1.InitialImage = ((System.Drawing.Image)(resources.GetObject("primaryComponent1.InitialImage")));
            this.primaryComponent1.Location = new System.Drawing.Point(267, 3);
            this.primaryComponent1.Name = "primaryComponent1";
            this.primaryComponent1.Size = new System.Drawing.Size(128, 128);
            this.primaryComponent1.TabIndex = 8;
            this.primaryComponent1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(375, 155);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.Desktop;
            this.pictureBox2.Location = new System.Drawing.Point(347, 155);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
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
            // childComponent4
            // 
            this.childComponent4.Accessory = true;
            this.childComponent4.BackColor = System.Drawing.Color.Transparent;
            this.childComponent4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent4.Location = new System.Drawing.Point(117, 3);
            this.childComponent4.Name = "childComponent4";
            this.childComponent4.RandomLocation = false;
            this.childComponent4.Size = new System.Drawing.Size(32, 32);
            this.childComponent4.TabIndex = 12;
            this.childComponent4.TabStop = false;
            // 
            // childComponent5
            // 
            this.childComponent5.Accessory = true;
            this.childComponent5.BackColor = System.Drawing.Color.Transparent;
            this.childComponent5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent5.Location = new System.Drawing.Point(155, 3);
            this.childComponent5.Name = "childComponent5";
            this.childComponent5.RandomLocation = false;
            this.childComponent5.Size = new System.Drawing.Size(32, 32);
            this.childComponent5.TabIndex = 13;
            this.childComponent5.TabStop = false;
            // 
            // childComponent8
            // 
            this.childComponent8.Accessory = true;
            this.childComponent8.BackColor = System.Drawing.Color.Transparent;
            this.childComponent8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent8.Location = new System.Drawing.Point(3, 41);
            this.childComponent8.Name = "childComponent8";
            this.childComponent8.RandomLocation = false;
            this.childComponent8.Size = new System.Drawing.Size(32, 32);
            this.childComponent8.TabIndex = 14;
            this.childComponent8.TabStop = false;
            // 
            // MainComponent
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.pictureBox2);
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
            ((System.ComponentModel.ISupportInitialize)(this.primaryComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent8)).EndInit();
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
        private PictureBox pictureBox2;
    }
}

