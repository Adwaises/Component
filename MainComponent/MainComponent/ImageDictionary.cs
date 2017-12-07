using MainComponent.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainComp
{
    public class ImageDictionary : Dictionary<Image, TypesOfImages>
    {
        //Картинки Primary компонента
        public Image primaryFace;
        public Image primaryRefriger;
        public Image primaryFlower;
        public Image primaryCustomImg;

        public Image BackgroundFace;
        public Image BackgroundRefriger;
        public Image BackgroundFlower;
        public Image BackgroundCustom;

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
            return imgsNonType.Images[MainComponent.random.Next(0, imgsNonType.Images.Count - 1)];
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

    }
}
