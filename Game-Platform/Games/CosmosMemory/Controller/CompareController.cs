using Game_Platform.Games.CosmosMemory.Models;
using Game_Platform.Games.CosmosMemory.Views;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Game_Platform.Games.CosmosMemory.Controller
{
    public class CompareController
    {
        private Card First;
        private Card Second;

        public DialogBox Dialog { get; set; }

        public int Pairs { get; set; }
        public int Acertos { get; set; }
        public int Erros { get; set; }
        public int Tentativas { get; set; }

        public TextBlock TxtAcertos { get; set; }
        public TextBlock TxtErros { get; set; }
        public TextBlock TxtTentativas { get; set; }

        public void Init()
        {
            Acertos = 0;
            Erros = 0;
            Tentativas = Pairs;
            TxtTentativas.Text = $"{Tentativas}";

            Dialog.btnAgain.Click += new RoutedEventHandler(PlayAgain);
            Dialog.btnSair.Click += new RoutedEventHandler(Exit);
        }

        public void PlayAgain(object obj, RoutedEventArgs args)
        {
            Dialog.Close();
            new InitView().Show();
            CardController.window.Close();
        }

        public void Exit(object obj, RoutedEventArgs args)
        {
            Dialog.Close();
            CardController.window.Close();
        }

        public async void Compare(Card card)
        {

            if (First == null)
                First = card;
            else
            {
                Second = card;

                if (First.Constellation == Second.Constellation)
                {
                    First.Active = false;
                    Second.Active = false;
                    Acertos++;
                    TxtAcertos.Text = $"{Acertos}";

                    if (Acertos == Pairs)
                    {
                        Dialog.SetMessage("Parabéns você ganhou");
                        Dialog.ShowDialog();
                    }
                }
                else
                {
                    await Task.Delay(200);
                    First.Flip();
                    Second.Flip();
                    Erros++;
                    Tentativas--;
                    TxtTentativas.Text = $"{Tentativas}";
                    TxtErros.Text = $"{Erros}";

                    if (Tentativas == 0)
                    {
                        Dialog.SetMessage("Você perdeu");
                        Dialog.ShowDialog();
                    }
                }

                First = null;
                Second = null;
            }
        }
    }
}
