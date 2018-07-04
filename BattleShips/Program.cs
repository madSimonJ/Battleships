using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Domain;
using BattleShips.BusinessLogic;

namespace BattleShips.ConsoleApp
{
	internal class Program
    {
	    private static void Main()
        {
	        (IEnumerable<string> message, MenuState state)state = (Enumerable.Empty<string>(), MenuState.Initialise);
			GameBoard playersGameBoard;
	        GameBoard computersGameBoard;
	        var userInput = ' ';
            var random = new Random();
            var placer = new ShipPlacer((min, max) => (char)random.Next(min, max));
	        while (state.state != MenuState.Quit)
	        {
		        switch (state.state)
		        {
					case MenuState.NewGame:
						playersGameBoard = GameFactory.NewBoard(placer);
						computersGameBoard = GameFactory.NewBoard(placer);
						break;
					default:
						state = Menu.GetMenuText(state.state, userInput);
						break;
				}
		        
		        foreach (var line in state.message)
			        Console.WriteLine(line);
		        userInput = Console.ReadKey().KeyChar;
				Console.WriteLine();
	        }
        }
    }
}
