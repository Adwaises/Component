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
using EnvDTE;
using EnvDTE80;

public enum TypesOfImages { Face, Refrigerator, Flower }

namespace HumanVerification
{

    public partial class HumanVerification : UserControl
    {
        public static Random random = new Random();
        private PictureBox pictureBox = null;
        private List<ChildComponent.ChildComponent> childElemlist;

        //переменные основного компонента
        private string textHelp = "Text\r\nhelp";
        private int errorNumber = 3;
        private int countNonCorrectChild = 3;
        private int countCorrectChild = 3;
        private Color colorLine = Color.Blue;
        private bool result = false;
        private int minChildNumber = 1;
        private int maxChildNumber = 7;

        private string pathRightChildPicture = String.Empty;
        private string pathWrongChildPicture = String.Empty;

        private static TypesOfImages typeImages = TypesOfImages.Face;


        //Хранит все картинки для дочерних элементов
        //вместе с их принадлежностью (из нумератора) 
        //+ картинки для праймари компонента
        ImageDictionary PatternImgResources = new ImageDictionary();

        public HumanVerification()
        {
            SuspendLayout();
            InitializeComponent();

            //Load Help Buttons
            pictureBox1.BackgroundImage = Resources.help_web_button;
            pictureBox2.BackgroundImage = Resources.update;

            pictureBox = new PictureBox();
            pictureBox.Invalidate(true);
            pictureBox.Size = new Size(400, 180);

            //создание списка дочерних элементов и его заполение
            childElemlist = new List<ChildComponent.ChildComponent>();
            foreach (var elem in this.Controls)
            {
                if (elem is ChildComponent.ChildComponent)
                {
                    ChildComponent.ChildComponent ch = elem as ChildComponent.ChildComponent;
                    childElemlist.Add(ch);
                }
            }
            ToPosition(this.primaryComponent1);

            //Загрузка картинок в зависимости от установленного TypesOfImages 
            SetImagesFromType(typeImages);

            //После загрузки - перемещение
            childElemlist.Reverse();
            foreach (var elem in childElemlist)
            {
                LearnToMove(elem);
            }

            Invalidate();
        }


        /// <summary>
        /// загружает файлы из директории
        /// </summary>
        /// <param name="path"></param>
        /// <param name="accessory"></param>
        private void LoadFiles(string path, bool accessory)
        {
            if (string.IsNullOrEmpty(path))
                return;
           
            List<string> PathChildFace = new List<string>();

            //а это метод который тащит все существующие файлы из директории
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] fi = di.GetFiles("*.png");
            foreach (FileInfo fc in fi)
            {
                PathChildFace.Add(path + "\\" + fc.Name);
            }

            //добавление на фон
            int i = 0;
            foreach (var elem in childElemlist)
            {
                if (elem.Accessory.Equals(accessory))
                {
                    if (PathChildFace.Count >= i)
                    {
                        elem.BackgroundImage = Image.FromFile(PathChildFace[i]);
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                }
            }
        }



