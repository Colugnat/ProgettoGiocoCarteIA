using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GiocoCarteIA.Helper;
using GiocoCarteIA.Model;
using Microsoft.Practices.ServiceLocation;

namespace GiocoCarteIA.ViewModel
{
    public class ViewModelLocator
    {
        public static MainViewModel Main
        {
            get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
        }
        public static CameraViewModel Camera
        {
            get { return ServiceLocator.Current.GetInstance<CameraViewModel>(); }
        }
        public static GameIAViewModel GameIA
        {
            get { return ServiceLocator.Current.GetInstance<GameIAViewModel>(); }
        }
        public static GameUserViewModel GameUser
        {
            get { return ServiceLocator.Current.GetInstance<GameUserViewModel>(); }
        }
        public static SettingsViewModel Settings
        {
            get { return ServiceLocator.Current.GetInstance<SettingsViewModel>(); }
        }
        public static StartGameViewModel StartGame
        {
            get { return ServiceLocator.Current.GetInstance<StartGameViewModel>(); }
        }
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CameraViewModel>();
            SimpleIoc.Default.Register<GameIAViewModel>();
            SimpleIoc.Default.Register<GameUserViewModel>();
            SimpleIoc.Default.Register<SettingsViewModel>();
            SimpleIoc.Default.Register<StartGameViewModel>();
        }
    }
}
