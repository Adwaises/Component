using MainComponent.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ChildComponent;
using System.IO;
using System.ComponentModel.Design;
using System.Web.UI.Design;
using EnvDTE;
using System.Windows.Forms.Design.Behavior;
using EnvDTE80;

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
        private int countNonCorrectChild = 7;
        private int countCorrectChild = 4;

        private static TypesOfImages typeImages = TypesOfImages.Flower;

        private Color colorLine = Color.Blue;

        string puthMainProject;

        public MainComponent()
        {

            puthMainProject = "";
            SuspendLayout();
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
                int oldCountCorrectChild = countCorrectChild;
                if (value > 0 && value <= 4)
                {
                    countCorrectChild = value;
                }

                if (oldCountCorrectChild < countCorrectChild)
                {
                    addChild(countCorrectChild - oldCountCorrectChild, true);
                }
                else
                {
                    deleteChild(oldCountCorrectChild - countCorrectChild, true);
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

            AllImg.Add(Resources.happyEyes as Bitmap, TypesOfImages.Face);
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



            // не заходит сюда, надо переинициализировать
            if (pathNoRightChildPicture != "")
            {
                List<string> PathChildFace = new List<string>();
                try
                {
                    //а это метод который тащит все существующие файлы из директории

                    DirectoryInfo di = new DirectoryInfo(@pathNoRightChildPicture);

                    FileInfo[] fi = di.GetFiles("*.png");

                    //MessageBox.Show(@pathNoRightChildPicture);
                    foreach (FileInfo fc in fi)
                    {
                        PathChildFace.Add(@pathNoRightChildPicture + "\\" + fc.Name);
                    }
                    //  MessageBox.Show("" + PathChildFace.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }


            }
        }

        private string pathNoRightChildPicture = "";
        [Category("ChildComponent"), Description("Specifies the path picture of no right child component.")]
        //[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string PathNoRightChildPicture
        {
            get
            { return pathNoRightChildPicture; }
            set
            {
                if (isPath(value))
                {
                    pathNoRightChildPicture = value;
                }
                else
                {
                    pathNoRightChildPicture = "";
                }
                Invalidate();
            }
        }

        private string pathRightChildPicture = "";
        [Category("ChildComponent"), Description("Specifies the path picture of no right child component.")]
        //[Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string PathRightChildPicture
        {
            get
            { return pathRightChildPicture; }
            set
            {
                if (isPath(value))
                {
                    pathRightChildPicture = value;
                } else
                {
                    pathRightChildPicture = "";
                }

                Invalidate();
            }
        }

        private bool isPath(string str)
        {
            //MessageBox.Show(str);
            //pathRightChildPicture = value;
            if (str != "" && str.Length > 2)
            {
                if (!str.Substring(1, 2).Equals(":\\"))
                {
                    MessageBox.Show("Не путь");
                    return false;
                    //pathRightChildPicture = "";
                }
                else
                {
                   // MessageBox.Show("Cтрока");
                    return true;
                }
            }
            else
            {
                //MessageBox.Show("Не путь");
                return false;
            }
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

        #region Property and events

        /// <summary>
        /// Свойства дочернего компонента
        /// </summary>

        //    //чтоб смотреть лист
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
                if (value >= minChildNumber && value <= maxChildNumber)
                {
                    countNonCorrectChild = value;
                }


                if (countNonCorrectChild > lastNum)
                {
                    //Аргумент - сколько новых нужно // Добавление неподходящих картинок
                    addChild(countNonCorrectChild - lastNum, false);
                }
                else if (lastNum > countNonCorrectChild)
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

        #region DeleteProperty
        // залоченные свойства
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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Font Font
        {
            get { return new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold); }
            set { Font = new Font(FontFamily.GenericSansSerif, 12.0F, FontStyle.Bold); }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Color ForeColor
        {
            get { return Color.Black; }
            set { ForeColor = Color.Black; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override RightToLeft RightToLeft
        {
            get { return RightToLeft.No; }
            set { RightToLeft = RightToLeft.No; }
        }

        ////странность - падает при компиляции
        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new bool UseWaitCursor
        //{
        //    get { return false; }
        //    set { UseWaitCursor = false; }
        //}

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoScroll
        {
            get { return false; }
            set { AutoScroll = false; }
        }

        ////странность
        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new Point AutoScrollMargin
        //{
        //    get { return new Point(0,0); }
        //    set { AutoScrollMargin = new Point(0, 0); }
        //}

        ////странность
        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new Point AutoScrollMinSize
        //{
        //    get { return new Point(0, 0); }
        //    set { AutoScrollMargin = new Point(0, 0); }
        //}

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoSize
        {
            get { return false; }
            set { AutoSize = false; }
        }

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new bool AutoSizeMode
        //{
        //    get { return false; }
        //    set { AutoSize = false; }
        //}


        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public override bool Padding
        //{
        //    get { return false; }
        //    set { AutoSize = false; }
        //}

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AllowDrop
        {
            get { return false; }
            set { AllowDrop = false; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override AutoValidate AutoValidate
        {
            get { return AutoValidate.EnablePreventFocusChange; }
            set { AutoValidate = AutoValidate.EnablePreventFocusChange; }
        }

        //падает
        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public override ContextMenuStrip ContextMenuStrip
        //{
        //    get { return ContextMenuStrip; }
        //    set { ContextMenuStrip = ContextMenuStrip; }
        //}

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public override ImeMode ImeMode
        //{
        //    get { return ImeMode.NoControl; }
        //    set { ImeMode = ImeMode.NoControl; }
        //}

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public override bool AccessibleDescription
        //{
        //    get { return false; }
        //    set { AllowDrop = false; }
        //}

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public override bool AccessibleName
        //{
        //    get { return false; }
        //    set { AllowDrop = false; }
        //}

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public override bool CausesValidation
        //{
        //    get { return false; }
        //    set { AllowDrop = false; }
        //}


        // скрываем события

        #endregion

        #region DeleteEvents

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Paint
        {
            add { }
            remove { }
        }

        //не хотят убираться
        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new event EventHandler CollectionChanged
        //{
        //    add { }
        //    remove { }
        //}


        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public event EventHandler CollectionChanging
        //{
        //    add { }
        //    remove { }
        //}

        // мб звук поставить кто захочет

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new event EventHandler Click
        //{
        //    add { }
        //    remove { }
        //}

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new event EventHandler DoubleClick
        //{
        //    add { }
        //    remove { }
        //}

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseCaptureChanged
        {
            add { }
            remove { }
        }

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new event EventHandler MouseClick
        //{
        //    add { }
        //    remove { }
        //}

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new event EventHandler MouseDoubleClick
        //{
        //    add { }
        //    remove { }
        //}

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Scroll
        {
            add { }
            remove { }
        }

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new event EventHandler KeyPress
        //{
        //    add { }
        //    remove { }
        //}

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new event EventHandler KeyDown
        //{
        //    add { }
        //    remove { }
        //}

        //[Browsable(false)]
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public new event EventHandler KeyUp
        //{
        //    add { }
        //    remove { }
        //}

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PreviewKeyDown
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Layout
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MarginChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Move
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Resize
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseDown
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseEnter
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseHover
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseLeave
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseMove
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseUp
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DragDrop
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DragEnter
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DragLeave
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DragOver
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler GiveFeedback
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler QueryContinueDrag
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ChangeUICues
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ControlAdded
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ControlRemoved
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler HelpRequested
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ImeModeChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Load
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler QueryAccessibilityHelp
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler StyleChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler SystemColorsChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler AutoSizeChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler AutoValidateChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackColorChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageLayoutChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BindingContextChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler CausesValidationChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ClientSizeChanged
        {
            add { }
            remove { }
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ContextMenuChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ContextMenuStripChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler CursorChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler DockChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler EnabledChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler FontChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ForeColorChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler LocationChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ParentChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RegionChanged
        {
            add { }
            remove { }
        }
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler RightToLeftChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler SizeChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabIndexChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TabStopChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler VisibleChanged
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Enter
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Leave
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Validated
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Validating
        {
            add { }
            remove { }
        }

        #endregion

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

            //КРИВО РАБОТАЕТ
            //for (int i = 0; i < countDeleteChild; i++)
            //{
            //    int index = 0;
            //    //иду по листу дочерних элементов
            //    foreach (var elem in childElemlist)
            //    {
            //        // MessageBox.Show("Зашёл");
            //        //сравниваю с типом
            //        // if (AllImg[elem.BackgroundImage] != typeImages) // значит верный
            //        if (isCorrectChild)
            //        {
            //            if (AllImg.ContainsKey(elem.BackgroundImage))
            //            {
            //                index++;
            //            }
            //        } else if (!isCorrectChild)
            //        {
            //            if (!AllImg.ContainsKey(elem.BackgroundImage))
            //            {
            //                index++;
            //            }
            //        }
            //        this.childElemlist.RemoveAt(index);
            //        this.Controls.RemoveAt(index);
            //        break;
            //    }
            //}

            for (int n = 0; n < countDeleteChild; n++)
            {
                int index = 0;
                //иду по листу дочерних элементов
                for (int i = 0; i < childElemlist.Count; i++)
                {
                    if (isCorrectChild) // удалить верный 
                    {
                        if ((childElemlist[i] as ChildComponent.ChildComponent).Accessory == true)
                        {
                            index = i;
                        }
                    }
                    else if (!isCorrectChild) // удалить не верный
                    {
                        if ((childElemlist[i] as ChildComponent.ChildComponent).Accessory == false)
                        {
                            index = i;
                        }
                    }
                }


                //поск в контроле
                int indexControl = 0;
                for (int i = 0; i < Controls.Count; i++)
                {
                    // MessageBox.Show((Controls[i].BackgroundImage == childElemlist[index].BackgroundImage).ToString());
                    if (Controls[i].BackgroundImage == childElemlist[index].BackgroundImage)
                    {
                        indexControl = i;
                        //break;
                    }
                }

                this.childElemlist.RemoveAt(index);
                this.Controls.RemoveAt(indexControl);
                Invalidate();
            }

            //this.Controls.RemoveAt(Controls.Count - 1);
            //childElemlist.RemoveAt(childElemlist.Count - 1);


        }

        /// <summary>
        /// Метод добавления дочернего элемента на форму и в лист
        /// </summary>
        /// <param name="n"></param>
        private void addChild(int countNewChild, bool isCorrectChild)
        {
            for (int i = 0; i < countNewChild; i++)
            {
                ChildComponent.ChildComponent child;

                //Если нужно добавить верный дочерний элемент
                if (isCorrectChild)
                {
                    child = new ChildComponent.ChildComponent();
                    child.Accessory = true;
                    child.BackgroundImage = FindNewCorrectImage();
                }
                else
                {
                    child = new ChildComponent.ChildComponent();
                    child.Accessory = false;
                    child.BackgroundImage = SetRandomWrongImage(typeImages);
                }
                // Рандомим позицию

                child.Location = new Point(random.Next(230), random.Next(150));
                //определяем не наложились ли элементы
                bool flag = true;
                while (flag)
                {
                    flag = false;
                    foreach (var elem in childElemlist)
                    {
                        if (Math.Abs((elem.Location.X + 13) - (child.Location.X + 13)) < 35 &&
                            Math.Abs((elem.Location.Y + 13) - (child.Location.Y + 13)) < 35 ||
                            child.Location.X < 5 || child.Location.Y < 5 || child.Location.Y > 140)
                        {
                            child.Location = new Point(random.Next(230), random.Next(140));
                            flag = true;
                        }
                    }
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
        #region move

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

            }
            else
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
                if (control.Top > controlPrim.Location.Y
                    && control.Top + control.Height < controlPrim.Location.Y + controlPrim.Height
                    && control.Left > controlPrim.Location.X
                    && control.Left + control.Width < controlPrim.Location.X + controlPrim.Width)
                {
                    TypesOfImages downTypeImage = CaptchaPattern;

                    //костыльное условие, почему то инвертируется всё
                    //  MessageBox.Show(control.Name);
                    //if(control.Name == "")
                    //{
                    //    if ((control as ChildComponent.ChildComponent).Accessory)
                    //    {
                    //        control.MouseDown -= new MouseEventHandler(mDown);
                    //        control.MouseUp -= new MouseEventHandler(mUp);
                    //    }
                    //    else
                    //    {
                    //        MessageBox.Show("Ошибка! Всё заново!");
                    //        updateComponent();
                    //        (control as ChildComponent.ChildComponent).RandomLocation = true;
                    //    }
                    //} else
                    //{
                    if (!(control as ChildComponent.ChildComponent).Accessory)
                    {
                        control.MouseDown -= new MouseEventHandler(mDown);
                        control.MouseUp -= new MouseEventHandler(mUp);
                        (control as ChildComponent.ChildComponent).OnPrimaryComponent = true;
                        if (checkIsOver())
                        {
                            MessageBox.Show("Проверка окончена");
                            //это пока
                            Enabled = false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ошибка! Всё заново!");
                        updateComponent();
                        (control as ChildComponent.ChildComponent).RandomLocation = true;
                    }
                    //}


                    #region okOrError
                    ////TryGetValue возвращает всегда ПЕРВЫЙ В СПИСКЕ тип для неправильных элементов 
                    //// Он устанавливается по дефолту
                    ////Неправильные элементы c# не может найти в нашем словаре. Почему ?? Хотя если приходят верные - все ОК 
                    ////Далее ниже идет костыль

                    //if (AllImg.ContainsKey(control.BackgroundImage))
                    //{
                    //    control.MouseDown -= new MouseEventHandler(mDown);
                    //    control.MouseUp -= new MouseEventHandler(mUp);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Ошибка");
                    //    (control as ChildComponent.ChildComponent).RandomLocation = true;
                    //}


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
                    #endregion
                }
            }
            else
            {//проверка что нажата левая кнопка
                return;
            }
        }

        // Функция выполняется при перемещении контрола
        private static void mMove(object sender, MouseEventArgs e)
        {
            if (isPress)
            {
                //только для левой и верхней
                Control control = (Control)sender;
                if (control.Top > 0 && control.Left > 0 &&
                    control.Top + control.Height < 180 && control.Left + control.Width < 400 ||//весь компонент
                    (control.Top <= 0 && control.Left <= 0 && e.X - startPst.X >= 0 && e.Y - startPst.Y >= 0) ||//угл лево верх
                    (control.Top <= 0 && e.Y - startPst.Y >= 0) ||//верх
                    (control.Left <= 0 && e.X - startPst.X >= 0))//лево
                {

                    control.Left += e.X - startPst.X;
                    control.Top += e.Y - startPst.Y;
                }

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
        #endregion
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            updateComponent();
        }


        private void updateComponent()
        {
            RandomLocationChild = true;
            foreach (var elem in childElemlist)
            {
                //elem.MouseDown -= new MouseEventHandler(mDown);
                //elem.MouseUp -= new MouseEventHandler(mUp);
                elem.MouseDown -= new MouseEventHandler(mDown);
                elem.MouseUp -= new MouseEventHandler(mUp);
                elem.MouseMove -= new MouseEventHandler(mMove);
            }
            foreach (var elem in childElemlist)
            {
                LearnToMove(elem);
            }

            foreach (var elem in childElemlist)
            {
                elem.OnPrimaryComponent = false;
            }
        }

        //надо проверить элементы, все ли правильные на главаном
        // как то проверить надо
        private bool checkIsOver()
        {
            int onPrimaryComponent = 0;
            foreach (var elem in childElemlist)
            {
                if (elem.OnPrimaryComponent)
                {
                    onPrimaryComponent++;
                }
            }
            if (onPrimaryComponent == countCorrectChild)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
