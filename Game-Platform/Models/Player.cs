using Game_Platform.Utils;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Game_Platform.Models
{
    public class Player
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string HashEmail { get => MD5HashString.GetMd5Hash(MD5.Create(), Email); }
        public string Password { get; set; }
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
