using PrimaryComponent;
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
    public partial class MainComponent : UserControl
    {
        //private PrimaryComponent primaryComp;

       

        private PictureBox pictureBox = null;

        public MainComponent()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            //this.SetStyle(ControlStyles.UserPaint, true);
            pictureBox.Invalidate(true);
            pictureBox.Size = new Size(400, 180);

        }



        private Color col1 = Color.Blue;
        [Category("Properties"), Description("Specifies the color of line.")]
        public Color ColorLine
        {
            get
            {
                return col1;
            }
            set
            {
                col1 = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(col1, 3);
            e.Graphics.DrawRectangle(pen, 1, 1, Width - 3, Height - 3);
            base.OnPaint(e);
        }





        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public override Size Size
        //{
        //    get { return base.Size; }
        //    set { base.Size = value; }
        //}

    }
}
