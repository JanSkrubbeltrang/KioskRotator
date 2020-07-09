using BLL.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IViewViewModel
    {
        AppViewModel App { get; }
        IViewViewModel Parent { get; }
    }
}
