using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public abstract class AImageModel
    {
        public abstract override bool Equals(object obj);
        public abstract override int GetHashCode();

    }
}
