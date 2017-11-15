using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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



        public PrimaryComponent.PrimaryComponent primaryComponent1;
        public ChildComponent.ChildComponent childComponent1;

        private void InitializeComponent()
        {
            this.primaryComponent1 = new PrimaryComponent.PrimaryComponent();
            this.childComponent1 = new ChildComponent.ChildComponent();
            ((System.ComponentModel.ISupportInitialize)(this.primaryComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // primaryComponent1
            // 
            this.primaryComponent1.BackColor = System.Drawing.Color.DarkBlue;
            this.primaryComponent1.Location = new System.Drawing.Point(10, 10);
            this.primaryComponent1.Name = "primaryComponent1";
            this.primaryComponent1.Size = new System.Drawing.Size(50, 100);
            this.primaryComponent1.TabIndex = 0;
            this.primaryComponent1.TabStop = false;
            // 
            // childComponent1
            // 
            this.childComponent1.BackColor = System.Drawing.Color.DarkBlue;
            this.childComponent1.Location = new System.Drawing.Point(100, 100);
            this.childComponent1.Name = "childComponent1";
            this.childComponent1.Size = new System.Drawing.Size(50, 100);
            this.childComponent1.TabIndex = 0;
            this.childComponent1.TabStop = false;
            // 
            // MainComponent
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            ((System.ComponentModel.ISupportInitialize)(this.primaryComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.childComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}

