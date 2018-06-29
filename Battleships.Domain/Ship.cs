using System.Collections.Generic;

namespace Battleships.Domain
{
	public class Ship
    {
	    public Player Owner { get; set; }
	    public IEnumerable<Square> Squares { get; set; }
    }
}
