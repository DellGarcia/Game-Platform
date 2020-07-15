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

            texts = new TextBlock[19];
            texts[0] = txtAcertos;
            texts[1] = txtErros;
            texts[2] = txtTentativas;

            texts[3] = constellation1;
            texts[4] = constellation2;
            texts[5] = constellation3;
            texts[6] = constellation4;
            texts[7] = constellation5;
            texts[8] = constellation6;
            texts[9] = constellation7;
            texts[10] = constellation8;
            texts[11] = constellation9;
            texts[12] = constellation10;
            texts[13] = constellation11;
            texts[14] = constellation12;
            texts[15] = constellation13;
            texts[16] = constellation14;
            texts[17] = constellation15;
            texts[18] = constellation16;
        }
    }
}
