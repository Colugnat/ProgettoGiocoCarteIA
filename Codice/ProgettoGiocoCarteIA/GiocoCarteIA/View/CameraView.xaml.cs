using GiocoCarteIA.Model;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using WebEye.Controls.Wpf;

namespace GiocoCarteIA.View
{
    /// <summary>
    /// Interaction logic for cameraView.xaml
    /// </summary>
    public partial class CameraView : UserControl
    {
        public CameraView()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            comboBox.ItemsSource = webCameraControl.GetVideoCaptureDevices();
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedItem = "";
            }
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var x = (WebCameraId)comboBox.SelectedItem;
            webCameraControl.StartCapture(x);
        }
    }
}
