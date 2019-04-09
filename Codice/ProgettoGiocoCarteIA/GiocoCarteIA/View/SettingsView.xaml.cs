using GiocoCarteIA.Model;
using ObjectRecognition;
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
    /// Interaction logic for SettingsView.xaml
    /// </summary>
    public partial class SettingsView : UserControl
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SettingsView()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        /// <summary>
        /// Convert the image in BitmapImage
        /// </summary>
        /// <param name="img">The image to convert</param>
        /// <returns>The new BitmapImage</returns>
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
        /// <summary>
        /// Backgroung image to learn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LearningImageOneButton_Click(object sender, RoutedEventArgs e)
        {
            backgroundImage = Convert(webCameraControl.GetCurrentImage());
            this.LearningImageOne.Source = backgroundImage;
        }
        /// <summary>
        /// Object to learn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LearningImageTwoButton_Click(object sender, RoutedEventArgs e)
        {
            learningImage = Convert(webCameraControl.GetCurrentImage());
            this.LearningImageTwo.Source = learningImage;
        }
        /// <summary>
        /// Image to analyze
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AnalyzeImageButton_Click(object sender, RoutedEventArgs e)
        {
            identificationImage = Convert(webCameraControl.GetCurrentImage());
            this.AnalysisImage.Source = identificationImage;
        }
        /// <summary>
        /// Method fo learn the new object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Method for analyze and testing the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Start the capture of a image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            PopulateLearnedItemsList();
            webCameraControl.StartCapture(Camera.CameraId);
        }
        /// <summary>
        /// Delete a object from a database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Populate the list with all the object
        /// </summary>
        private void PopulateLearnedItemsList()
        {
            List<ObjectSignatureData> learnedObjects = ObjectMemoryService.GetSignatures();
            this.LearnedObjectsList.Items.Clear();
            foreach (ObjectSignatureData objectSignatureData in learnedObjects)
            {
                this.LearnedObjectsList.Items.Add(objectSignatureData.ObjectName);
            }
        }
        /// <summary>
        /// Check if the button for capture the video is ready
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            startButton.IsEnabled = e.AddedItems.Count > 0;
        }
        /// <summary>
        /// Take the new camera when the combobox item is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStartButtonClick(object sender, RoutedEventArgs e)
        {
            var cameraId = (WebCameraId)comboBox.SelectedItem;
            webCameraControl.StartCapture(cameraId);
            Camera.CameraId = cameraId;

        }
        /// <summary>
        /// Stop capturing the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnStopButtonClick(object sender, RoutedEventArgs e)
        {
            webCameraControl.StopCapture();
        }
        /// <summary>
        /// Stop capturing the video
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (webCameraControl.IsCapturing)
                webCameraControl.StopCapture();
        }
        /// <summary>
        /// Initialize the combobox with all the cameras
        /// </summary>
        private void InitializeComboBox()
        {
            comboBox.ItemsSource = webCameraControl.GetVideoCaptureDevices();
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedItem = "";
            }
        }
    }
}
