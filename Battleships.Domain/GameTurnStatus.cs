namespace Battleships.Domain
{
	public class GameTurnStatus
	{
	    public bool PlayerHit { get; set; }
	    public (int x, int y) ComputerPlayerShot { get; set; }
	    public bool IsPlayerHit { get; set; }
	}
}
