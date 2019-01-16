
using Microsoft.Win32;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Controls;
using WebEye.Controls.Wpf;

using AForge;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Math.Geometry;
using System;

namespace ProgettoGiocoCarteIA.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComboBox()
        {
            comboBox.ItemsSource = webCameraControl.GetVideoCaptureDevices();

            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedItem = comboBox.Items[0];
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            startButton.IsEnabled = e.AddedItems.Count > 0;
        }

        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            var cameraId = (WebCameraId)comboBox.SelectedItem;
            webCameraControl.StartCapture(cameraId);
        }

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            webCameraControl.StopCapture();
        }

        private void OnImageButtonClick(object sender, RoutedEventArgs e)
        {
            Bitmap bitmap = null;
            bitmap = (Bitmap)webCameraControl.GetCurrentImage();
            try
            {
                Boolean IsColorFound = false;

                if (bitmap != null)
                {
                    //Converting loaded image into bitmap
                    Bitmap bmp = new Bitmap(bitmap);

                    //Iterate whole bitmap to findout the picked color
                    for (int i = 0; i < bitmap.Height; i++)
                    {
                        for (int j = 0; j < bitmap.Width; j++)
                        {
                            //Get the color at each pixel
                            Color now_color = bmp.GetPixel(j, i);
                            //Compare Pixel's Color ARGB property with the picked color's ARGB property 
                            if (now_color.ToArgb() == Color.Green.ToArgb())
                            {
                                IsColorFound = true;
                                MessageBox.Show("Color green Found!");
                                break;
                            }
                            if (now_color.ToArgb() == Color.Yellow.ToArgb())
                            {
                                IsColorFound = true;
                                MessageBox.Show("Color yellow Found!");
                                break;
                            }
                            if (now_color.ToArgb() == Color.Blue.ToArgb())
                            {
                                IsColorFound = true;
                                MessageBox.Show("Color blue Found!");
                                break;
                            }
                            if (now_color.ToArgb() == Color.Red.ToArgb())
                            {
                                IsColorFound = true;
                                MessageBox.Show("Color red Found!");
                                break;
                            }
                        }
                        if (IsColorFound == true)
                        {
                            break;
                        }
                    }

                    if (IsColorFound == false)
                    {
                        MessageBox.Show("Selected Color Not Found.");
                    }
                }
                else
                {
                    MessageBox.Show("Image is not loaded");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
