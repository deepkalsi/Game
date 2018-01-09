using System;
using System.Collections.Generic;

namespace Game.Models
{
    public partial class Games
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string Score { get; set; }
        public string ReleaseYear { get; set; }
        public string Developer { get; set; }
    }
}
