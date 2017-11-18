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
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MaximumSize
        {
            get { return new Size(400, 180); }
            set { Size = new Size(400, 180); }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MinimumSize
        {
            get { return new Size(400, 180); }
            set { Size = new Size(400, 180); }
        }

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
            this.primaryComponent1 = new PrimaryComponent.PrimaryComponent();
            this.childComponent5 = new ChildComponent.ChildComponent();
            this.childComponent4 = new ChildComponent.ChildComponent();
            this.childComponent3 = new ChildComponent.ChildComponent();
            this.childComponent2 = new ChildComponent.ChildComponent();
            this.childComponent1 = new ChildComponent.ChildComponent();
            ((System.ComponentModel.ISupportInitialize)(this.primaryComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // primaryComponent1
            // 
            this.primaryComponent1.BackColor = System.Drawing.Color.DarkBlue;
            this.primaryComponent1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.primaryComponent1.Location = new System.Drawing.Point(269, 45);
            this.primaryComponent1.Name = "primaryComponent1";
            this.primaryComponent1.Size = new System.Drawing.Size(100, 100);
            this.primaryComponent1.TabIndex = 1;
            this.primaryComponent1.TabStop = false;
            // 
            // childComponent5
            // 
            this.childComponent5.Accessory = false;
            this.childComponent5.BackColor = System.Drawing.Color.Red;
            this.childComponent5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent5.Location = new System.Drawing.Point(71, 56);
            this.childComponent5.Name = "childComponent5";
            this.childComponent5.RandomLocation = false;
            this.childComponent5.Size = new System.Drawing.Size(25, 25);
            this.childComponent5.TabIndex = 6;
            this.childComponent5.TabStop = false;
            // 
            // childComponent4
            // 
            this.childComponent4.Accessory = false;
            this.childComponent4.BackColor = System.Drawing.Color.Red;
            this.childComponent4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent4.Location = new System.Drawing.Point(44, 108);
            this.childComponent4.Name = "childComponent4";
            this.childComponent4.RandomLocation = false;
            this.childComponent4.Size = new System.Drawing.Size(25, 25);
            this.childComponent4.TabIndex = 5;
            this.childComponent4.TabStop = false;
            // 
            // childComponent3
            // 
            this.childComponent3.Accessory = true;
            this.childComponent3.BackColor = System.Drawing.Color.GreenYellow;
            this.childComponent3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent3.Location = new System.Drawing.Point(134, 137);
            this.childComponent3.Name = "childComponent3";
            this.childComponent3.RandomLocation = false;
            this.childComponent3.Size = new System.Drawing.Size(25, 25);
            this.childComponent3.TabIndex = 4;
            this.childComponent3.TabStop = false;
            // 
            // childComponent2
            // 
            this.childComponent2.Accessory = false;
            this.childComponent2.BackColor = System.Drawing.Color.Red;
            this.childComponent2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent2.Location = new System.Drawing.Point(117, 92);
            this.childComponent2.Name = "childComponent2";
            this.childComponent2.RandomLocation = false;
            this.childComponent2.Size = new System.Drawing.Size(25, 25);
            this.childComponent2.TabIndex = 3;
            this.childComponent2.TabStop = false;
            // 
            // childComponent1
            // 
            this.childComponent1.Accessory = true;
            this.childComponent1.BackColor = System.Drawing.Color.GreenYellow;
            this.childComponent1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent1.Location = new System.Drawing.Point(19, 32);
            this.childComponent1.Name = "childComponent1";
            this.childComponent1.RandomLocation = false;
            this.childComponent1.Size = new System.Drawing.Size(25, 25);
            this.childComponent1.TabIndex = 2;
            this.childComponent1.TabStop = false;
            this.childComponent1.Click += new System.EventHandler(this.childComponent1_Click);
            this.childComponent1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.childComponent1_MouseDown);
            // 
            // MainComponent
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.childComponent5);
            this.Controls.Add(this.childComponent4);
            this.Controls.Add(this.childComponent3);
            this.Controls.Add(this.childComponent2);
            this.Controls.Add(this.childComponent1);
            this.Controls.Add(this.primaryComponent1);
            this.MaximumSize = new System.Drawing.Size(400, 180);
            this.MinimumSize = new System.Drawing.Size(400, 180);
            this.Name = "MainComponent";
            this.Size = new System.Drawing.Size(400, 180);
            ((System.ComponentModel.ISupportInitialize)(this.primaryComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).EndInit();
            this.ResumeLayout(false);

        }
        public PrimaryComponent.PrimaryComponent primaryComponent1;
        private ChildComponent.ChildComponent childComponent1;
        private ChildComponent.ChildComponent childComponent2;
        private ChildComponent.ChildComponent childComponent3;
        private ChildComponent.ChildComponent childComponent4;
        private ChildComponent.ChildComponent childComponent5;
    }
}

