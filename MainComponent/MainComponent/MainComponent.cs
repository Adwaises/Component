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


public enum TypesOfImages { Face, Refrigerator, Flower, Custom }

namespace MainComp
{

    public partial class MainComponent : UserControl
    {
        public static Random random = new Random();

        private PictureBox pictureBox = null;
        private List<ChildComponent.ChildComponent> childElemlist;

        //переменные основного компонента
        private string textHelp = "Text\r\nhelp";
        private int errorNumber = 3;
        private int countNonCorrectChild = 3;
        private int countCorrectChild = 3;

        private static TypesOfImages typeImages = TypesOfImages.Face;

        private Color colorLine = Color.Blue;
       
        public MainComponent()
        {          
            SuspendLayout();
            InitializeComponent();

            //Load Help Buttons
            pictureBox1.BackgroundImage = Resources.help_web_button;
            pictureBox2.BackgroundImage = Resources.update;

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

            //Загрузка картинок в зависимости от установленного TypesOfImages 

            //Задает изображение для primary-компонента
            SetPrimaryAndBackgroundImage(typeImages);
            //Задает изображение для child-компонентов
            SetChildsImages(typeImages);

            //После загрузки - перемещение
            childElemlist.Reverse();
            foreach (var elem in childElemlist)
            {
                LearnToMove(elem);
            }

            Invalidate();
        }

        //Хранит все картинки для дочерних элементов
        //вместе с их принадлежностью (из нумератора) 
        //+ картинки для праймари компонента
        ImageDictionary PatternImgResources = new ImageDictionary();
        
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
                SetPrimaryAndBackgroundImage(typeImages);
                SetChildsImages(typeImages);

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
        
