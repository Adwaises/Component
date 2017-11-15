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
    public partial class MainComponent : PictureBox
    {
        //private PrimaryComponent primaryComp;
        public MainComponent()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.UserPaint, true);
            this.Invalidate(true);
            this.Size = new Size(400, 180);
            //this.MaximumSize = new Size(400, 180);
            //this.MinimumSize = new Size(400, 180);


            //primaryComp = new ListBox();
            ////имя
            //primaryComp.Name = "MyListBox";
            ////ширина
            //primaryComp.Width = 50;
            ////высота
            //primaryComp.Height = 100;
            ////координаты расположения контрола на форме
            //primaryComp.Location = new Point(10, 20);

            //this.Controls.Add(primaryComp);
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
            e.Graphics.DrawRectangle(pen, 1, 1, Width-3, Height-3);
            base.OnPaint(e);
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MaximumSize
        {
            get { return new Size(400, 180); }
            set { base.Size = new Size(400,180); }
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MinimumSize
        {
            get { return new Size(400, 180); }
            set { base.Size = new Size(400, 180); }
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
