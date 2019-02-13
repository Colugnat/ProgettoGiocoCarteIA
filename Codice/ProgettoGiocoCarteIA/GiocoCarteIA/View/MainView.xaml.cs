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
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        //private int countTab = -1;
        //private String tab = "";
        //private String[] cardInGame = null;
        //private String[] cardInGameCopy = null;
        //private String[][] cardAI = null;
        //private String[][] cardAICopy = null;
        //private List<String> combinations = new List<String>();
        //private List<String>[] saveCombinations = null;
        //private int addCard = 0;
        public MainView()
        {
        //    cardInGame = new String[2];
        //    cardAI = new String[7][];
        //    saveCombinations = new List<string>[10];
            InitializeComponent();
        //    InitializeComboBox();
        //    for (int i = 0; i < 7; i++)
        //    {
        //        Thread.Sleep(50);
        //        cardAI[i] = new String[2];
        //        RandomCardGenerator(i);
        //    }
        //    carta0.Text = cardAI[0][0] + " " + cardAI[0][1];
        //    carta1.Text = cardAI[1][0] + " " + cardAI[1][1];
        //    carta2.Text = cardAI[2][0] + " " + cardAI[2][1];
        //    carta3.Text = cardAI[3][0] + " " + cardAI[3][1];
        //    carta4.Text = cardAI[4][0] + " " + cardAI[4][1];
        //    carta5.Text = cardAI[5][0] + " " + cardAI[5][1];
        //    carta6.Text = cardAI[6][0] + " " + cardAI[6][1];
        //    cardAICopy = (String[][])cardAI.Clone();
        //    cardInGameCopy = (String[])cardInGame.Clone();
        }
        //////////////////////////////////////////Intelligenza
        //private void RandomCardGenerator(int i)
        //{
        //    Random rnd = new Random();
        //    int colorNum = rnd.Next(0, 4);
        //    switch (colorNum)
        //    {
        //        case 0:
        //            cardAI[i][0] = "Rosso";
        //            break;
        //        case 1:
        //            cardAI[i][0] = "Giallo";
        //            break;
        //        case 2:
        //            cardAI[i][0] = "Verde";
        //            break;
        //        case 3:
        //            cardAI[i][0] = "Blu";
        //            break;
        //        default:
        //            break;
        //    }
        //    cardAI[i][1] = rnd.Next(0, 10).ToString();
        //}
        //private String AddTab(bool remove)
        //{
        //    tab = "";
        //    if (remove)
        //        countTab += 1;
        //    else
        //        countTab -= 1;
        //    for (int i = 0; i < countTab; i++)
        //    {
        //        tab += " L ";
        //    }
        //    return tab;
        //}
        //private void Save()
        //{
        //    if (combinations.Count != 0)
        //    {
        //        addCard += 1;
        //        saveCombinations[addCard - 1] = combinations.ToList();
        //    }
        //}
        //private void SelectGame(String selectedCard, String selectedNum, bool nextIsMy)
        //{
        //    for (int i = 0; i < cardAICopy.Length; i++)
        //    {
        //        if (((cardAICopy[i][0] == selectedCard) && !nextIsMy) || (cardAICopy[i][1] == selectedNum))
        //        {
        //            cardsMove.Text += AddTab(true) + cardAICopy[i][0] + " " + cardAICopy[i][1] + Environment.NewLine;
        //            cardInGameCopy[0] = cardAICopy[i][0];
        //            cardInGameCopy[1] = cardAICopy[i][1];
        //            combinations.Add(cardInGameCopy[0] + " " + cardInGameCopy[1]);
        //            cardAICopy[i][0] = "";
        //            cardAICopy[i][1] = "";
        //            SelectGame(cardInGameCopy[0], cardInGameCopy[1], true);
        //            cardAICopy[i][0] = cardAI[i][0];
        //            cardAICopy[i][1] = cardAI[i][1];
        //            AddTab(false);
        //        }
        //    }
        //    Save();
        //    combinations.RemoveRange(0, combinations.Count);
        //}
        //////////////////////////////////////////Camera
        //public BitmapImage Convert(System.Drawing.Image img)
        //{
        //    using (var memory = new MemoryStream())
        //    {
        //        img.Save(memory, ImageFormat.Png);
        //        memory.Position = 0;

        //        var bitmapImage = new BitmapImage();
        //        bitmapImage.BeginInit();
        //        bitmapImage.StreamSource = memory;
        //        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
        //        bitmapImage.EndInit();

        //        return bitmapImage;
        //    }
        //}

        //private BitmapImage learningImage = null;
        //private BitmapImage backgroundImage = null;
        //private BitmapImage identificationImage = null;

        //private void LearningImageOneButton_Click(object sender, RoutedEventArgs e)
        //{
        //    backgroundImage = Convert(webCameraControl.GetCurrentImage());
        //    this.LearningImageOne.Source = backgroundImage;
        //}

        //private void LearningImageTwoButton_Click(object sender, RoutedEventArgs e)
        //{
        //    learningImage = Convert(webCameraControl.GetCurrentImage());
        //    this.LearningImageTwo.Source = learningImage;
        //}

        //private void AnalyzeImageButton_Click(object sender, RoutedEventArgs e)
        //{
        //    identificationImage = Convert(webCameraControl.GetCurrentImage());
        //    this.AnalysisImage.Source = identificationImage;
        //}

        //private void LearnObjectButton_Click(object sender, RoutedEventArgs e)
        //{
        //    string objectName = this.ObjectNameText.Text;
        //    if (objectName.Length == 0)
        //    {
        //        MessageBox.Show("Please give the item a name");
        //    }
        //    else if (learningImage == null || backgroundImage == null)
        //    {
        //        MessageBox.Show("Please select a background image and an image with the object to learn");
        //    }
        //    else
        //    {
        //        ObjectLearningServices.LearnObject(learningImage, backgroundImage, objectName);
        //        PopulateLearnedItemsList();
        //    }
        //}

        //private void AnalyzeButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (identificationImage == null)
        //    {
        //        MessageBox.Show("Please select an image to analyze");
        //    }
        //    else
        //    {
        //        IList<string> identifiedObjects = ObjectIdentificationService.AnalyzeImage(identificationImage);
        //        this.AnalysisResultsText.Text = "";

        //        foreach (string objectName in identifiedObjects)
        //        {
        //            this.AnalysisResultsText.Text = this.AnalysisResultsText.Text + ("May contain " + objectName + "\r\n");
        //            char[] whitespace = new char[] { ' ', '\t' };
        //            string[] moves = objectName.Split(whitespace);
        //            cardInGame[0] = moves[0];
        //            cardInGame[1] = moves[1];
        //            SelectGame(cardInGame[0], cardInGame[1], false);
        //        }

        //        if (identifiedObjects.Count == 0)
        //        {
        //            this.AnalysisResultsText.Text = "Did not recognize anything";
        //        }
        //    }
        //}

        //private void Window_Loaded_1(object sender, RoutedEventArgs e)
        //{
        //    PopulateLearnedItemsList();
        //}

        //private void DeleteObjectButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.LearnedObjectsList.SelectedIndex != -1)
        //    {
        //        string objectName = (string)this.LearnedObjectsList.SelectedItem;
        //        ObjectMemoryService.RemoveSignatureByName(objectName);
        //        PopulateLearnedItemsList();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select an item to delete");
        //    }
        //}

        //private void PopulateLearnedItemsList()
        //{
        //    List<ObjectSignatureData> learnedObjects = ObjectMemoryService.GetSignatures();
        //    this.LearnedObjectsList.Items.Clear();
        //    foreach (ObjectSignatureData objectSignatureData in learnedObjects)
        //    {
        //        this.LearnedObjectsList.Items.Add(objectSignatureData.ObjectName);
        //    }
        //}
        //private void InitializeComboBox()
        //{
        //    comboBox.ItemsSource = webCameraControl.GetVideoCaptureDevices();

        //    if (comboBox.Items.Count > 0)
        //    {
        //        comboBox.SelectedItem = comboBox.Items[0];
        //    }
        //}
        //private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    startButton.IsEnabled = e.AddedItems.Count > 0;
        //}
        //private void OnStartButtonClick(object sender, RoutedEventArgs e)
        //{
        //    var cameraId = (WebCameraId)comboBox.SelectedItem;
        //    webCameraControl.StartCapture(cameraId);

        //}
        //private void OnStopButtonClick(object sender, RoutedEventArgs e)
        //{
        //    webCameraControl.StopCapture();
        //}
    }
}
