using Game_Platform.Games.CosmosMemory.Controller;
using System.Windows;
using System.Windows.Controls;

namespace Game_Platform.Games.CosmosMemory.Views
{
    /// <summary>
    /// Lógica interna para MediumGameView.xaml
    /// </summary>
    public partial class HardGameView : Window
    {
        Image[] images;
        TextBlock[] texts;

        public HardGameView()
        {
            InitializeComponent();
            Init();
            new CardController(this, images, texts);
        }

        private void Init()
        {
            images = new Image[16];
            images[0] = card1;
            images[1] = card2;
            images[2] = card3;
            images[3] = card4;
            images[4] = card5;
            images[5] = card6;
            images[6] = card7;
            images[7] = card8;
            images[8] = card9;
            images[9] = card10;
            images[10] = card11;
            images[11] = card12;
            images[12] = card13;
            images[13] = card14;
            images[14] = card15;
            images[15] = card16;

            texts = new TextBlock[3];
            texts[0] = txtAcertos;
            texts[1] = txtErros;
            texts[2] = txtTentativas;
        }
    }
}
