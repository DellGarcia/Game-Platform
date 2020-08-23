using Game_Platform.Games.Forca.Controllers;
using Game_Platform.Games.Forca.Services.RestCountriesApi.AlphaCode;
using SharpVectors.Runtime;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Game_Platform.Games.Forca.Views
{
    /// <summary>
    /// Lógica interna para MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            Button[] VirtualKeyboard = new Button[26];

            VirtualKeyboard[0] = btn1;
            VirtualKeyboard[1] = btn2;
            VirtualKeyboard[2] = btn3;
            VirtualKeyboard[3] = btn4;
            VirtualKeyboard[4] = btn5;
            VirtualKeyboard[5] = btn6;
            VirtualKeyboard[6] = btn7;
            VirtualKeyboard[7] = btn8;
            VirtualKeyboard[8] = btn9;
            VirtualKeyboard[9] = btn10;

            VirtualKeyboard[10] = btn11;
            VirtualKeyboard[11] = btn12;
            VirtualKeyboard[12] = btn13;
            VirtualKeyboard[13] = btn14;
            VirtualKeyboard[14] = btn15;
            VirtualKeyboard[15] = btn16;
            VirtualKeyboard[16] = btn17;
            VirtualKeyboard[17] = btn18;
            VirtualKeyboard[18] = btn19;
            VirtualKeyboard[19] = btn20;

            VirtualKeyboard[20] = btn21;
            VirtualKeyboard[21] = btn22;
            VirtualKeyboard[22] = btn23;
            VirtualKeyboard[23] = btn24;
            VirtualKeyboard[24] = btn25;
            VirtualKeyboard[25] = btn26;

            new GameController(this ,VirtualKeyboard);
        }

    }
}
