﻿using MainComponent.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MainComp
{
    public partial class MainComponent : UserControl
    {
        public enum TypesOfImages { Face, Pizza, Flower, Custom }
        private PictureBox pictureBox = null;
        private List<ChildComponent.ChildComponent> сhildElemlist;
        //переменные основного компонента
        private string textHelp = "Text\r\nhelp";
        private int errorNumber = 3;
        private int clildNumber = 5;
        private Color colorLine = Color.Blue;

        public MainComponent()
        {
            InitializeComponent();
            pictureBox = new PictureBox();
            
            //this.SetStyle(ControlStyles.UserPaint, true);
            pictureBox.Invalidate(true);
            pictureBox.Size = new Size(400, 180);

            //создание списка дочерних элементов и его заполение
            сhildElemlist = new List<ChildComponent.ChildComponent>();
            foreach (var elem in this.Controls)
            {
                if (elem is ChildComponent.ChildComponent) {
                    сhildElemlist.Add(elem as ChildComponent.ChildComponent);
                }
            }
            ToPosition(this.primaryComponent1);
            //Тут будет загрузка картинок из папки в коллекции
            LoadImages();

            //Загрузка картинок в зависимости от установленного TypesOfImages 
            SetImagesFromType();

            //После загрузки - перемещение
            сhildElemlist.Reverse();
            foreach (var elem in сhildElemlist)
            {
                LearnToMove(elem);
            }
        }



        #region WorkWithImage

        private TypesOfImages typeImages = TypesOfImages.Face;
        private ImageList FaceImg = new ImageList();
        private ImageList PizzaImg = new ImageList();
        private ImageList FlowersImg = new ImageList();
        private ImageList TrashImg = new ImageList();

        [Category("Component"), Description("Current type images of component")]
        public TypesOfImages TypeImage
        {
            get { return typeImages; }
            set
            {
                typeImages = value;
            }
        }
        
        ImageList imgs = new ImageList();

        [Category("ChildComponent"), Description("Custom list of child images")]
        public ImageList CustomChildImages
        {
            get { return imgs; }
            set { imgs = value; }
        }

        void LoadImages()
        {
            //Исправлю и сделаю загрузку ВСЕХ файлов из папки
            //Загрузка из ресурсов
            FaceImg.ImageSize = new Size (128,128);
            FaceImg.Images.Add(Resources.face as Bitmap);
            FaceImg.Images.Add(Resources.eyes as Bitmap);
            FaceImg.Images.Add(Resources.nose as Bitmap);
            FaceImg.Images.Add(Resources.mouth as Bitmap);

            //TrashImg.Images.Add(Resources)
            TrashImg.ImageSize = new Size(128, 128);
            TrashImg.Images.Add(Resources.rose as Bitmap);
            TrashImg.Images.Add(Resources.poppy as Bitmap);
            TrashImg.Images.Add(Resources.roses as Bitmap);

        }

        void SetImagesFromType()
        {
            if (typeImages == TypesOfImages.Face)
            {   
                //Загрузка шаблона "Лицо"
                BackgroundImagePrimary = FaceImg.Images[0];

                //Итератор который проходит по картинкам в коллекции
                int numPicture = 1;
                for (int i = 0; i < сhildElemlist.Count; i++)
                {
                    //Загружаем все элементы из коллекции
                    //Если нужно загрузить больше элементов чем есть картинок 
                    //- загрузка из трэш-коллекции
                    if (i < FaceImg.Images.Count - 2)
                    {
                        сhildElemlist[i].BackgroundImage = FaceImg.Images[numPicture];
                        numPicture++;
                    } else if (i == FaceImg.Images.Count - 2)
                    {
                        сhildElemlist[i].BackgroundImage = FaceImg.Images[numPicture];
                        numPicture = 1;
                    }
                    else
                    {
                        сhildElemlist[i].BackgroundImage = TrashImg.Images[numPicture];
                        numPicture++;
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
                return сhildElemlist;
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
                foreach (var elem in сhildElemlist)
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
                сhildElemlist.RemoveAt(сhildElemlist.Count-1);
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
                    foreach (var elem in сhildElemlist)
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
                Controls.Add(child);
                сhildElemlist.Add(child);
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
