using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Platform.Models
{
    public class Player
    {
        public string Username { get; set; }
        public string Email { get;  set; }
        public string Password { get;  set; }
        public int Vitorias { get; set; }
        public int Derrotas { get; set; }
        public List<Player> Friends { get; }

        public Player()
        {
            Vitorias = 0;
            Derrotas = 0;
            Friends = new List<Player>();
        }
    }
}
