using GiocoCarteIA.Model;
using ObjectRecognition;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for GameIAView.xaml
    /// </summary>
    public partial class GameIAView : UserControl
    {
        private int countTab = -1;
        private String tab = "";
        Bitmap identificationImage;
        private List<String> combinations = new List<String>();
        private List<String[]> saveCombinations = null;
        private int addCard = 0;
        /// <summary>
        /// Constructor
        /// </summary>
        public GameIAView()
        {
            InitializeComponent();
            Carta.CardInGame = new String[2];
            saveCombinations = new List<String[]>();
        }
        /// <summary>
        /// Repeat the code if is not correct for the first time with the recognization of the camera
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Correct_Click(object sender, RoutedEventArgs e)
        {
            Carta.CardAI = Carta.CardAICopy;
            
            identificationImage = webCameraControl.GetCurrentImage();
            if (identificationImage == null)
            {
                MessageBox.Show("Please select an image to analyze");
            }
            else
            {
                IList<string> identifiedObjects = ObjectIdentificationService.AnalyzeImage(Convert(identificationImage));
                if (identifiedObjects.Count == 0)
                {
                    FoundedCard.Content = "Not work";
                }
                else
                {
                    string[] objectCard = identifiedObjects[0].Split(' ');
                    Carta.CardInGame[0] = objectCard[0];
                    Carta.CardInGame[1] = objectCard[1];
                    FoundedCard.Content = objectCard[0] + " " + objectCard[1];
                    Carta.CardInGameCopy = (String[])Carta.CardInGame.Clone();
                    SelectGame(Carta.CardInGameCopy[0], Carta.CardInGameCopy[1], false);
                    SelectGame(objectCard[0], objectCard[1], false);
                    Random num = new Random();
                    Move.Content = "";
                    if (saveCombinations.Count != 0)
                    {
                        foreach (string comb in saveCombinations[num.Next(0, saveCombinations.Count)])
                        {
                            Thread.Sleep(1500);
                            Move.Content += comb + " - ";
                            DeleteCard(comb);
                            if (Carta.NumCard == 1)
                            {
                                Thread.Sleep(1500);
                                Move.Content += " - UNO!";
                            }
                            else if (Carta.NumCard == 0)
                            {
                                Move.Content = "!!!!!! I WIN !!!!!!";
                            }
                        }
                    }
                    else if (Carta.NumCard == 0)
                    {
                        Move.Content = "!!!!!! I WIN !!!!!!";
                    }
                    else
                    {
                        Move.Content = "DRAW";
                        IsDrawCard();
                    }
                }
                saveCombinations = null;
                saveCombinations = new List<String[]>();
            }
        }
        /// <summary>
        /// Recognize the card for make the move and play the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            webCameraControl.StartCapture(Camera.CameraId);
            Thread.Sleep(3000);
            identificationImage = webCameraControl.GetCurrentImage();
            if (identificationImage == null)
            {
                MessageBox.Show("Please select an image to analyze");
            }
            else
            {
                IList<string> identifiedObjects = ObjectIdentificationService.AnalyzeImage(Convert(identificationImage));
                if (identifiedObjects.Count == 0)
                {
                    FoundedCard.Content = "Not work";
                }
                else
                {
                    var objectCard = identifiedObjects[0].Split(' ');
                    Carta.CardInGame[0] = objectCard[0];
                    Carta.CardInGame[1] = objectCard[1];
                    FoundedCard.Content = objectCard[0] + " " + objectCard[1];
                    Carta.CardInGameCopy = (String[])Carta.CardInGame.Clone();
                    SelectGame(Carta.CardInGameCopy[0], Carta.CardInGameCopy[1], false);
                    Random num = new Random();
                    int value = num.Next(0, saveCombinations.Count);
                    Move.Content = "";
                    if(saveCombinations.Count != 0)
                    {
                        foreach (string comb in saveCombinations[num.Next(0, saveCombinations.Count)])
                        {
                            Thread.Sleep(1500);
                            Move.Content += comb + " ";
                            DeleteCard(comb);
                            if (Carta.NumCard == 1)
                            {
                                Thread.Sleep(1500);
                                Move.Content += " UNO! ";
                            }
                            else if (Carta.NumCard == 0)
                            {
                                Move.Content = "!!!!!! I WIN !!!!!!";
                            }
                        }
                    }
                    else if (Carta.NumCard == 0)
                    {
                        Move.Content = "!!!!!! I WIN !!!!!!";
                    }
                    else
                    {
                        Move.Content = "DRAW";
                        IsDrawCard();
                    }
                }
                saveCombinations = null;
                saveCombinations = new List<String[]>();
            }
        }
        /// <summary>
        /// Change the status of the button for draw the card
        /// </summary>
        private void IsDrawCard()
        {
            Draw.IsEnabled = true;
        }
        /// <summary>
        /// Add a tab or remove it, if it's necessary
        /// </summary>
        /// <param name="remove">Remove or add a tab in the console</param>
        /// <returns>A sequence of tab</returns>
        private String AddTab(bool remove)
        {
            tab = "";
            if (remove)
                countTab += 1;
            else
                countTab -= 1;
            for (int i = 0; i < countTab; i++)
            {
                tab += " L ";
            }
            return tab;
        }
        /// <summary>
        /// Save all the combinations founded on the method
        /// </summary>
        private void Save()
        {
            if (combinations.Count != 0)
            {
                addCard += 1;
                saveCombinations.Add(combinations.ToArray());
            }
        }
        /// <summary>
        /// Check the possible moves, and check all the possibility
        /// </summary>
        /// <param name="selectedCard">Color of the card</param>
        /// <param name="selectedNum">Number of the card</param>
        /// <param name="nextIsMy">Check if the card is of the IA or the game</param>
        private void SelectGame(String selectedCard, String selectedNum, bool nextIsMy)
        {
            for (int i = 0; i < Carta.CardAICopy.Length; i++)
            {
                if (((Carta.CardAICopy[i][0] == selectedCard) && !nextIsMy) || (Carta.CardAICopy[i][1] == selectedNum))
                {
                    Console.WriteLine(AddTab(true) + Carta.CardAICopy[i][0] + " " + Carta.CardAICopy[i][1] + Environment.NewLine);
                    Carta.CardInGameCopy[0] = Carta.CardAICopy[i][0];
                    Carta.CardInGameCopy[1] = Carta.CardAICopy[i][1];
                    combinations.Add(Carta.CardInGameCopy[0] + " " + Carta.CardInGameCopy[1]);
                    Carta.CardAICopy[i][0] = "";
                    Carta.CardAICopy[i][1] = "";
                    SelectGame(Carta.CardInGameCopy[0], Carta.CardInGameCopy[1], true);
                    Carta.CardAICopy[i][0] = Carta.CardAI[i][0];
                    Carta.CardAICopy[i][1] = Carta.CardAI[i][1];
                    AddTab(false);
                }
            }
            Save();
            combinations.RemoveRange(0, combinations.Count);
        }
        /// <summary>
        /// Delete the selected card
        /// </summary>
        /// <param name="delete">the color and number of a card</param>
        private void DeleteCard(string delete)
        {
            for(int i = 0; i < Carta.CardAI.Length; i++)
            {
                if ((Carta.CardAI[i][0] + " " + Carta.CardAI[i][1]) == delete)
                {
                    Carta.CardAI[i][0] = "";
                    Carta.CardAI[i][1] = "";
                    Carta.NumCard -= 1;
                    break;
                }
            }
        }
        /// <summary>
        /// Convert the image in BitmapImage
        /// </summary>
        /// <param name="img">The image to convert</param>
        /// <returns>The new BitmapImage</returns>
        private BitmapImage Convert(System.Drawing.Image img)
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
        /// <summary>
        /// Draw a new card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Draw_Click(object sender, RoutedEventArgs e)
        {
            Carta.NumCard += 1;
            var card = IdentifierObject().Split(' ');
            Carta.CardAI[Carta.NumCard][0] = card[0];
            Carta.CardAI[Carta.NumCard][1] = card[1];
            Carta.CardAICopy = Carta.CardAI;
            SelectGame(Carta.CardInGameCopy[0], Carta.CardInGameCopy[1], false);
        }
        /// <summary>
        /// Recognize a card
        /// </summary>
        /// <returns></returns>
        private string IdentifierObject()
        {
            var identificationImage = webCameraControl.GetCurrentImage();
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
        /// <summary>
        /// Stop using the camera for this section
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            if (webCameraControl.IsCapturing)
                webCameraControl.StopCapture();
        }
    }
}
