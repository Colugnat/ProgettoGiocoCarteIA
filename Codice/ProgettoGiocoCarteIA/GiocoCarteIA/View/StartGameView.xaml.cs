﻿using GiocoCarteIA.Model;
using GiocoCarteIA.ViewModel;
using ObjectRecognition;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WebEye.Controls.Wpf;

namespace GiocoCarteIA.View
{
    /// <summary>
    /// Interaction logic for StartGameView.xaml
    /// </summary>
    public partial class StartGameView : UserControl
    {
        public StartGameView()
        {
            Carta.CardAI = new String[7][];
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                Carta.CardAI[i] = new String[2];
            }
        }
        public string identifierObject()
        {
            webCameraControl.StartCapture(Camera.CameraId);
            var identificationImage = webCameraControl.GetCurrentImage();
            webCameraControl.StopCapture();
            if (identificationImage == null)
            {
                MessageBox.Show("Please select an image to analyze");
            }
            else
            {
                IList<string> identifiedObjects = ObjectIdentificationService.AnalyzeImage(Convert(identificationImage));
                if (identifiedObjects.Count == 0)
                {
                    return "Not work";
                }
                else
                {
                    return identifiedObjects[0];
                }
            }
            return "Not work";
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
        private void FirstCard_Click(object sender, RoutedEventArgs e)
        {
            var card = identifierObject().Split(' ');
            FirstResult.Content = card[0] + " " + card[1];
            Carta.CardAI[0][0] = card[0];
            Carta.CardAI[0][1] = card[1];
            Carta.CardAICopy = (String[][])Carta.CardAI.Clone();
        }
        private void SecondCard_Click(object sender, RoutedEventArgs e)
        {
            var card = identifierObject().Split(' ');
            SecondResult.Content = card[0] + " " + card[1];
            Carta.CardAI[1][0] = card[0];
            Carta.CardAI[1][1] = card[1];
            Carta.CardAICopy = (String[][])Carta.CardAI.Clone();
        }

        private void ThirdCard_Click(object sender, RoutedEventArgs e)
        {
            var card = identifierObject().Split(' ');
            ThirdResult.Content = card[0] + " " + card[1];
            Carta.CardAI[2][0] = card[0];
            Carta.CardAI[2][1] = card[1];
            Carta.CardAICopy = (String[][])Carta.CardAI.Clone();
        }

        private void FourthCard_Click(object sender, RoutedEventArgs e)
        {
            var card = identifierObject().Split(' ');
            FourthResult.Content = card[0] + " " + card[1];
            Carta.CardAI[3][0] = card[0];
            Carta.CardAI[3][1] = card[1];
            Carta.CardAICopy = (String[][])Carta.CardAI.Clone();
        }

        private void FifthCard_Click(object sender, RoutedEventArgs e)
        {
            var card = identifierObject().Split(' ');
            FifthResult.Content = card[0] + " " + card[1];
            Carta.CardAI[4][0] = card[0];
            Carta.CardAI[4][1] = card[1];
            Carta.CardAICopy = (String[][])Carta.CardAI.Clone();
        }

        private void SixthCard_Click(object sender, RoutedEventArgs e)
        {
            var card = identifierObject().Split(' ');
            SixthResult.Content = card[0] + " " + card[1];
            Carta.CardAI[5][0] = card[0];
            Carta.CardAI[5][1] = card[1];
            Carta.CardAICopy = (String[][])Carta.CardAI.Clone();
        }

        private void SeventhCard_Click(object sender, RoutedEventArgs e)
        {
            var card = identifierObject().Split(' ');
            SeventhResult.Content = card[0] + " " + card[1];
            Carta.CardAI[6][0] = card[0];
            Carta.CardAI[6][1] = card[1];
            Carta.CardAICopy = (String[][])Carta.CardAI.Clone();
        }
    }
}
