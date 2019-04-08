using GiocoCarteIA.Model;
using GiocoCarteIA.ViewModel;
using ObjectRecognition;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WebEye.Controls.Wpf;

namespace GiocoCarteIA.View
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (Camera.CameraId == null)
            {
                MessageBox.Show("Insert a camera for continue the game.");
                Carta.ChooseView = -1;
            }
                
        }
    }
}
