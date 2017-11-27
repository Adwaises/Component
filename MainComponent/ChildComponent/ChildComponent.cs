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
            this.Size = new Size(32, 32);
            this.BackColor = Color.Transparent;
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
        public bool RandomLocation
        {
            get
            {
                return false;
            }
            set
            {
                if (value)
                {
                    Random rand = new Random();
                    Point point = new Point(rand.Next(230), rand.Next(150));
                    //определяем не наложились ли элементы
                    bool flag = true;
                    while (flag)
                    {
                        flag = false;
                        foreach (var elem in Parent.Controls)
                        {
                            if (elem is ChildComponent)
                            {
                                if (Math.Abs(((elem as ChildComponent).Location.X + 13) - (point.X + 13)) < 30 &&
                                    Math.Abs(((elem as ChildComponent).Location.Y + 13) - (point.Y + 13)) < 30 ||
                                    point.X < 5 || point.Y < 5 || point.Y > 150)
                                {
                                    point = new Point(rand.Next(230), rand.Next(140));
                                    flag = true;
                                }
                            }
                        }
                    }
                    this.Location = point;
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
