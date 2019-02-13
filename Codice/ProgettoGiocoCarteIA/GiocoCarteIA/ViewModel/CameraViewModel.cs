using System;
using GiocoCarteIA.Helper;
using GiocoCarteIA.Model;

namespace GiocoCarteIA.ViewModel
{
    public class CameraViewModel : BindableBase
    {
        public IDelegateCommand OkCameraCommand { get; protected set; }
        public CameraViewModel()
        {
            RegisterCommands();
        }

        private void RegisterCommands()
        {
            OkCameraCommand = new DelegateCommand(OnOkCamera, CanOkCamera);
        }

        private bool CanOkCamera(object arg)
        {
            return true;
        }

        private void OnOkCamera(object obj)
        {
            SetProperty(ref Game.currentViewModelBase, ViewModelLocator.StartGame);
        }
    }
}
