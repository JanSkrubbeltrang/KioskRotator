using BLL.Commands;
using BLL.Interfaces;
using DAL.Factories;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xaml;

namespace BLL.ViewModels
{
    public class ImageViewModel : BaseNotifyModel, IViewViewModel
    {
        public AppViewModel App { get; private set; }

        public IViewViewModel Parent { get; private set; }

        public ImageViewModel(AppViewModel App)
        {
            this.App = App;
            Parent = this;
            images = ImageFactory.GetImageContainer(ImageFactoryType.Basic, App.Settings);
            
            NextImage = new DelegateCommandResolver(SetNextImage);
            timer = new System.Timers.Timer(App.Settings.UpdateInterval * 1000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled = true;
            CurrentImage = images.CurrentImage;
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            SetNextImage();
        }

        private System.Timers.Timer timer;


        private void SetNextImage()
        {
            images.Update();
            CurrentImage = images.NextImage();
        }

        private IImageContainer images;

        public ICommand NextImage { get; private set; }

        private IImage currentImage;
        public IImage CurrentImage
        {
            get { return currentImage; }
            set
            {
                currentImage = value;
                OnPropertyChanged("CurrentImage");
            }
        }
    }
}
