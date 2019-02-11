
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
using System.Threading;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.Linq;
using System.Windows.Media.Imaging;
using System.IO;

namespace ProgettoGiocoCarteIA.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public const int COUNTNUMCARD = 50;
        public const int MSECONDNUMCARD = 100;
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
        public int TakeNumber()
        {
            int[] finalNum = new int[10];
            for(int i = 0; i < COUNTNUMCARD;  i++)
            {
                Thread.Sleep(MSECONDNUMCARD);
                using (var api = OcrApi.Create())
                {
                    api.SetVariable("tessedit_char_whitelist", "0123456789");
                    api.Init(Languages.English);
                    string plainText = api.GetTextFromImage((Bitmap)webCameraControl.GetCurrentImage());
                    Console.WriteLine("prova" + plainText);
                    for (int y = 0; y < 10; y++)
                    {
                        if(plainText.Contains(y.ToString()))
                        {
                            finalNum[y] += 1;
                        }
                    }
                }
            }
            return finalNum.ToList().IndexOf(finalNum.Max());
        }

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            webCameraControl.StopCapture();
        }
        public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        {
            Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
            Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
            return cropped;
        }
        private void OnImageButtonClick(object sender, RoutedEventArgs e)
        {
            Bitmap bmp = null;
            bmp = (Bitmap)webCameraControl.GetCurrentImage();
            Boolean IsColorFound = false;
            int number = TakeNumber();


            if (bmp != null)
            {
                //Iterate whole bitmap to findout the picked color
                for (int i = 0; i < bmp.Height; i++)
                {
                    for (int j = 0; j < bmp.Width; j++)
                    {
                        //Get the color at each pixel
                        Color now_color = bmp.GetPixel(j, i);
                        //Compare Pixel's Color ARGB property with the picked color's ARGB property 
                        if (now_color.R <= 50 && now_color.G >= 100 && now_color.B <= 50)
                        {
                            IsColorFound = true;
                            MessageBox.Show("Number " + number + ", color green Found!");
                            break;
                        }
                        if (now_color.R >= 100 && now_color.G >= 100 && now_color.B <= 50)
                        {
                            IsColorFound = true;
                            MessageBox.Show("Number " + number + ", color yellow Found!");
                            break;
                        }
                        if (now_color.R <= 50 && now_color.G <= 50 && now_color.B >= 100)
                        {
                            IsColorFound = true;
                            MessageBox.Show("Number " + number + ", color blue Found!");
                            break;
                        }
                        if (now_color.R >= 100 && now_color.G <= 50 && now_color.B <= 50)
                        {
                            IsColorFound = true;
                            MessageBox.Show("Number " + number + ", color red Found!");
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
                    MessageBox.Show("Selected Color Not Found. " + number);
                }
            }
            else
            {
                MessageBox.Show("Image is not loaded");
            }
            
        }
    }
}
