using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Platform.Models
{
    class Player
    {
        private string Username { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }
        private int Score { get; set; }
        private List<Player> Friends { get; }

    }
}
