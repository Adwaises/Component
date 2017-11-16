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
            this.childComponent1 = new ChildComponent.ChildComponent();
            this.primaryComponent1 = new PrimaryComponent.PrimaryComponent();
            this.childComponent2 = new ChildComponent.ChildComponent();
            this.childComponent3 = new ChildComponent.ChildComponent();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.primaryComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent3)).BeginInit();
            this.SuspendLayout();
            // 
            // childComponent1
            // 
            this.childComponent1.BackColor = System.Drawing.Color.Red;
            this.childComponent1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent1.Location = new System.Drawing.Point(40, 30);
            this.childComponent1.Name = "childComponent1";
            this.childComponent1.Size = new System.Drawing.Size(27, 21);
            this.childComponent1.TabIndex = 2;
            this.childComponent1.TabStop = false;
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
            // childComponent2
            // 
            this.childComponent2.BackColor = System.Drawing.Color.Red;
            this.childComponent2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent2.Location = new System.Drawing.Point(40, 57);
            this.childComponent2.Name = "childComponent2";
            this.childComponent2.Size = new System.Drawing.Size(27, 22);
            this.childComponent2.TabIndex = 3;
            this.childComponent2.TabStop = false;
            // 
            // childComponent3
            // 
            this.childComponent3.BackColor = System.Drawing.Color.Red;
            this.childComponent3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.childComponent3.Location = new System.Drawing.Point(40, 97);
            this.childComponent3.Name = "childComponent3";
            this.childComponent3.Size = new System.Drawing.Size(50, 50);
            this.childComponent3.TabIndex = 4;
            this.childComponent3.TabStop = false;
            // 
            // MainComponent
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.childComponent3);
            this.Controls.Add(this.childComponent2);
            this.Controls.Add(this.childComponent1);
            this.Controls.Add(this.primaryComponent1);
            this.MaximumSize = new System.Drawing.Size(400, 180);
            this.MinimumSize = new System.Drawing.Size(400, 180);
            this.Name = "MainComponent";
            this.Size = new System.Drawing.Size(400, 180);
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.primaryComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent3)).EndInit();
            this.ResumeLayout(false);

        }
        public PrimaryComponent.PrimaryComponent primaryComponent1;
        public ChildComponent.ChildComponent childComponent1;
        private ChildComponent.ChildComponent childComponent2;
        private ChildComponent.ChildComponent childComponent3;
    }
}

