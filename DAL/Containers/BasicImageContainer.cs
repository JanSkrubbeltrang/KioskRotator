using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DAL.Containers
{
    class BasicImageContainer : IImageContainer
    {
        public BasicImageContainer(string ImagePath)
        {
            images = new List<IImage>();
            currentImageNo = 0;
            imagePath = ImagePath;
            Update();
        }

        private List<IImage> images;

        public void Update()
        {
            IEnumerable<string> files = Directory.EnumerateFiles(imagePath);
            foreach (string file in files)
            {
                IImage Image = new ImageModel { Filename = file };
                if (!images.Contains(Image))
                {
                    images.Add(Image);
                }
            }
            for (int i = images.Count - 1; i > 0; i--)
            {
                if (!File.Exists(images[i].Filename))
                {
                    images.Remove(images[i]);
                }
            }
        }

        private string imagePath;
        private int currentImageNo;

        public IImage CurrentImage
        {
            get { return images[currentImageNo]; }
        }

        public IImage NextImage()
        {
            currentImageNo++;
            currentImageNo = currentImageNo < images.Count ? currentImageNo : 0;
            return CurrentImage;
        }

        public IImage PreviousImage()
        {
            currentImageNo--;
            currentImageNo = currentImageNo > -1 ? currentImageNo : images.Count - 1;
            return CurrentImage;
        }
    }
}
