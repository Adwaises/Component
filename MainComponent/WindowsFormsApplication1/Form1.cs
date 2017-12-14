using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mainComponent1_Load(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }

        private void humanVerification1_ResultEvent(object sender, EventArgs e)
        {
            
                textBox1.Enabled = true;
           
        }

        private void humanVerification1_BadResultEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Совершено более трех ошибок");
        }

        private void humanVerification1_ErrorEvent(object sender, EventArgs e)
        {
            MessageBox.Show("Совершена ошибка");
        }
    }
}
