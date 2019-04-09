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
        /// <summary>
        /// The button for go in the next page, is needed to check if it's possible to go in the next page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextPage_Click(object sender, RoutedEventArgs e)
        {
            if (Camera.CameraId == null)
            {
                MessageBox.Show("Insert a camera for continue the game.");
                Carta.ChooseView = -1;
            }      
        }
        /// <summary>
        /// Check the settings page is possible to use
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NextPage_Click(sender, e);
        }
    }
}
