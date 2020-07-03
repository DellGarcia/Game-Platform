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
        public int Score { get; set; }
        public List<Player> Friends { get; }

        public Player()
        {
            Score = 0;
            Friends = new List<Player>();
        }
    }
}
