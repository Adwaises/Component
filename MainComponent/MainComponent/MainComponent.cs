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

        private int countNonCorrectChild = 3;
        private int countCorrectChild = 3;

        private static TypesOfImages typeImages = TypesOfImages.Flower;

        private Color colorLine = Color.Blue;


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
                if (elem is ChildComponent.ChildComponent)
                {
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

        //Картинки Primary компонента
        private Image primaryFace;
        private Image primaryRefriger;
        private Image primaryFlower;
        private Image primaryCustomImg;

        //Хранит картинки дочерних компоненов по типам
        private static Dictionary<Image, TypesOfImages> AllImg = new Dictionary<Image, TypesOfImages>();

        //Свойство для выбора типа шаблона
        [Category("Component"), Description("Current type images of component")]
        public TypesOfImages CaptchaPattern
        {
            get
            {
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

        [Category("Component"), Description("Specifies the number of right child component. Value from 1 to 4.")]
        public int CountCorrectChild
        {
            get
            { return countCorrectChild; }
            set
            {
                if (value > 0 && value <= 4)
                {
                    countCorrectChild = value;
                }

                Invalidate();
            }
        }

        void LoadImages()
        {
            //Исправлю и сделаю загрузку ВСЕХ файлов из папки
            //Загрузка из ресурсов
            primaryFace = Resources.face;
            primaryFlower = Resources.vase;
            primaryRefriger = Resources.refrigerator;

            AllImg.Add(Resources.eyes as Bitmap, TypesOfImages.Face);
            AllImg.Add(Resources.nose as Bitmap, TypesOfImages.Face);
            AllImg.Add(Resources.mouth as Bitmap, TypesOfImages.Face);
            AllImg.Add(Resources.moustache as Bitmap, TypesOfImages.Face);
            AllImg.Add(Resources.reading_glasses as Bitmap, TypesOfImages.Face);

            AllImg.Add(Resources.meat as Bitmap, TypesOfImages.Refrigerator);
            AllImg.Add(Resources.cheese as Bitmap, TypesOfImages.Refrigerator);
            AllImg.Add(Resources.jelly as Bitmap, TypesOfImages.Refrigerator);
            AllImg.Add(Resources.water as Bitmap, TypesOfImages.Refrigerator);
            AllImg.Add(Resources.can as Bitmap, TypesOfImages.Refrigerator);
            AllImg.Add(Resources.carrot as Bitmap, TypesOfImages.Refrigerator);

            AllImg.Add(Resources.rose as Bitmap, TypesOfImages.Flower);
            AllImg.Add(Resources.sunflower as Bitmap, TypesOfImages.Flower);
            AllImg.Add(Resources.rose_1 as Bitmap, TypesOfImages.Flower);
            AllImg.Add(Resources.poppy as Bitmap, TypesOfImages.Flower);
            AllImg.Add(Resources.roses as Bitmap, TypesOfImages.Flower);
        }

        Image SetRandomWrongImage(TypesOfImages exceptionTypeImg)
        {
            //Лист для всех элементов кроме пришедшей переменной 
            ImageList imgsNonType = new ImageList();
            imgsNonType.ImageSize = new Size(32, 32);

            foreach (var elem in AllImg)
            {
                if (!elem.Value.Equals(exceptionTypeImg))
                {
                    imgsNonType.Images.Add(elem.Key);
                }
            }

            //Image newImage = imgsNonType.Images[random.Next(0, imgsNonType.Images.Count - 1)];
            //Возвращает рандомный элемент из списка
            return imgsNonType.Images[random.Next(0, imgsNonType.Images.Count - 1)];
        }

        void SetImagesFromType(TypesOfImages typeImg)
        {
            //Задает изображение для primary-компонента
            if (typeImg == TypesOfImages.Face)
            {
                primaryComponent1.BackgroundImage = primaryFace;
            }
            else if (typeImg == TypesOfImages.Refrigerator)
            {
                primaryComponent1.BackgroundImage = primaryRefriger;
            }
            else if (typeImg == TypesOfImages.Flower)
            {
                primaryComponent1.BackgroundImage = primaryFlower;
            }
            else if (typeImg == TypesOfImages.Custom)
            {
                primaryComponent1.BackgroundImage = primaryCustomImg;
            }

            // Проход по всем картинкам и выборка изображений данного типа
            var newImageList = new List<Image>();
            foreach (var elem in AllImg)
            {
                if (elem.Value == typeImg)
                {
                    newImageList.Add(elem.Key);
                }
            }

            //Задает дочерним компонентам изображение из нового списка
            //Пока картинки есть и дочерние компоненты => делаем присваивание
            int i = 0; //Добавление подходящих компонентов
            for (int p = 0; p < CountCorrectChild; p++)
            {
                childElemlist[i].BackgroundImage = newImageList[p];
                i++;
            }

            //Добавление неправильных компонентов
            for (int j = 0; j < CountNonCorrectChild; j++)
            {
                childElemlist[i].BackgroundImage = SetRandomWrongImage(typeImages);
                i++;
            }

        }

        #endregion

        #region Property

        /// <summary>
        /// Свойства дочернего компонента
        /// </summary>


        //[Category("ChildComponent"), Description("Specifies the list of child elements.")]
        //public List<ChildComponent.ChildComponent> SelectChild
        //{
        //    get
        //    {
        //        return childElemlist;
        //    }

        //}

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
            get { return primaryComponent1.Location; }
            set
            {
                primaryComponent1.Location = value;
                Invalidate();
            }
        }

        [Category("PrimaryComponent"), Description("Specifies the size of primary element.")]
        public Size SizePrimary
        {
            get { return primaryComponent1.Size; }
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
            { return false; }
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
            { return colorLine; }
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
            { return errorNumber; }
            set
            {
                if (value > 0 && value <= 10)
                    errorNumber = value;
                Invalidate();
            }
        }


        private int minChildNumber = 1;
        private int maxChildNumber = 7;

        [Category("Component"), Description("Specifies the number of child component. Value from 1 to 7.")]
        public int CountNonCorrectChild
        {
            get
            { return countNonCorrectChild; }
            set
            {
                //Мин-Макс проверка
                int lastNum = countNonCorrectChild;
                if (value > minChildNumber && value <= maxChildNumber)
                {
                    countNonCorrectChild = value;
                }


                if (countNonCorrectChild > lastNum)
                {
                    //Аргумент - сколько новых нужно // Добавление неподходящих картинок
                    addChild(countNonCorrectChild - lastNum, false);
                } else if (lastNum > countNonCorrectChild)
                {
                    deleteChild(lastNum - countNonCorrectChild, false);
                }

                Invalidate();
            }
        }

        [Category("Component"), Description("Specifies the text help of component.")]
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string TextHelp
        {
            get
            { return textHelp; }
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
        private void deleteChild(int countDeleteChild, bool isCorrectChild)
        {
            //for (int i = 0; i < childElemlist.Count; i++){
            //    //Если нужно удалить верный 
            //    if (isCorrectChild)
            //    {

            //    } else //Если нужно удалить неверный
            //    {

            //    }
            //}



            for (int i = 0; i < countDeleteChild; i++)
            {

                this.Controls.RemoveAt(Controls.Count - 1);
                childElemlist.RemoveAt(childElemlist.Count - 1);
            }
        }

        /// <summary>
        /// Метод добавления дочернего элемента на форму и в лист
        /// </summary>
        /// <param name="n"></param>
        private void addChild(int countNewChild, bool isCorrectChild)
        {
            for (int i = 0; i < countNewChild; i++)
            {
                // Рандомим позицию
                ChildComponent.ChildComponent child = new ChildComponent.ChildComponent();
                child.Location = new Point(random.Next(230), random.Next(150));
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
                            child.Location = new Point(random.Next(230), random.Next(140));
                            flag = true;
                        }
                    }
                }
                //Если нужно добавить верный дочерний элемент
                if (isCorrectChild)
                {
                    child.BackgroundImage = FindNewCorrectImage();
                } else
                {
                    child.BackgroundImage = SetRandomWrongImage(typeImages);
                }

                Controls.Add(child);
                childElemlist.Add(child);
                LearnToMove(child);
            }
        }

        private Image FindNewCorrectImage()
        {
            //Проход по всей коллекции картинок
            foreach (var elem in AllImg)
            {
                //Если тип картинки в коллекции совпадает с текущим шаблоном капчи
                if (elem.Value == typeImages)
                {
                    //Проход по всем дочерним элементам с целью найти не использованное изображение
                    for (int i = 0; i < childElemlist.Count; i++)
                    {
                        if (!childElemlist[i].BackgroundImage.Equals(elem.Key))
                        {
                            return elem.Key;
                        }
                    }
                }
            }

            return null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Pen pen = new Pen(colorLine, 3);
            e.Graphics.DrawRectangle(pen, 1, 1, Width - 3, Height - 3);
            base.OnPaint(e);
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
                controlTemp = control;
                isPress = true;
                startPst = e.Location;

            } else
            {   //проверка что нажата левая кнопка
                return;
            } 
        }
        
        // Функция выполняется при отжатии перемещаемого контрола
        private void mUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Control childComponent
                Control control = (Control)sender;
                isPress = false;

                //Если дочерний компонент отпустили в координатах primary-comp
                if (control.Top > controlPrim.Location.Y && control.Left > controlPrim.Location.X)
                {
                    TypesOfImages downTypeImage = CaptchaPattern;

                    //TryGetValue возвращает всегда ПЕРВЫЙ В СПИСКЕ тип для неправильных элементов 
                    // Он устанавливается по дефолту
                    //Неправильные элементы c# не может найти в нашем словаре. Почему ?? Хотя если приходят верные - все ОК 
                    //Далее ниже идет костыль

                    if (AllImg.ContainsKey(control.BackgroundImage)){
                        control.MouseDown -= new MouseEventHandler(mDown);
                        control.MouseUp -= new MouseEventHandler(mUp);
                    } else
                    {
                        MessageBox.Show("Ошибка");
                        (control as ChildComponent.ChildComponent).RandomLocation = true;
                    }


                    //AllImg.TryGetValue(control.BackgroundImage as Bitmap, out downTypeImage);

                    //MessageBox.Show(" Элемент: " + downTypeImage + " CaptchaPattern " + CaptchaPattern);

                    ////Проверка сходятся ли типы primary и дочернего
                    //if (downTypeImage.Equals(CaptchaPattern))
                    //{
                    //    control.MouseDown -= new MouseEventHandler(mDown);
                    //    control.MouseUp -= new MouseEventHandler(mUp);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Ошибка");
                    //    (control as ChildComponent.ChildComponent).RandomLocation = true;
                    //}
                }
            } else
            {//проверка что нажата левая кнопка
                return;
            }
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
        public void LearnToMove(object sender)
        {
            Control control = (Control)sender;
            control.MouseDown += new MouseEventHandler(mDown);
            control.MouseUp += new MouseEventHandler(mUp);
            control.MouseMove += new MouseEventHandler(mMove);
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
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox1, textHelp);
            toolTip1.IsBalloon = true;
        }
    }
}
