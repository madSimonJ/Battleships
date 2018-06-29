using System.Collections.Generic;

namespace Battleships.Domain
{
    public class GameBoard
    {
	    public IEnumerable<Ship> Armada { get; set; }
    }
}
