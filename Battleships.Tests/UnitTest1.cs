using System.Collections.Generic;
using BattleShips.ConsoleApp;
using FluentAssertions;
using Xunit;

namespace MenuTests__
{
	namespace given_a_request_for_menu_text
	{
		public class when_no_other_requests_have_been_made
		{
			private readonly (IEnumerable<string> MenuText, MenuState State) _menuText;

			public when_no_other_requests_have_been_made()
			{
				_menuText = Menu.GetMenuText();
			}

			[Fact]
			public void then_the_main_menu_text_should_be_displayed()
			{
				_menuText.MenuText.Should().BeEquivalentTo(
					"Battleships",
					"By Simon J. Painter",
					"",
					"",
					"1. New Game",
					"2. Quit");
			}

			[Fact]
			public void then_the_menu_state_should_be_main_menu()
			{
				_menuText.State.Should().Be(MenuState.MainMenu);
			}
		}
	}

	namespace given_the_user_is_on_the_main_menu
	{

		public class when_option_1_is_selected
		{
			private readonly (IEnumerable<string> MenuText, MenuState State) menuText;

			public when_option_1_is_selected()
			{
				menu = new Menu();
				menuText = menu.GetMenuText(MenuState.MainMenu, '1');
			}

			[Fact]
			public void then_the_new_game_text_should_be_displayed()
			{
				menuText.MenuText.Should().BeEquivalentTo("Would you like to be player 1 or 2?");
			}

			[Fact]
			public void then_the_menu_state_should_be_main_menu()
			{
				menuText.State.Should().Be(MenuState.NewGame);
			}
		}

		public class when_option_2_is_selected
		{
			private readonly (IEnumerable<string> MenuText, MenuState State) menuText;

			public when_option_2_is_selected()
			{
				menuText = Menu.GetMenuText(MenuState.MainMenu, '2');
			}

			[Fact]
			public void then_farewell_message_should_be_displayed()
			{
				menuText.MenuText.Should().BeEquivalentTo("Goodbye!");
			}

			[Fact]
			public void then_the_menu_state_should_be_quit()
			{
				menuText.State.Should().Be(MenuState.Quit);
			}
		}

		public class when_an_invalid_option_is_selected
		{
			private readonly Menu menu;
			private readonly (IEnumerable<string> MenuText, MenuState State) menuText;

			public when_an_invalid_option_is_selected()
			{
				menu = new Menu();
				menuText = menu.GetMenuText(MenuState.MainMenu, '6');
			}

			[Fact]
			public void then_the_user_should_see_a_prompt_to_try_again()
			{
				menuText.MenuText.Should().BeEquivalentTo("Invalid option selected.  Please try again");
			}

			[Fact]
			public void then_the_menu_state_should_still_be_main_menu()
			{
				menuText.State.Should().Be(MenuState.MainMenu);
			}
		}

	}
}