        /// <summary>
        /// Проверяет строку на путь
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool isPath(string str)
        {
            if (!String.IsNullOrEmpty(str) && str.Length > 2)
            {
               
                if (!str.Substring(1, 2).Equals(":\\"))
                {
                    MessageBox.Show("Неверно указан путь");
                    return false;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        private void SetImagesFromType(TypesOfImages typeImg)
        {
            SetPrimaryAndBackgroundImage(typeImg);
            SetChildsImages(typeImg);
        }

        //Set picture
        private void SetPrimaryAndBackgroundImage(TypesOfImages typeImg)
        {
            if (typeImg == TypesOfImages.Face)
            {
                primaryComponent1.BackgroundImage = PatternImgResources.primaryFace;
                this.BackgroundImage = PatternImgResources.BackgroundFace;
                TextHelp = "С помощью мыши перетащите элементы, чтобы собрать изображение лица";
            }
            else if (typeImg == TypesOfImages.Refrigerator)
            {
                primaryComponent1.BackgroundImage = PatternImgResources.primaryRefriger;
                this.BackgroundImage = PatternImgResources.BackgroundRefriger;
                TextHelp = "С помощью мыши перетащите всё продукты в холодильник";
            }
            else if (typeImg == TypesOfImages.Flower)
            {
                primaryComponent1.BackgroundImage = PatternImgResources.primaryFlower;
                this.BackgroundImage = PatternImgResources.BackgroundFlower;
                TextHelp = "С помощью мыши перетащите всё цветы в вазу";
            }

        }

        private void SetChildsImages(TypesOfImages typeImg)
        {
            // Проход по всем картинкам и выборка изображений данного типа
            var newImageList = PatternImgResources.GetImageListFromPattern(typeImg);

            //Задает дочерним компонентам изображение из нового списка
            //Пока картинки есть и дочерние компоненты => делаем присваивание
            int i = 0;
            //Добавление подходящих компонентов
            for (int p = 0; p < CountCorrectChild; p++)
            {
                childElemlist[i].BackgroundImage = newImageList[p];
                i++;
            }

            //Добавление неправильных компонентов
            for (int j = 0; j < CountNonCorrectChild; j++)
            {
                childElemlist[i].BackgroundImage = PatternImgResources.GetRandomWrongImage(typeImages);
                i++;
            }
        }

        /// <summary>
        /// Метод удаления дочернего элемента с формы и листа
        /// </summary>
        /// <param name="n"></param>
        private void deleteChild(int countDeleteChild, bool isCorrectChild)
        {
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
                    if (Controls[i].BackgroundImage == childElemlist[index].BackgroundImage)
                    {
                        indexControl = i;
                    }
                }

                this.childElemlist.RemoveAt(index);
                this.Controls.RemoveAt(indexControl);
                Invalidate();
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
                ChildComponent.ChildComponent child;

                //Если нужно добавить верный дочерний элемент
                if (isCorrectChild)
                {
                    child = new ChildComponent.ChildComponent();
                    child.Accessory = true;
                    child.BackgroundImage = PatternImgResources.FindNewCorrectImage(typeImages, childElemlist);
                }
                else
                {
                    child = new ChildComponent.ChildComponent();
                    child.Accessory = false;
                    child.BackgroundImage = PatternImgResources.GetRandomWrongImage(typeImages);
                }
                // Рандомим позицию
                child.Location = RandomNewPoint();
                Controls.Add(child);
                childElemlist.Add(child);
                LearnToMove(child);
            }
        }

        /// <summary>
        /// метод, вощвращающий координату дочернего элемента
        /// </summary>
        /// <returns></returns>
        private Point RandomNewPoint()
        {
            Random rand = new Random();
            Point point = new Point(rand.Next(230), rand.Next(150));
            //определяем не наложились ли элементы
            bool flag = true;
            while (flag)
            {
                flag = false;
                foreach (var elem in childElemlist)
                {
                    if (Math.Abs((elem.Location.X + 13) - (point.X + 13)) < 30 &&
                        Math.Abs((elem.Location.Y + 13) - (point.Y + 13)) < 30 ||
                        point.X < 5 || point.Y < 5 || point.Y > 140)
                    {
                        point = new Point(rand.Next(230), rand.Next(140));
                        flag = true;
                    }
                }
            }
            return point;
        }

        /// <summary>
        /// Переопределение метода отрисовки
        /// </summary>
        /// <param name="e"></param>
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
        // static Control controlTemp;
        static Point location_0;
        // Функция выполняется при нажатии на перемещаемый контрол
        private static void mDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                //запоминаем компонент который тянем 
                isPress = true;
                startPst = e.Location;
                location_0 = new Point(Cursor.Position.X - e.Location.X - control.Location.X, Cursor.Position.Y - e.Location.Y - control.Location.Y);
            }

            return;
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

