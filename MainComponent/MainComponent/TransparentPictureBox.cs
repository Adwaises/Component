﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MainComponent
{
    /// 

    /// A transparent PictureBox.
    /// 


    public class TransparentPictureBox : PictureBox
    {

        Boolean parent_refreshed = false;

        public TransparentPictureBox()
        {
            this.BackColor = Color.Transparent;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.Image);
            e.Graphics.DrawImage(bmp, new Point(0, 0));

            int x;
            int y;

            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            Color mask = Color.FromArgb(0x00000000);
            for (x = 0; x <= bmp.Width - 1; x++)
            {
                for (y = 0; y <= bmp.Height - 1; y++)
                {
                    if (!bmp.GetPixel(x, y).Equals(mask))
                    {
                        gp.AddRectangle(new Rectangle(x, y, 1, 1));
                    }
                }
            }

            bmp.Dispose();
            this.Region = new System.Drawing.Region(gp);
            if (!parent_refreshed)
            {
                this.Parent.Invalidate();
                parent_refreshed = true;
            }
        }
    }
}