        private void LoadFiles(string path, bool accessory)
        {
            if (!string.IsNullOrEmpty(path))
            {
                List<string> PathChildFace = new List<string>();
                try
                {
                    //а это метод который тащит все существующие файлы из директории

                    DirectoryInfo di = new DirectoryInfo(path);

                    FileInfo[] fi = di.GetFiles("*.png");

                    //MessageBox.Show(@pathNoRightChildPicture);
                    foreach (FileInfo fc in fi)
                    {
                        PathChildFace.Add(path + "\\" + fc.Name);
                    }
                    // MessageBox.Show("" + PathChildFace.Count);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }

                //добавление на фон
                int i = 0;
                foreach (var elem in childElemlist)
                {
                    if (!elem.Accessory.Equals(accessory))
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
        }


        private string pathWrongChildPicture = "";
        [Category("ChildComponent"), Description("Specifies the path picture of no right child component.")]
        public string PathWrongChildPicture
        {
            get
            { return pathWrongChildPicture; }
            set
            {
                if (isPath(value))
                {
                    pathWrongChildPicture = value;
                    LoadFiles(pathWrongChildPicture, false);
                }
                else
                {
                    pathWrongChildPicture = "";
                   // SetImagesFromType(typeImages); //инвертирует всё (true становится false)
                }
                Invalidate();
            }
        }

        private string pathRightChildPicture = "";
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
                   
                } else
                {
                    pathRightChildPicture = "";
                   // SetImagesFromType(typeImages);
                
                
                }

                Invalidate();
                this.Refresh();
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


        //Set picture
        private void SetPrimaryAndBackgroundImage(TypesOfImages typeImg)
        {
            if (typeImg == TypesOfImages.Face)
            {
                primaryComponent1.BackgroundImage = PatternImgResources.primaryFace;
                this.BackgroundImage = PatternImgResources.BackgroundFace;
            }
            else if (typeImg == TypesOfImages.Refrigerator)
            {
                primaryComponent1.BackgroundImage = PatternImgResources.primaryRefriger;
                this.BackgroundImage = PatternImgResources.BackgroundRefriger;
            }
            else if (typeImg == TypesOfImages.Flower)
            {
                primaryComponent1.BackgroundImage = PatternImgResources.primaryFlower;
                this.BackgroundImage = PatternImgResources.BackgroundFlower;
            }
            else if (typeImg == TypesOfImages.Custom)
            {
                primaryComponent1.BackgroundImage = PatternImgResources.primaryCustomImg;
                this.BackgroundImage = PatternImgResources.BackgroundFace;
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

        #region Property and events

        /// <summary>
        /// Свойства дочернего компонента
        /// </summary>

        ////чтоб смотреть лист //Пока не удалять
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

        //[Category("PrimaryComponent"), Description("Specifies the location of primary element.")]
        //public Point LocationPrimary
        //{
        //    get { return primaryComponent1.Location; }
        //    set
        //    {
        //        primaryComponent1.Location = value;
        //        Invalidate();
        //    }
        //}

        //[Category("PrimaryComponent"), Description("Specifies the size of primary element.")]
        //public Size SizePrimary
        //{
        //    get { return primaryComponent1.Size; }
        //    set
        //    {
        //        primaryComponent1.Size = value;
        //        Invalidate();
        //    }
        //}

        /// <summary>
        /// Свойства основного коспонента
        /// </summary>

        //[Category("Component"), Description("Specifies the random point of child element.")]
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


        private bool result = false;
        public bool Result
        {
            get
            { return result; }
            //set
            //{
            //    result = value;
            //    Invalidate();
            //}
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
                    child.BackgroundImage = PatternImgResources.GetRandomWrongImage(typeImages);
                }
                // Рандомим позицию

                child.Location = newPoint();
                //определяем не наложились ли элементы
                //bool flag = true;
                //while (flag)
                //{
                //    flag = false;
                //    foreach (var elem in childElemlist)
                //    {
                //        if (Math.Abs((elem.Location.X + 13) - (child.Location.X + 13)) < 35 &&
                //            Math.Abs((elem.Location.Y + 13) - (child.Location.Y + 13)) < 35 ||
                //            child.Location.X < 5 || child.Location.Y < 5 || child.Location.Y > 140)
                //        {
                //            child.Location = new Point(random.Next(230), random.Next(140));
                //            flag = true;
                //        }
                //    }
                //}


                Controls.Add(child);
                childElemlist.Add(child);
                LearnToMove(child);
            }
        }

        private Point newPoint()
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

        private Image FindNewCorrectImage()
        {
            //Проход по всей коллекции картинок
            foreach (var elem in PatternImgResources)
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
       // static Control controlTemp;
        static Point location_0;
        // Функция выполняется при нажатии на перемещаемый контрол
        private static void mDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control control = (Control)sender;
                //запоминаем компонент который тянем 
              //  controlTemp = control;
                isPress = true;
                startPst = e.Location;
                location_0 = new Point(Cursor.Position.X - e.Location.X - control.Location.X, Cursor.Position.Y - e.Location.Y - control.Location.Y); 
               

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

                    /*
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
                    //{*/

                    if (!(control as ChildComponent.ChildComponent).Accessory)
                    {
                        control.MouseDown -= new MouseEventHandler(mDown);
                        control.MouseUp -= new MouseEventHandler(mUp);
                        (control as ChildComponent.ChildComponent).OnPrimaryComponent = true;

                        //Привязываем дочерний к праймари компоненту для прозрачного отображения
                        Point oldPoint = control.Location;

                        control.Parent = primaryComponent1;              
                        control.Location = new Point(oldPoint.X - primaryComponent1.Location.X, 
                            oldPoint.Y - primaryComponent1.Location.Y);


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
               
                Control control = (Control)sender;
                //не даем выйти курсору когда он тянет элемент
                if (Cursor.Position.X - e.X <= location_0.X) {
                    Cursor.Position =new Point( location_0.X +1 + e.X, Cursor.Position.Y);
                }
                if (Cursor.Position.Y - e.Y<= location_0.Y)
                {
                    Cursor.Position = new Point(Cursor.Position.X, location_0.Y + 1 + e.Y);
                }
                if (Cursor.Position.X +(control.Width- e.X )>= location_0.X+400)
                {
                    Cursor.Position = new Point(location_0.X+400 - 1- (control.Width - e.X), Cursor.Position.Y);
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
            UpdateComponent();
        }


        private void UpdateComponent()
        {            
            foreach (var elem in childElemlist)
            {
                elem.Parent = this;

                //elem.MouseDown -= new MouseEventHandler(mDown);
                //elem.MouseUp -= new MouseEventHandler(mUp);
                elem.MouseDown -= new MouseEventHandler(mDown);
                elem.MouseUp -= new MouseEventHandler(mUp);
                elem.MouseMove -= new MouseEventHandler(mMove);

                //primaryComponent1.Controls.Remove(elem);
                //this.Controls.Add(elem);
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

        private bool checkError()
        {
           if(ErrorNumber < 2)
            {
                return true;
            }
            else
            {
                return false;
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
    }
}
