using MainComponent.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ChildComponent;

namespace MainComp
{
    public partial class MainComponent : UserControl
    {
        public enum TypesOfImages { Face, Refrigerator, Flower, Custom }

        Random random = new Random();

        private PictureBox pictureBox = null;
        private List<ChildComponent.ChildComponent> childElemlist;

        //переменные основного компонента
        private string textHelp = "Text\r\nhelp";
        private int errorNumber = 3;
        private int clildNumber = 5;
        private Color colorLine = Color.Blue;


        //!Это костыль!
        public static System.Drawing.Drawing2D.GraphicsPath BuildTransparencyPath(Image im)
        {
            int x;
            int y;
            Bitmap bmp = new Bitmap(im);
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            Color mask = bmp.GetPixel(0, 0);

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
            return gp;
        }

        public MainComponent()
        {
            InitializeComponent();

            pictureBox = new PictureBox();
            
            //this.SetStyle(ControlStyles.UserPaint, true);
            pictureBox.Invalidate(true);
            pictureBox.Size = new Size(400, 180);

            //создание списка дочерних элементов и его заполение
            childElemlist = new List<ChildComponent.ChildComponent>();
            foreach (var elem in this.Controls)
            {
                if (elem is ChildComponent.ChildComponent) {
                    childElemlist.Add(elem as ChildComponent.ChildComponent);
                }
            }
            ToPosition(this.primaryComponent1);
            //Тут будет загрузка картинок из папки в коллекции
            LoadImages();

            //Загрузка картинок в зависимости от установленного TypesOfImages 
            SetImagesFromType(typeImages);

            //После загрузки - перемещение
            childElemlist.Reverse();
            foreach (var elem in childElemlist)
            {
                LearnToMove(elem);
            }


            //primaryComponent1.Controls.Add(childComponent1);
            //primaryComponent1.Controls.Add(childComponent2);
            //primaryComponent1.Controls.Add(childComponent3);
            //primaryComponent1.Controls.Add(childComponent4);
            //primaryComponent1.Controls.Add(childComponent5);

            Invalidate();            
        }



        #region WorkWithImage

        private int rightChildNumber = 4;

        [Category("Component"), Description("Specifies the number of right child component. Value from 1 to 4.")]
        public int CountRightChild
        {
            get
            {
                return rightChildNumber;
            }
            set
            {
                if (value > 0 && value <= 4)
                    rightChildNumber = value;
                    
                Invalidate();
            }
        }

        private TypesOfImages typeImages;

        private ImageList FaceImg = new ImageList();
        private Image primaryFace;

        private ImageList RefrigerImg = new ImageList();
        private Image primaryRefriger;

        private ImageList FlowersImg = new ImageList();
        private Image primaryFlower;

        private ImageList CustomImg = new ImageList();
        private Image primaryCustomImg;

        [Category("Component"), Description("Current type images of component")]
        public TypesOfImages TypeImage
        {
            get {
                return typeImages;
            }
            set
            {
                typeImages = value;
                SetImagesFromType(typeImages);
                Invalidate();
                this.Refresh();

            }
        }


        [Category("ChildComponent"), Description("Custom list of child images")]
        public ImageList CustomChildImages
        {
            get { return CustomImg; }
            set { CustomImg = value; }
        }

