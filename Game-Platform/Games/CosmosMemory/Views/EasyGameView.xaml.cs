using Game_Platform.Games.CosmosMemory.Controller;
using System.Windows;
using System.Windows.Controls;

namespace Game_Platform.Games.CosmosMemory.Views
{
    
    public partial class EasyGameView : Window
    {
        Image[] images;
        TextBlock[] texts;

        public EasyGameView()
        {
            InitializeComponent();
            Init();
            new CardController(this, images, texts);
        }

        private void Init()
        {
            images = new Image[8];
            images[0] = card1;
            images[1] = card2;
            images[2] = card3;
            images[3] = card4;
            images[4] = card5;
            images[5] = card6;
            images[6] = card7;
            images[7] = card8;

            texts = new TextBlock[11];
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
        }


    }
}
