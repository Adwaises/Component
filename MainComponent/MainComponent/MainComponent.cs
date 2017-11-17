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

        private List<ChildComponent.ChildComponent> list;

        public MainComponent()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            //this.SetStyle(ControlStyles.UserPaint, true);
            pictureBox.Invalidate(true);
            pictureBox.Size = new Size(400, 180);

            list = new List<ChildComponent.ChildComponent>();
            foreach (var elem in this.Controls)
            {
                if (elem is ChildComponent.ChildComponent) {
                    list.Add(elem as ChildComponent.ChildComponent);
                }
            }
            list.Reverse();

        }

        // private Color colorChild = Color.Blue;
        //[Category("Properties"), Description("Specifies the color of line.")]
        //public Color ColorLineChild
        //{
        //    get
        //    {
        //        return childComponent1.ColorLineChild;
        //    }
        //    set
        //    {
        //        childComponent1.ColorLineChild = value;
        //        Invalidate();
        //    }
        //}

        
        //private ChildComponent.ChildComponent childComponent = childComponent1;
        /// <summary>
        /// Свойства дочернего компонента
        /// </summary>
           
            //теперь они не нужны
            
            //[Category("ChildComponent"), Description("Specifies the background image of child element.")]
            //public Image BackgroundImageChild
            //{
            //    get
            //    {
            //        return list[0].BackgroundImage;
            //    }
            //    set
            //    {
            //        list[0].BackgroundImage = value;
            //        Invalidate();
            //    }
            //}
            //[Category("ChildComponent"), Description("Specifies the location of child element.")]
            //public Point LocationChild
            //{
            //    get
            //    {
            //        return childComponent1.Location;
            //    }
            //    set
            //    {
            //        childComponent1.Location = value;
            //        Invalidate();
            //    }
            //}
            //[Category("ChildComponent"), Description("Specifies the size of child element.")]
            //public Size SizeChild
            //{
            //    get
            //    {
            //        return childComponent1.Size;
            //    }
            //    set
            //    {
            //        childComponent1.Size = value;
            //        Invalidate();
            //    }
            //}

        [Category("ChildComponent"), Description("Specifies the list of child elements.")]
        public List<ChildComponent.ChildComponent> SelectChild
        {
            get
            {
                return list;
            }
            //set
            //{
            //    list = value;
            //    Invalidate();
            //}
        }

        /// <summary>
        /// Свойства Главного компонента
        /// </summary>
        [Category("PrimaryComponent"), Description("Specifies the background image of primary element.")]
        public Image BackgroundImagePrimary
        {
            get
            {
                return primaryComponent1.BackgroundImage;
            }
            set
            {
                primaryComponent1.BackgroundImage = value;
                Invalidate();
            }
        }
        [Category("PrimaryComponent"), Description("Specifies the location of primary element.")]
        public Point LocationPrimary
        {
            get
            {
                return primaryComponent1.Location;
            }
            set
            {
                primaryComponent1.Location = value;
                Invalidate();
            }
        }
        [Category("PrimaryComponent"), Description("Specifies the size of primary element.")]
        public Size SizePrimary
        {
            get
            {
                return primaryComponent1.Size;
            }
            set
            {
                primaryComponent1.Size = value;
                Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(colorLine, 3);
            e.Graphics.DrawRectangle(pen, 1, 1, Width - 3, Height - 3);
            base.OnPaint(e);
        }

        private Color colorLine = Color.Blue;
        [Category("Component"), Description("Specifies the color of line of component.")]
        public Color ColorLine
        {
            get
            {
                return colorLine;
            }
            set
            {
                colorLine = value;
                Invalidate();
            }
        }

        private int errorNumber = 3;
        [Category("Component"), Description("Specifies the error number of component. Value from 1 to 10.")]
        public int ErrorNumber
        {
            get
            {
                return errorNumber;
            }
            set
            {
                if(value >0 && value <= 10)
                    errorNumber = value;
                Invalidate();
            }
        }

        private int clildNumber = 5;
        [Category("Component"), Description("Specifies the number of child component. Value from 5 to 7.")]
        public int ClildNumber
        {
            get
            {
                return clildNumber;
            }
            set
            {
                int lastNum = clildNumber;
                if (value > 4 && value <= 7)
                    clildNumber = value;
                Invalidate();
                if ( clildNumber > lastNum)
                {
                    addChild(clildNumber - lastNum);
                } else if(lastNum > clildNumber)
                {
                    delChild(lastNum - clildNumber);
                }
            }

        }

        private void delChild(int n)
        {
            for (int i = 0; i < n; i++)
            {
                this.Controls.RemoveAt(Controls.Count - 1);
                list.RemoveAt(list.Count-1);
            }
        }

        private void addChild(int n)
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                ChildComponent.ChildComponent child = new ChildComponent.ChildComponent();
                child.Location = new Point(rand.Next(230), rand.Next(150));
                //определяем не наложились ли элементы
                //bool flag = true;
                //while (flag)
                //{
                //    flag = false;
                //    foreach (var elem in list)
                //    {
                //        if ((elem.Location.X + 13) - child.Location.X < Math.Abs(15) ||
                //                (elem.Location.Y + 13) - child.Location.Y < Math.Abs(15))
                //        {
                        
                //            child.Location = new Point(rand.Next(230), rand.Next(150));
                //            flag = true;

                //        }
                //    }
                //}
                
                

                Controls.Add(child);
                list.Add(child);
            }
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