        void LoadImages()
        {
            //Исправлю и сделаю загрузку ВСЕХ файлов из папки
            //Загрузка из ресурсов
            primaryFace = Resources.face;

            FaceImg.ImageSize = new Size (32,32);
            FaceImg.Images.Add(Resources.eyes as Bitmap);
            FaceImg.Images.Add(Resources.nose as Bitmap);
            FaceImg.Images.Add(Resources.mouth as Bitmap);
            FaceImg.Images.Add(Resources.reading_glasses as Bitmap);
            FaceImg.Images.Add(Resources.moustache as Bitmap);


            //FlowersCollection
            primaryFlower = Resources.vase;

            FlowersImg.ImageSize = new Size(32, 32);
            FlowersImg.Images.Add(Resources.rose as Bitmap);
            FlowersImg.Images.Add(Resources.poppy as Bitmap);
            FlowersImg.Images.Add(Resources.roses as Bitmap);
            FlowersImg.Images.Add(Resources.rose_1 as Bitmap);
            FlowersImg.Images.Add(Resources.sunflower as Bitmap);

            //
            primaryRefriger = Resources.refrigerator;

            RefrigerImg.ImageSize = new Size(32, 32);
            RefrigerImg.Images.Add(Resources.meat as Bitmap);
            RefrigerImg.Images.Add(Resources.cheese as Bitmap);
            RefrigerImg.Images.Add(Resources.jelly as Bitmap);
            RefrigerImg.Images.Add(Resources.water as Bitmap);
            RefrigerImg.Images.Add(Resources.fish as Bitmap);
            RefrigerImg.Images.Add(Resources.can as Bitmap);
            RefrigerImg.Images.Add(Resources.carrot as Bitmap);
            
        }

        Image SetRandomWrongImage(TypesOfImages exceptionTypeImg)
        {

            var allLists = new List<ImageList>();
            if (!exceptionTypeImg.Equals(TypesOfImages.Face))
            {
                allLists.Add(FaceImg);
            }

            if (!exceptionTypeImg.Equals(TypesOfImages.Flower))
            {
                allLists.Add(FlowersImg);
            }

            if (!exceptionTypeImg.Equals(TypesOfImages.Refrigerator))
            {
                allLists.Add(RefrigerImg);
            }

            if (!exceptionTypeImg.Equals(TypesOfImages.Custom))
            {
                allLists.Add(CustomImg);
            }

            var randomList = allLists[random.Next(0, allLists.Count - 1)];

            return randomList.Images[random.Next(0, randomList.Images.Count - 1)];
        }

        void SetImagesFromType(TypesOfImages typeImg)
        {

            //var newImageList;

            if (typeImg == TypesOfImages.Face)
            {
                //Загрузка шаблона "Лицо"
                BackgroundImagePrimary = primaryFace;

                //Проход по всем дочерним элементам
                for (int i = 0; i < childElemlist.Count; i++)
                {
                    //Пока не закончатся шаблонные картинки заливаем их 
                    if (i < FaceImg.Images.Count && i < rightChildNumber)
                    {
                        childElemlist[i].BackgroundImage = FaceImg.Images[i];
                    } else // Если закончились - спамим неправильные
                    {
                        childElemlist[i].BackgroundImage = SetRandomWrongImage(typeImg);
                    }
                    
                }               

            }
            else if (typeImg == TypesOfImages.Flower)
            {
                BackgroundImagePrimary = primaryFlower;

                for (int i = 0; i < childElemlist.Count; i++)
                {

                    if (i < FlowersImg.Images.Count && i < rightChildNumber)
                    {
                        childElemlist[i].BackgroundImage = FlowersImg.Images[i];
                    }
                    else
                    {
                        childElemlist[i].BackgroundImage = SetRandomWrongImage(typeImg);
                    }

                }
            }
            else if (typeImg == TypesOfImages.Refrigerator)
            {
                BackgroundImagePrimary = primaryRefriger;

                for (int i = 0; i < childElemlist.Count; i++)
                {

                    if (i < RefrigerImg.Images.Count && i < rightChildNumber)
                    {
                        childElemlist[i].BackgroundImage = RefrigerImg.Images[i];
                    }
                    else
                    {
                        childElemlist[i].BackgroundImage = SetRandomWrongImage(typeImg);
                    }

                }
            }
        }

        #endregion

        #region Property

        /// <summary>
        /// Свойства дочернего компонента
        /// </summary>
        [Category("ChildComponent"), Description("Specifies the list of child elements.")]
        public List<ChildComponent.ChildComponent> SelectChild
        {
            get
            {
                return childElemlist;
            }
            //set
            //{
            //    childElemlist.Clear();
            //    childElemlist = value;
            //}
        }

        //пытался другим способом сделать

        public enum ChildListEnum { childComponent1, childComponent2, childComponent3, childComponent4, childComponent5 }

        private ChildListEnum childSelector;

