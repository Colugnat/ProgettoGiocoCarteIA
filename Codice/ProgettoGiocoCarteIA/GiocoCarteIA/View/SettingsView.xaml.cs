using GiocoCarteIA.Model;
using ObjectRecognition;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GiocoCarteIA.View
{
    /// <summary>
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
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
            webCameraControl.StartCapture(Camera.CameraId);
            backgroundImage = Convert(webCameraControl.GetCurrentImage());
            webCameraControl.StopCapture();
            this.LearningImageOne.Source = backgroundImage;
        }

        private void LearningImageTwoButton_Click(object sender, RoutedEventArgs e)
        {
            webCameraControl.StartCapture(Camera.CameraId);
            learningImage = Convert(webCameraControl.GetCurrentImage());
            webCameraControl.StopCapture();
            this.LearningImageTwo.Source = learningImage;
        }

        private void AnalyzeImageButton_Click(object sender, RoutedEventArgs e)
        {
            webCameraControl.StartCapture(Camera.CameraId);
            identificationImage = Convert(webCameraControl.GetCurrentImage());
            webCameraControl.StopCapture();
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
    }
}
