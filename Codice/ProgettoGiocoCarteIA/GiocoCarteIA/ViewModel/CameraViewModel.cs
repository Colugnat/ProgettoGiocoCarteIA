using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GiocoCarteIA.Helper;
using GiocoCarteIA.Model;
using WebEye.Controls.Wpf;

namespace GiocoCarteIA.ViewModel
{
    public class CameraViewModel : BindableBase
    {
        private Camera model;

        private ObservableCollection<String> camere;

        public ObservableCollection<String> Camere
        {
            get { return camere; }
            set { camere = value; }
        }

        private Camera selected;

        public Camera Selected
        {
            get { return selected; }
            set
            {
                ViewModelLocator.CameraId.CameraId = value.CameraId;
                Console.WriteLine("prova" + ViewModelLocator.CameraId.CameraId);
                selected = value;
            }
        }

        public CameraViewModel()
        {
            model = new Camera();
            List<WebCameraId> x = new List<WebCameraId>();
            //Camere = webCameraControl.GetVideoCaptureDevices();
        }
    }
}
