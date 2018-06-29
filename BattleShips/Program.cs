using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Domain;

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
	        while (state.state != MenuState.Quit)
	        {
		        switch (state.state)
		        {
					case MenuState.NewGame:
						playersGameBoard = GameFactory.NewBoard();
						computersGameBoard = GameFactory.NewBoard();
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
