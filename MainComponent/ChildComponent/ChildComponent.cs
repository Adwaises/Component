using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChildComponent
{
    public class ChildComponent : PictureBox

    {
        public ChildComponent()
        {
            //this.SetStyle(ControlStyles.UserPaint, true);
            //this.Invalidate(true);
            this.Size = new Size(25, 25);
            this.BackColor = Color.Red;
            //this.MaximumSize = new Size(400, 180);
            //this.MinimumSize = new Size(400, 180);
            this.BackgroundImageLayout = ImageLayout.Stretch;

        }


        private bool accessory = false;
        [Category("Child element"), Description("Specifies the accessory to the primary element.")]
        public bool Accessory 
        {
            get
            {
                return accessory;
            }
            set
            {
                accessory = value;
                Invalidate();
            }
        }

        
        [Category("Child element"), Description("Specifies the random point of child element.")]
        public bool RandomPoint
        {
            get
            {
                return false;
            }
            set
            {
                if(value)
                {
                    Random rand = new Random();
                    this.Location = new Point(rand.Next(230), rand.Next(150));
                }
                Invalidate();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
