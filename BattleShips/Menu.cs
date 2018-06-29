using System;
using System.Collections.Generic;

namespace BattleShips.ConsoleApp
{
    public static class Menu
    {
		public static (IEnumerable<string> MenuText, MenuState State) GetMenuText(MenuState oldMenuState, char userInput)
		{
			switch (oldMenuState)
			{
				case MenuState.Initialise:
					return (new[]
					{
						"Battleships",
						"By Simon J. Painter",
						"",
						"",
						"1. New Game",
						"2. Quit"
					}, MenuState.MainMenu);
				case MenuState.MainMenu:
					return HandleMainMenuChoices(userInput);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

	    private static (IEnumerable<string> MenuText, MenuState State) HandleMainMenuChoices(char choice)
	    {
		    switch (choice)
		    {
				case '1':
					return (new[] { "Would you like to be player 1 or 2?"}, MenuState.NewGame);
				case '2':
					return (new[] { "Goodbye!" }, MenuState.Quit);
				default:
					return(new[] { "Invalid option selected.  Please try again" }, MenuState.MainMenu);
		    }
	    }
    }
}
