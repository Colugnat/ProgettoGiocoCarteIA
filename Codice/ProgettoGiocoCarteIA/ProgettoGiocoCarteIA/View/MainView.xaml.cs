
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
            TakeNumber();
        }
        public void TakeNumber()
        {
            while(true)
            {
                Thread.Sleep(1000);
                //Bitmap image = new Bitmap(webCameraControl.GetCurrentImage());
                //Tesseract ocr = new Tesseract();
                //ocr.SetVariable("tessedit_char_whitelist", "0123456789"); // If digit only
                //ocr.Init(@"C:\OCRTest\tessdata\", "eng", false); // To use correct tessdata
                //List<tessnet2.Word> result = ocr.DoOCR(image, Rectangle.Empty);
                //foreach (tessnet2.Word word in result)
                //    Console.WriteLine("{0} : {1}", word.Confidence, word.Text);
                using (var api = OcrApi.Create())
                {
                    api.SetVariable("tessedit_char_whitelist", "0123456789");
                    api.Init(Languages.English);
                    string plainText = api.GetTextFromImage((Bitmap)webCameraControl.GetCurrentImage());
                    Console.WriteLine("prova" + plainText);
                }
            }
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
            Bitmap bitmap = null;
            bitmap = (Bitmap)webCameraControl.GetCurrentImage();
            Boolean IsColorFound = false;



            if (bitmap != null)
            {
                //Converting loaded image into bitmap
                Bitmap bmp = new Bitmap(bitmap);

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
                            MessageBox.Show("Color green Found!");
                            break;
                        }
                        if (now_color.R >= 100 && now_color.G >= 100 && now_color.B <= 50)
                        {
                            IsColorFound = true;
                            MessageBox.Show("Color yellow Found!");
                            break;
                        }
                        if (now_color.R <= 50 && now_color.G <= 50 && now_color.B >= 100)
                        {
                            IsColorFound = true;
                            MessageBox.Show("Color blue Found!");
                            break;
                        }
                        if (now_color.R >= 100 && now_color.G <= 50 && now_color.B <= 50)
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
    }
}