        [Category("ChildComponent"), Description("Current type images of component")]
        public ChildListEnum ChildList
        {
            get
            {
                return childSelector;
            }
            set
            {
                childSelector = value;
                Invalidate();

            }
        }


        // они нужны мб

        //[Category("ChildComponent"), Description("Specifies the background image of child element.")]
        //public Image BackgroundImageChild
        //{
        //    get
        //    {
        //        return childElemlist[0].BackgroundImage;
        //    }
        //    set
        //    {
        //        childElemlist[0].BackgroundImage = value;
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
        [Category("ChildComponent"), Description("Specifies the size of child element.")]
        public bool Accessory
        {
            get
            {
                switch (childSelector)
                {
                    case ChildListEnum.childComponent1:
                        return childComponent1.Accessory;
                    case ChildListEnum.childComponent2:
                        return childComponent2.Accessory;
                    case ChildListEnum.childComponent3:
                        return childComponent3.Accessory;
                    case ChildListEnum.childComponent4:
                        return childComponent4.Accessory;
                    case ChildListEnum.childComponent5:
                        return childComponent5.Accessory;
                }
                return childComponent1.Accessory;


            }
            set
            {
                switch (childSelector)
                {
                    case ChildListEnum.childComponent1:
                        childComponent1.Accessory = value;
                        Invalidate();
                        break;
                    case ChildListEnum.childComponent2:
                        childComponent2.Accessory = value;
                        Invalidate();
                        break;
                    case ChildListEnum.childComponent3:
                        childComponent3.Accessory = value;
                        Invalidate();
                        break;
                    case ChildListEnum.childComponent4:
                        childComponent4.Accessory = value;
                        Invalidate();
                        break;
                    case ChildListEnum.childComponent5:
                        childComponent5.Accessory = value;
                        Invalidate();
                        break;
                }

                //if (childSelector == ChildListEnum.childComponent1)
                //{
                //    childComponent1.Accessory = value;
                //}
                //if (childSelector == ChildListEnum.childComponent2)
                //{
                //    childComponent2.Accessory = value;
                //    MessageBox.Show(childComponent2.Accessory.ToString());
                //}
                //Invalidate();

                //childComponent2.Accessory = value;
                //Invalidate();

            }
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

        /// <summary>
        /// Свойства основного коспонента
        /// </summary>

        [Category("Component"), Description("Specifies the random point of child element.")]
        public bool RandomLocationChild
        {
            get
            {
                return false;
            }
            set
            {
                foreach (var elem in childElemlist)
                {
                    elem.RandomLocation = true;
                }
                Invalidate();
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MaximumSize
        {
            get { return new Size(400, 180); }
            set { Size = new Size(400, 180); }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Size MinimumSize
        {
            get { return new Size(400, 180); }
            set { Size = new Size(400, 180); }
        }

        
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

       
        [Category("Component"), Description("Specifies the error number of component. Value from 1 to 10.")]
        public int ErrorNumber
        {
            get
            {
                return errorNumber;
            }
            set
            {
                if (value > 0 && value <= 10)
                    errorNumber = value;
                Invalidate();
            }
        }


        private int minChildNumber = 3;
        private int maxChildNumber = 7;
       
        [Category("Component"), Description("Specifies the number of child component. Value from 3 to 7.")]
        public int ClildNumber
        {
            get
            {
                return clildNumber;
            }
            set
            {
                int lastNum = clildNumber;
                if (value > minChildNumber && value <= maxChildNumber) //???Магические числа???
                    clildNumber = value;
                if (clildNumber > lastNum)
                {
                    addChild(clildNumber - lastNum);
                }
                else if (lastNum > clildNumber)
                {
                    delChild(lastNum - clildNumber);
                }

                Invalidate();
            }
        }

        [Category("Component"), Description("Specifies the text help of component.")]
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string TextHelp
        {
            get
            {
                return textHelp;
            }
            set
            {
                textHelp = value;
                textHelp.Replace("\r\n", Environment.NewLine);
                Invalidate();
            }
        }

        #endregion

        /// <summary>
        /// Метод удаления дочернего элемента с формы и листа
        /// </summary>
        /// <param name="n"></param>
        private void delChild(int n)
        {
            for (int i = 0; i < n; i++)
            {
                this.Controls.RemoveAt(Controls.Count - 1);
                childElemlist.RemoveAt(childElemlist.Count-1);
            }
        }

        /// <summary>
        /// Метод добавления дочернего элемента на форму и в лист
        /// </summary>
        /// <param name="n"></param>
        private void addChild(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Random rand = new Random();
                ChildComponent.ChildComponent child = new ChildComponent.ChildComponent();
                child.Location = new Point(rand.Next(230), rand.Next(150));
                //определяем не наложились ли элементы
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    foreach (var elem in childElemlist)
                    {
                        if (Math.Abs((elem.Location.X + 13) - (child.Location.X + 13)) < 30 &&
                            Math.Abs((elem.Location.Y + 13) - (child.Location.Y + 13)) < 30 ||
                            child.Location.X < 5 || child.Location.Y < 5 || child.Location.Y > 150)
                        {
                            child.Location = new Point(rand.Next(230), rand.Next(140));
                            flag = true;
                        }
                    }
                }

                child.Image = SetRandomWrongImage(typeImages);
                Controls.Add(child);
                childElemlist.Add(child);
                LearnToMove(child);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(colorLine, 3);
            e.Graphics.DrawRectangle(pen, 1, 1, Width - 3, Height - 3);
            base.OnPaint(e);
        }

        private void childComponent1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void childComponent1_Click(object sender, EventArgs e)
        {

        }


        // события для движения
        static bool isPress = false;
        static Point startPst;
        
        
        
        static Control controlTemp;
        // Функция выполняется при нажатии на перемещаемый контрол
        private static void mDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                //запоминаем компонент который тянем 
                controlTemp=control;
                isPress = true;
                startPst = e.Location;
                
            }
            else { return; } //проверка что нажата левая кнопка

        }
        // Функция выполняется при отжатии перемещаемого контрола
        private static void mUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                Control control = (Control)sender;
                isPress = false;
                if (control.Top > controlPrim.Location.Y && control.Left > controlPrim.Location.X)
                {
                    if ((control as ChildComponent.ChildComponent).Accessory)
                    {
                        control.MouseDown -= new MouseEventHandler(mDown);
                        control.MouseUp -= new MouseEventHandler(mUp);
                    }
                    else
                    {
                        (control as ChildComponent.ChildComponent).RandomLocation=true;
                        
                    }
                    MessageBox.Show("1");
                }
            }
            else
            {
                return;
            }//проверка что нажата левая кнопка

        } 
       
