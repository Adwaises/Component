using MainComponent.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HumanVerification
{
    public class ImageDictionary : Dictionary<Image, TypesOfImages>
    {
        //Картинки Primary компонента
        public Image primaryFace { get; set; }
        public Image primaryRefriger { get; set; }
        public Image primaryFlower { get; set; }
        public Image primaryCustomImg { get; set; }

        public Image BackgroundFace { get; set; }
        public Image BackgroundRefriger { get; set; }
        public Image BackgroundFlower { get; set; }
        public Image BackgroundCustom { get; set; }

        public ImageDictionary()
        {
            BackgroundFace = Resources.backgroundFace;
            BackgroundRefriger = Resources.backgroundRefriger;
            BackgroundFlower = Resources.backgroundFlower;
            BackgroundCustom = null;

            primaryFace = Resources.face;
            primaryFlower = Resources.vase;
            primaryRefriger = Resources.refrigerator;

            this.Add(Resources.happyEyes as Bitmap, TypesOfImages.Face);
            this.Add(Resources.nose as Bitmap, TypesOfImages.Face);
            this.Add(Resources.mouth as Bitmap, TypesOfImages.Face);
            this.Add(Resources.moustache as Bitmap, TypesOfImages.Face);
            this.Add(Resources.reading_glasses as Bitmap, TypesOfImages.Face);

            this.Add(Resources.meat as Bitmap, TypesOfImages.Refrigerator);
            this.Add(Resources.cheese as Bitmap, TypesOfImages.Refrigerator);
            this.Add(Resources.jelly as Bitmap, TypesOfImages.Refrigerator);
            this.Add(Resources.water as Bitmap, TypesOfImages.Refrigerator);
            this.Add(Resources.can as Bitmap, TypesOfImages.Refrigerator);
            this.Add(Resources.carrot as Bitmap, TypesOfImages.Refrigerator);

            this.Add(Resources.rose as Bitmap, TypesOfImages.Flower);
            this.Add(Resources.sunflower as Bitmap, TypesOfImages.Flower);
            this.Add(Resources.rose_1 as Bitmap, TypesOfImages.Flower);
            this.Add(Resources.poppy as Bitmap, TypesOfImages.Flower);
            this.Add(Resources.roses as Bitmap, TypesOfImages.Flower);
        }

        //Возвращает рандомную картинку в соотвествии с аргементом
        public Image GetRandomWrongImage(TypesOfImages exceptionTypeImg)
        {
            //Лист для всех элементов кроме пришедшей переменной 
            ImageList imgsNonType = new ImageList();
            imgsNonType.ImageSize = new Size(32, 32);

            foreach (var elem in this)
            {
                if (!elem.Value.Equals(exceptionTypeImg))
                {
                    imgsNonType.Images.Add(elem.Key);
                }
            }

            //Image newImage = imgsNonType.Images[random.Next(0, imgsNonType.Images.Count - 1)];
            //Возвращает рандомный элемент из списка
            return imgsNonType.Images[HumanVerification.random.Next(0, imgsNonType.Images.Count - 1)];
        }

        public List<Image> GetImageListFromPattern(TypesOfImages typeImg)
        {
            // Проход по всем картинкам и выборка изображений данного типа
            var newImageList = new List<Image>();

            foreach (var elem in this)
            {
                if (elem.Value == typeImg)
                {
                    newImageList.Add(elem.Key);
                }
            }
            return newImageList;
        }

        public Image FindNewCorrectImage(TypesOfImages typeImg, List<ChildComponent.ChildComponent> listChild)
        {
            //Проход по всей коллекции картинок
            foreach (var elem in this)
            {
                //Если тип картинки в коллекции совпадает с текущим шаблоном капчи
                if (elem.Value == typeImg)
                {
                    //Проход по всем дочерним элементам с целью найти не использованное изображение
                    for (int i = 0; i < listChild.Count; i++)
                    {
                        if (!listChild[i].BackgroundImage.Equals(elem.Key))
                        {
                            return elem.Key;
                        }
                    }
                }
            }

            return null;
        }

    }
}
