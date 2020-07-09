using DAL.Interfaces;
using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL.Factories
{
    public static class AppSettingFactory
    {
        public static IAppSetting GetAppSetting(string Filename)
        {
            if (Filename.Equals("")||!File.Exists(Filename))
            {
                return null;
            } else
            {
                return LoadSettings(Filename);

            }
        }

        public static void PutAppSettings(AppSettingModel settings, string filename)
        {
            string jsondata = JsonConvert.SerializeObject(settings);
            byte[] rawdata = Encoding.UTF8.GetBytes(jsondata);
            File.WriteAllBytes(filename, rawdata);
        }

        private static IAppSetting GetDefaultValues()
        {
            AppSettingModel setting = new AppSettingModel();
            setting.RunMaximized = false;
            setting.UpdateInterval = 20;
            setting.ImagePath = @"c:\images";
            return setting;
        }

        private static IAppSetting LoadSettings(string Filename)
        {
            try
            {
                string jsondata = File.ReadAllText(Filename);
                return JsonConvert.DeserializeObject<AppSettingModel>(jsondata);
            }
            catch (Exception)
            {
                return GetDefaultValues();
            }
        }
    }
}
