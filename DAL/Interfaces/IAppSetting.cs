using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IAppSetting
    {
        string ImagePath { get; set; }
        int UpdateInterval { get; set; }
        bool RunMaximized { get; set; }
    }
}
