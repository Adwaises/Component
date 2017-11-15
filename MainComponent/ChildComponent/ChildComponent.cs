using System;
using System.Collections.Generic;
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
            this.Size = new Size(50, 50);
            this.BackColor = Color.Red;
            //this.MaximumSize = new Size(400, 180);
            //this.MinimumSize = new Size(400, 180);

        }
        
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
