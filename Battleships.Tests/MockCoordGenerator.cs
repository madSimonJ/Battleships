using System;
using System.Collections.Generic;

namespace Battleships.Tests
{
    public class MockCoordGenerator
    {
	    private readonly char[] _xCoords;
	    private readonly char[] _yCoords;
		public int XCoordCount { get; private set; }
		public int YCoordCount { get; private set; }

		public List<(char min, char max)> MinMaxParams = new List<(char min, char max)>();

	    public MockCoordGenerator(char[] xCoords, char[] yCoords)
	    {
		    _xCoords = xCoords;
		    _yCoords = yCoords;
	    }

	    public char GenerateCoords(char min, char max)
	    {
		    MinMaxParams.Add((min, max));
		    if (Helper.IsXCoord((min, max)))
		    {
			    XCoordCount++;
			    return _xCoords[XCoordCount - 1];
		    }

			if (Helper.IsYCoord((min, max)))
			{
			    YCoordCount++;
			    return _yCoords[YCoordCount - 1];
		    }

		    throw new Exception();
	    }
    }
}
