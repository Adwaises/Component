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
                    //this.Location = new Point(rand.Next(230), rand.Next(150));
                    Point point = new Point(rand.Next(230), rand.Next(150));
                    //this.Location = new Point(10,10);
                    //определяем не наложились ли элементы
                    bool flag = true;
                    while (flag)
                    {
                        flag = false;
                        foreach (var elem in Parent.Controls)
                        {
                            if (elem is ChildComponent) {
                                if (Math.Abs(((elem as ChildComponent).Location.X + 13) - (point.X + 13)) < 30 &&
                                    Math.Abs(((elem as ChildComponent).Location.Y + 13) - (point.Y + 13)) < 30)
                                {
                                    point = new Point(rand.Next(230), rand.Next(140));
                                    //this.Location = new Point((elem as ChildComponent).Location.X, (elem as ChildComponent).Location.Y);
                                    flag = true;
                                }
                            }
                            //flag = false;
                        }
                    }

                    // this.Location = new Point(Parent.Controls[Parent.Controls.Count-1].Location.X, Parent.Controls[Parent.Controls.Count-1].Location.Y);
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
