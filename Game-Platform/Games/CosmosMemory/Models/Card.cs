using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Platform.Games.CosmosMemory.Models
{
    public class Card
    {
        public string Constellation { get; private set; }
        private readonly string TurnDownImage = "/Games/CosmosMemory/Assets/Constelacoes/cosmos.jpg";
        public bool TurnUp { get; set; }

        public Card(string constellationName)
        {
            Constellation = constellationName;
            TurnUp = false;
        }
    }
}
