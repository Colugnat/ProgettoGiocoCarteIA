using GiocoCarteIA.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiocoCarteIA.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private BindableBase currentViewModelBase;

        public BindableBase CurrentViewModel
        {
            get { return currentViewModelBase; }
            set
            {
                SetProperty(ref currentViewModelBase, value);
            }
        }
        public IDelegateCommand NextPage { get; private set; }
        public IDelegateCommand CameraPageCommand { get; private set; }
        public IDelegateCommand GameIAPageCommand { get; private set; }
        public IDelegateCommand GameUserPageCommand { get; private set; }
        public IDelegateCommand SettingsPageCommand { get; private set; }
        public IDelegateCommand StartGamePageCommand { get; private set; }
        private int ChooseView = 0;
        public MainViewModel()
        {
            NextPage = new DelegateCommand(OnNextPage, CanNextPage);
            CameraPageCommand = new DelegateCommand(OnCameraPage, CanCameraPage);
            GameIAPageCommand = new DelegateCommand(OnGameIAPage, CanGameIAPage);
            GameUserPageCommand = new DelegateCommand(OnGameUserPage, CanGameUserPage);
            SettingsPageCommand = new DelegateCommand(OnSettingsPage, CanSettingsPage);
            StartGamePageCommand = new DelegateCommand(OnStartGamePage, CanStartGamePage);
            CurrentViewModel = ViewModelLocator.Camera;
        }

        private bool CanNextPage(object arg)
        {
            return true;
        }

        private void OnNextPage(object obj)
        {
            ChooseView += 1;
            if(ChooseView == 1)
            {
                CurrentViewModel = ViewModelLocator.StartGame;
            }
        }

        private bool CanCameraPage(object arg)
        {
            return true;
        }

        private void OnCameraPage(object obj)
        {
            CurrentViewModel = ViewModelLocator.Camera;
        }

        private bool CanGameIAPage(object arg)
        {
            return true;
        }

        private void OnGameIAPage(object obj)
        {
            CurrentViewModel = ViewModelLocator.GameIA;
        }

        private bool CanGameUserPage(object arg)
        {
            return true;
        }

        private void OnGameUserPage(object obj)
        {
            CurrentViewModel = ViewModelLocator.GameUser;
        }

        private bool CanSettingsPage(object arg)
        {
            return true;
        }

        private void OnSettingsPage(object obj)
        {
            CurrentViewModel = ViewModelLocator.Settings;
        }

        private bool CanStartGamePage(object arg)
        {
            return true;
        }
        private void OnStartGamePage(object obj)
        {
            CurrentViewModel = ViewModelLocator.StartGame;
        }
    }
}
