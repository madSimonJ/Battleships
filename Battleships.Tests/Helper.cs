namespace Battleships.Tests
{
    public static class Helper
    {
	    public static bool IsXCoord(char c) => c >= 'a' && c <= 'j';
	    public static bool IsYCoord(char c) => c >= '0' && c <= '9';

	    public static bool IsXCoord((char min, char max) range) => IsXCoord(range.min) && IsXCoord(range.max);
	    public static bool IsYCoord((char min, char max) range) => IsYCoord(range.min) && IsYCoord(range.max);
    }
}
