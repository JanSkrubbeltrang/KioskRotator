using BLL.Interfaces;
using DAL.Factories;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.ViewModels
{
    public class AppViewModel : BaseNotifyModel
    {
		public AppViewModel()
		{
			Settings = AppSettingFactory.GetAppSetting("Settings.json");
			CurrentViewModel = new ImageViewModel(this);
		}

		private IViewViewModel currentViewModel;

		public IViewViewModel CurrentViewModel
		{
			get { return currentViewModel; }
			set 
			{ 
				currentViewModel = value;
				OnPropertyChanged("CurrentView");
			}
		}
		
		public IAppSetting Settings { get; private set; }

	}
}
