using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IImageContainer
    {
        IImage CurrentImage { get; }
        void Update();
        IImage NextImage();
        IImage PreviousImage();

    }
}
