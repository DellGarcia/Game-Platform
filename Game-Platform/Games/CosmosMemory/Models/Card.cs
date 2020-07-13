using Game_Platform.Games.CosmosMemory.Controller;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Game_Platform.Games.CosmosMemory.Models
{
    public class Card
    {
        public int Id { get; set; }
        private readonly Image Component;
        public string Constellation { get; private set; }
        private static readonly string resourcePath = "/Games/CosmosMemory/Assets/Constelacoes/";
        private readonly string TurnDownImage = $"{resourcePath}cosmos.jpg";
        public bool Active;
        public bool TurnUp { get; set; }

        public Card(int id, Image component, string constellationName)
        {
            Id = id;
            Component = component;
            Constellation = constellationName;
            Active = true;
            TurnUp = false;
            SetSource(TurnDownImage);
            Component.MouseLeftButtonUp += new MouseButtonEventHandler(Click);
        }

        private void SetSource(string path)
        {
            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri(path, UriKind.Relative);
            image.EndInit();
            Component.Source = image;
        }

        private void Click(Object o, MouseButtonEventArgs args)
        {
            if(Active && !TurnUp)
                Flip();
        }

        public void Flip()
        {
            TurnUp = !TurnUp;

            if (TurnUp)
            {
                SetSource($"{resourcePath}{Constellation}");
                CardController.Compare(this);
            }
            else
                SetSource(TurnDownImage);
        }
    }
}
