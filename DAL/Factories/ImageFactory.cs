using DAL.Containers;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Factories
{
    public static class ImageFactory
    {
        public static IEnumerable<IImage> GetImages(ImageFactoryType Type)
        {
            switch (Type)
            {
                case ImageFactoryType.Basic:
                    return null;
                case ImageFactoryType.Json:
                    return null;
                default:
                    return null;
            }
        }

        public static IImageContainer GetImageContainer(ImageFactoryType Type, IAppSetting Settings)
        {
            switch (Type)
            {
                case ImageFactoryType.Basic:
                    return new BasicImageContainer(Settings.ImagePath);
                case ImageFactoryType.Json:
                    return null;
                default:
                    return null;
            }
        }
    }


    public enum ImageFactoryType
    {
        Basic,Json
    }
}