                    if ((control as ChildComponent.ChildComponent).Accessory)
                    {
                        control.MouseDown -= new MouseEventHandler(mDown);
                        control.MouseUp -= new MouseEventHandler(mUp);
                        (control as ChildComponent.ChildComponent).OnPrimaryComponent = true;

                        //Привязываем дочерний к праймари компоненту для прозрачного отображения
                        Point oldPoint = control.Location;

                        control.Parent = primaryComponent1;
                        control.Location = new Point(oldPoint.X - primaryComponent1.Location.X,
                            oldPoint.Y - primaryComponent1.Location.Y);

                        //MessageBox.Show((control as ChildComponent.ChildComponent).Accessory.ToString());

                        if (checkIsOver())
                        {
                            MessageBox.Show("Проверка окончена");
                            result = true;
                            //это пока
                            Enabled = false;
                            //надо как то вернуть значение истины!
                        }
                    }
                    else
                    {
                        if (checkError())
                        {
                            MessageBox.Show("Вы допустили слишком много ошибок");
                            Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Ошибка! Всё заново!");
                            errorNumber--;
                            UpdateComponent();
                            (control as ChildComponent.ChildComponent).RandomLocation = true;
                        }
                    }
                }
            }

            return;
        }

        // Функция выполняется при перемещении контрола
        private static void mMove(object sender, MouseEventArgs e)
        {
            if (isPress)
            {
                Control control = (Control)sender;
                //не даем выйти курсору когда он тянет элемент
                if (Cursor.Position.X - e.X <= location_0.X)
                {
                    Cursor.Position = new Point(location_0.X + 1 + e.X, Cursor.Position.Y);
                }
                if (Cursor.Position.Y - e.Y <= location_0.Y)
                {
                    Cursor.Position = new Point(Cursor.Position.X, location_0.Y + 1 + e.Y);
                }
                if (Cursor.Position.X + (control.Width - e.X) >= location_0.X + 400)
                {
                    Cursor.Position = new Point(location_0.X + 400 - 1 - (control.Width - e.X), Cursor.Position.Y);
                }
                if (Cursor.Position.Y + (control.Height - e.Y) >= location_0.Y + 180)
                {
                    Cursor.Position = new Point(Cursor.Position.X, location_0.Y + 180 - 1 - (control.Height - e.Y));
                }

                control.Left += e.X - startPst.X;
                control.Top += e.Y - startPst.Y;
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
        }
        #endregion
        /// <summary>
        /// вызов подсказки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pictureBox1, textHelp);
            toolTip1.IsBalloon = true;
        }

        /// <summary>
        /// вызов обновления компонента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            UpdateComponent();
        }

        /// <summary>
        /// Мето обновления компонента
        /// </summary>
        private void UpdateComponent()
        {
            foreach (var elem in childElemlist)
            {
                elem.Parent = this;
                elem.MouseDown -= new MouseEventHandler(mDown);
                elem.MouseUp -= new MouseEventHandler(mUp);
                elem.MouseMove -= new MouseEventHandler(mMove);
            }

            RandomLocationChild = true;

            foreach (var elem in childElemlist)
            {
                LearnToMove(elem);
            }

            foreach (var elem in childElemlist)
            {
                elem.OnPrimaryComponent = false;
            }
        }

        /// <summary>
        /// Проверяет завершена ли проверка
        /// </summary>
        /// <returns></returns>
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

            return false;
        }

        /// <summary>
        /// Проверяет кол-во ошибок
        /// </summary>
        /// <returns></returns>
        private bool checkError()
        {
            if (ErrorNumber < 2)
            {
                return true;
            }

            return false;
        }


        #region Property and events

        /// <summary>
        /// Свойства дочернего компонента
        /// </summary>

        //путь к директории не правильных дочерних элементов
        [Category("ChildComponent"), Description("Specifies the path picture of no right child component.")]
        public string PathWrongChildPicture
        {
            get
            { return pathWrongChildPicture; }
            set
            {
               
                if (isPath(value))
                {
                    //Если путь верен отображаем картинки из папки
                    pathWrongChildPicture = value;
                    LoadFiles(pathWrongChildPicture, false);
                }
                else
                {
                    //Иначе - подгрузка из шаблонов
                    pathWrongChildPicture = String.Empty;
                    SetImagesFromType(typeImages);
                }
                Invalidate();
            }
        }

        //путь к директории для правильных дочерних элементов
        [Category("ChildComponent"), Description("Specifies the path picture of right child component.")]
        public string PathRightChildPicture
        {
            get
            { return pathRightChildPicture; }
            set
            {
                if (isPath(value))
                {
                    
                    pathRightChildPicture = value;
                    LoadFiles(pathRightChildPicture, true);
                }
                else
                {
                    pathRightChildPicture = String.Empty;
                    SetImagesFromType(typeImages);
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Свойства Главного компонента
        /// </summary>

        //фон главного компонента
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

        /// <summary>
        /// Свойства основного коспонента
        /// </summary>

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

                //Загрузка картинок в зависимости от установленного TypesOfImages 
                SetImagesFromType(typeImages);

                Invalidate();
            }
        }



        // рандомит все элеметы
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
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

        //цвет отводки компонента
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

        //количество ошибок
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

        //свойсво определяющее количество правильных дочерних элементов
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

                //Добавлять или удалять элементы?
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

        //количество не правильных дочерних элементов
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

        //помощь
        [Category("Component"), Description("Specifies the text help of component.")]
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

        //свойство результата (задать его может только сам компонент)
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Result
        {
            get
            { return result; }
        }


        #endregion

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

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoScroll
        {
            get { return false; }
            set { AutoScroll = false; }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AutoSize
        {
            get { return false; }
            set { AutoSize = false; }
        }

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


        // скрываем события

        #endregion

        #region DeleteEvents
        //залоченные события
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Paint
        {
            add { }
            remove { }
        }



        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler MouseCaptureChanged
        {
            add { }
            remove { }
        }



        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler Scroll
        {
            add { }
            remove { }
        }


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
    }
}
