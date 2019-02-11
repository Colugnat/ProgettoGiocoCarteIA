
using Microsoft.Win32;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows;
using System.Windows.Controls;
using WebEye.Controls.Wpf;

using System;
using System.Threading;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.Linq;
using System.Windows.Media.Imaging;
using ObjectRecognition;
using System.Windows.Interop;
using System.Windows.Media;
using System.IO;

namespace ProgettoGiocoCarteIA.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        //public const int COUNTNUMCARD = 50;
        //public const int MSECONDNUMCARD = 100;
        public MainView()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        public BitmapImage Convert(System.Drawing.Image img)
        {
            using (var memory = new MemoryStream())
            {
                img.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();

                return bitmapImage;
            }
        }

        private BitmapImage learningImage = null;
        private BitmapImage backgroundImage = null;
        private BitmapImage identificationImage = null;

        private void LearningImageOneButton_Click(object sender, RoutedEventArgs e)
        {

            backgroundImage = Convert(LearningImageOne.GetCurrentImage());
        }

        private void LearningImageTwoButton_Click(object sender, RoutedEventArgs e)
        {
            learningImage = Convert(LearningImageOne.GetCurrentImage());
            this.LearningImageTwo.Source = learningImage;
        }

        private void AnalyzeImageButton_Click(object sender, RoutedEventArgs e)
        {
            identificationImage = Convert(LearningImageOne.GetCurrentImage());
            this.AnalysisImage.Source = identificationImage;
        }

        private void LearnObjectButton_Click(object sender, RoutedEventArgs e)
        {
            string objectName = this.ObjectNameText.Text;
            if (objectName.Length == 0)
            {
                MessageBox.Show("Please give the item a name");
            }
            else if (learningImage == null || backgroundImage == null)
            {
                MessageBox.Show("Please select a background image and an image with the object to learn");
            }
            else
            {
                ObjectLearningServices.LearnObject(learningImage, backgroundImage, objectName);
                PopulateLearnedItemsList();
            }
        }

        private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        {
            if (identificationImage == null)
            {
                MessageBox.Show("Please select an image to analyze");
            }
            else
            {
                IList<string> identifiedObjects = ObjectIdentificationService.AnalyzeImage(identificationImage);
                this.AnalysisResultsText.Text = "";

                foreach (string objectName in identifiedObjects)
                {
                    this.AnalysisResultsText.Text = this.AnalysisResultsText.Text + ("May contain " + objectName + "\r\n");
                }

                if (identifiedObjects.Count == 0)
                {
                    this.AnalysisResultsText.Text = "Did not recognize anything";
                }
            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            PopulateLearnedItemsList();
        }

        private void DeleteObjectButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.LearnedObjectsList.SelectedIndex != -1)
            {
                string objectName = (string)this.LearnedObjectsList.SelectedItem;
                ObjectMemoryService.RemoveSignatureByName(objectName);
                PopulateLearnedItemsList();
            }
            else
            {
                MessageBox.Show("Please select an item to delete");
            }
        }

        private void PopulateLearnedItemsList()
        {
            List<ObjectSignatureData> learnedObjects = ObjectMemoryService.GetSignatures();
            this.LearnedObjectsList.Items.Clear();
            foreach (ObjectSignatureData objectSignatureData in learnedObjects)
            {
                this.LearnedObjectsList.Items.Add(objectSignatureData.ObjectName);
            }
        }











        private void InitializeComboBox()
        {
            comboBox.ItemsSource = LearningImageOne.GetVideoCaptureDevices();

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
            LearningImageOne.StartCapture(cameraId);

        }










        //public int TakeNumber() {

        //    //// Instantiates a client
        //    //var client = ImageAnnotatorClient.Create();
        //    //// Load the image file into memory
        //    //var image = Google.Cloud.Vision.V1.Image.FromFile(@"c:\OCRTest\otto.jpg");
        //    //// Performs label detection on the image file
        //    //var response = client.DetectLabels(image);
        //    //foreach (var annotation in response)
        //    //{
        //    //    if (annotation.Description != null)
        //    //        Console.WriteLine(annotation.Description);
        //    //}
        //    int[] finalNum = new int[10];
        //    for (int i = 0; i < COUNTNUMCARD; i++)
        //    {
        //        Thread.Sleep(MSECONDNUMCARD);
        //        using (var api = OcrApi.Create())
        //        {
        //            api.SetVariable("tessedit_char_whitelist", "0123456789");
        //            api.Init(Languages.English);
        //            api.InputImage = OcrPix.FromBitmap((Bitmap)webCameraControl.GetCurrentImage());
        //            api.SetImage(OcrPix.FromBitmap((Bitmap)webCameraControl.GetCurrentImage()));
        //            api.Recognize();
        //            //string plainText = api.GetTextFromImage((Bitmap)webCameraControl.GetCurrentImage());
        //            Console.WriteLine("prova" + api.GetUtf8Text());
        //            for (int y = 0; y < 10; y++)
        //            {
        //               if (api.GetUtf8Text().Contains(y.ToString()))
        //               {
        //                    finalNum[y] += 1;
        //               }
        //            }
        //        }
        //    }
        //    return finalNum.ToList().IndexOf(finalNum.Max());
        //}

        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            LearningImageOne.StopCapture();
        }
        //public Bitmap CropBitmap(Bitmap bitmap, int cropX, int cropY, int cropWidth, int cropHeight)
        //{
        //    Rectangle rect = new Rectangle(cropX, cropY, cropWidth, cropHeight);
        //    Bitmap cropped = bitmap.Clone(rect, bitmap.PixelFormat);
        //    return cropped;
        //}
        //private void OnImageButtonClick(object sender, RoutedEventArgs e)
        //{
        //    Bitmap bmp = null;
        //    bmp = (Bitmap)webCameraControl.GetCurrentImage();
        //    Boolean IsColorFound = false;
        //    int number = TakeNumber();


        //    if (bmp != null)
        //    {
        //        //Iterate whole bitmap to findout the picked color
        //        for (int i = 0; i < bmp.Height; i++)
        //        {
        //            for (int j = 0; j < bmp.Width; j++)
        //            {
        //                //Get the color at each pixel
        //                Color now_color = bmp.GetPixel(j, i);
        //                //Compare Pixel's Color ARGB property with the picked color's ARGB property 
        //                if (now_color.R <= 50 && now_color.G >= 100 && now_color.B <= 50)
        //                {
        //                    IsColorFound = true;
        //                    MessageBox.Show("Number " + number + ", color green Found!");
        //                    break;
        //                }
        //                if (now_color.R >= 100 && now_color.G >= 100 && now_color.B <= 50)
        //                {
        //                    IsColorFound = true;
        //                    MessageBox.Show("Number " + number + ", color yellow Found!");
        //                    break;
        //                }
        //                if (now_color.R <= 50 && now_color.G <= 50 && now_color.B >= 100)
        //                {
        //                    IsColorFound = true;
        //                    MessageBox.Show("Number " + number + ", color blue Found!");
        //                    break;
        //                }
        //                if (now_color.R >= 100 && now_color.G <= 50 && now_color.B <= 50)
        //                {
        //                    IsColorFound = true;
        //                    MessageBox.Show("Number " + number + ", color red Found!");
        //                    break;
        //                }
        //            }
        //            if (IsColorFound == true)
        //            {
        //                break;
        //            }
        //        }
        //        if (IsColorFound == false)
        //        {
        //            MessageBox.Show("Selected Color Not Found. " + number);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Image is not loaded");
        //    }

        //}
    }
}
