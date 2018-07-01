using System.Collections.Generic;

namespace Battleships.Domain
{
    public class GameBoard
    {
        public Player Owner { get; set; }
	    public IEnumerable<Ship> Armada { get; set; }
    }
}
