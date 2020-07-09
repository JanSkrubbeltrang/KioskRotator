using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ImageModel: AImageModel, IImage
    {
        public string Filename { get; set; }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Filename.GetHashCode();
        }
    }
}
