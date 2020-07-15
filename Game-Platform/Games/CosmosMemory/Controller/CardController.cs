﻿using Game_Platform.Games.CosmosMemory.Models;
using Game_Platform.Games.CosmosMemory.Utils;
using Game_Platform.Games.CosmosMemory.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Game_Platform.Games.CosmosMemory.Controller
{
    public class CardController
    {
        private readonly List<Card> Cards;
        internal static Window window;

        private readonly CompareController Comparator;

        public CardController(Window window, Image[] images, TextBlock[] texts)
        {
            CardController.window = window;
            Cards = new List<Card>();

            Comparator = new CompareController
            {
                Pairs = images.Length / 2,
                TxtAcertos = texts[0],
                TxtErros = texts[1],
                TxtTentativas = texts[2],

                Dialog = new DialogBox()
            };
            Comparator.Init();

            List<String> ConstellationsNames = 
                Methods.Shuffle(
                    Methods.SplitAndDuplicate(
                        Methods.Shuffle(Constellations.Names.ToList<String>()), Comparator.Pairs));

            for (int i = 0; i < images.Length; i++)
            {
                Card card = new Card(i, images[i], ConstellationsNames[i]);
                card.Component.MouseLeftButtonUp += new MouseButtonEventHandler(Click);
                Cards.Add(card);
            }

        }

        private void Click(Object o, MouseButtonEventArgs args)
        {
            Image image = (Image) o;

            foreach(Card card in Cards)
            {
                if (card.Component != image)
                    continue;

                if (card.Active && !card.TurnUp)
                {
                    card.Flip();

                    if (card.TurnUp)
                        Comparator.Compare(card);
                }
                break;
            }
        }

    }
}