        // Функция выполняется при перемещении контрола
        private static void mMove(object sender, MouseEventArgs e)
        {
            if (isPress)
            {
                Control control = (Control)sender;
                control.Top += e.Y - startPst.Y;
                control.Left += e.X - startPst.X;
               
            }
        }
       

        // обучает контролы передвигаться

        public static void LearnToMove(object sender)
        {
            Control control = (Control)sender;
            control.MouseDown += new MouseEventHandler(mDown);
            control.MouseUp += new MouseEventHandler(mUp);
            control.MouseMove += new MouseEventHandler(mMove);
        }

        private static void onThePosition(object sender, EventArgs e)
        {

            
            if (isPress)
            {
                MessageBox.Show("1");
                //if ((controlTemp  as ChildComponent.ChildComponent).Accessory)
                //{

                //    controlTemp.MouseMove -= new MouseEventHandler(mMove);
                //}
                //else {
                //    controlTemp.Top = startPst.Y;
                //    controlTemp.Left = startPst.X;
                //} 

            }
            else {
MessageBox.Show("");
            }
        }
        static Control controlPrim;
        public static void ToPosition(object sender)
        {
            controlPrim = (Control)sender;
           // control.MouseEnter += new EventHandler(onThePosition);
        }

        /// <summary>
        /// Метод вывода подсказки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox1, textHelp);
            toolTip1.IsBalloon = true;
        }
    }

}
