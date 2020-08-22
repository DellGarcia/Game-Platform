using System.Threading;
using System.Windows;

namespace Game_Platform.Games.Forca.Views
{
    public partial class AwaitView : Window
    {
        private static AwaitView INSTANCE;

        private AwaitView()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Thread thread = new Thread(SwitchWindow);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void SwitchWindow()
        {
            Thread.Sleep(6000);
            new MainView().Show();
            AwaitView.INSTANCE.Destroy();
        }

        public static AwaitView Create()
        {
            if(INSTANCE == null)
            {
                INSTANCE = new AwaitView();
            }

            return INSTANCE;
        }

        public void Destroy()
        {
            INSTANCE.Close();
            INSTANCE = null;
        }
    }
}
