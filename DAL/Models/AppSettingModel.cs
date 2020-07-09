using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class AppSettingModel : IAppSetting
    {
        public string ImagePath { get; set; }
        public int UpdateInterval { get; set; }
        public bool RunMaximized { get; set; }

    }
}
