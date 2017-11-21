using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrimaryComponent
{
    public class PrimaryComponent : PictureBox
    {
        public PrimaryComponent()
        {
            this.Size = new Size(128, 128);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
