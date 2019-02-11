using System;
using System.Collections.Generic;
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

namespace IntelligenzaArtificiale.View
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private int countTab = -1;
        private String tab = "";
        private String[] cardInGame = null;
        private String[] cardInGameCopy = null;
        private String[][] cardAI = null;
        private String[][] cardAICopy = null;
        private List<String> combinations = new List<String>();
        private List<String>[] saveCombinations = null;
        private int addCard = 0;

        public MainView()
        {
            cardInGame = new String[2];
            cardAI = new String[7][];
            saveCombinations = new List<string>[10];
            InitializeComponent();
            for(int i = 0; i < 7; i++)
            {
                Thread.Sleep(50);
                cardAI[i] = new String[2];
                RandomCardGenerator(i);
            }
            carta0.Text = cardAI[0][0] + " " + cardAI[0][1];
            carta1.Text = cardAI[1][0] + " " + cardAI[1][1];
            carta2.Text = cardAI[2][0] + " " + cardAI[2][1];
            carta3.Text = cardAI[3][0] + " " + cardAI[3][1];
            carta4.Text = cardAI[4][0] + " " + cardAI[4][1];
            carta5.Text = cardAI[5][0] + " " + cardAI[5][1];
            carta6.Text = cardAI[6][0] + " " + cardAI[6][1];
            cardAICopy = (String[][])cardAI.Clone();
            cardInGameCopy = (String[])cardInGame.Clone();
        }
        private void RandomCardGenerator(int i)
        {
            Random rnd = new Random();
            int colorNum = rnd.Next(0, 4);
            switch (colorNum)
            {
                case 0:
                    cardAI[i][0] = "Rosso";
                    break;
                case 1:
                    cardAI[i][0] = "Giallo";
                    break;
                case 2:
                    cardAI[i][0] = "Verde";
                    break;
                case 3:
                    cardAI[i][0] = "Blu";
                    break;
                default:
                    break;
            }
            cardAI[i][1] = rnd.Next(0, 10).ToString();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (color0.IsChecked.Value)
                cardInGame[0] = color0.Content.ToString();
            else if(color1.IsChecked.Value)
                cardInGame[0] = color1.Content.ToString();
            else if (color2.IsChecked.Value)
                cardInGame[0] = color2.Content.ToString();
            else if (color3.IsChecked.Value)
                cardInGame[0] = color3.Content.ToString();

            cardInGame[1] = number.Value.ToString();

           cardGame.Text = cardInGame[0] + " " + cardInGame[1];
           SelectGame(cardInGame[0], cardInGame[1], false);
        }
        private String AddTab(bool remove)
        {
            tab = "";
            if (remove)
                countTab += 1;
            else
                countTab -= 1;
            for(int i = 0; i < countTab; i++)
            {
                tab += " L ";
            }
            return tab;
        }
        private void Save()
        {
            if(combinations.Count !=  0)
            {
                addCard += 1;
                saveCombinations[addCard - 1] = combinations.ToList();
            }
        }
        private void SelectGame(String selectedCard, String selectedNum, bool nextIsMy)
        {
            for(int i = 0; i < cardAICopy.Length; i++)
            {
                if (((cardAICopy[i][0] == selectedCard) && !nextIsMy) || (cardAICopy[i][1] == selectedNum))
                {
                    cardsMove.Text += AddTab(true) + cardAICopy[i][0] + " " + cardAICopy[i][1] + Environment.NewLine;
                    cardInGameCopy[0] = cardAICopy[i][0];
                    cardInGameCopy[1] = cardAICopy[i][1];
                    combinations.Add(cardInGameCopy[0] + " " + cardInGameCopy[1]);
                    cardAICopy[i][0] = "";
                    cardAICopy[i][1] = "";
                    SelectGame(cardInGameCopy[0], cardInGameCopy[1], true);
                    cardAICopy[i][0] = cardAI[i][0];
                    cardAICopy[i][1] = cardAI[i][1];
                    AddTab(false);
                }
            }
            Save();
            combinations.RemoveRange(0, combinations.Count);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cardsMove.Text = "";
            for (int i = 0; i < 7; i++)
            {
                Thread.Sleep(50);
                cardAI[i] = new String[2];
                RandomCardGenerator(i);
            }
            carta0.Text = cardAI[0][0] + " " + cardAI[0][1];
            carta1.Text = cardAI[1][0] + " " + cardAI[1][1];
            carta2.Text = cardAI[2][0] + " " + cardAI[2][1];
            carta3.Text = cardAI[3][0] + " " + cardAI[3][1];
            carta4.Text = cardAI[4][0] + " " + cardAI[4][1];
            carta5.Text = cardAI[5][0] + " " + cardAI[5][1];
            carta6.Text = cardAI[6][0] + " " + cardAI[6][1];
            cardAICopy = (String[][])cardAI.Clone();
            cardInGameCopy = (String[])cardInGame.Clone();
        }
    }
}
