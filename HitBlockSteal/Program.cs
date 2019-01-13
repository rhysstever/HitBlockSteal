using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitBlockSteal
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> playerList = new List<Player>();

            // Creates 4 players and adds them to an List 
            Player player1 = new Player("Player 1");
            Player player2 = new Player("Player 2");
            Player player3 = new Player("Player 3");
            Player player4 = new Player("Player 4");

            playerList.Add(player1);
            playerList.Add(player2);
            playerList.Add(player3);
            playerList.Add(player4);

            // Creates a loop to iterate 5 times for the 5 rounds of the game
            for(int round = 1; round < 6; round++)
            {
				// Decision Phase: Asks each player for their action for the round
				foreach(Player player in playerList)
				{
					Console.WriteLine(" *** Round " + round + ": Decision Phase ***\n");
					
					Console.Write(" " + player.Name + ", do you wish to Hit, Block, Steal? ");
					player.Action = Console.ReadLine();
					switch(player.Action)
					{
						case "Hit":
							Console.Write(" Who do you wish to attack? (1, 2, 3, 4): ");
							player.Victim = int.Parse(Console.ReadLine());
							Console.WriteLine(" You have chosen to attack Player " + player.Victim + "!");
							break;
						case "Block":
							Console.WriteLine(" You have chosen to block yourself from attacks.");
							break;
						case "Steal":
							Console.WriteLine(" You have chosen to steal some cash.");
							break;
					}

					Console.Write("\n Press enter to continue...");
					Console.ReadLine();
					Console.Clear();
				}

				// Results Phase: Displays each player's decision
				Console.WriteLine(" *** Round " + round + ": Results Phase ***\n");

				foreach (Player player in playerList)
				{
					Console.Write(" " + player.Name + "'s action is: ");
					if (player.Action.Equals("Hit"))
						Console.WriteLine("Hit Player " + player.Victim);
					else
						Console.WriteLine(player.Action);
				}

				Console.Write(" Press enter to continue...");
				Console.ReadLine();
				Console.Clear();

				// Resolution Phase: Resolves each player's action
				Console.WriteLine(" *** Round " + round + ": Resolution Phase ***\n");

				foreach (Player player in playerList)
				{
					if (player.Action.Equals("Hit"))
					{
						Console.WriteLine(" " + player.Name + " attacks " + playerList[player.Victim - 1].Name + ".");
						if (playerList[player.Victim - 1].Action.Equals("Block"))
						{
							Console.WriteLine(" The attack was blocked! Nothing happens.");
						}
						else
						{
							playerList[player.Victim - 1].Lives--;
							Console.WriteLine(" " + playerList[player.Victim - 1].Name + " takes one damage!");
						}
					}
					else if(player.Action.Equals("Block"))
					{
						Console.WriteLine(" " + player.Name + " blocks.");
					}
					else if(player.Action.Equals("Steal"))
					{
						Console.WriteLine(" " + player.Name + " tries to steal cash...");
						foreach (Player secondPlayer in playerList)
						{
							if(secondPlayer.Equals(player))
							{
								if (playerList[secondPlayer.Victim].Equals(player))
								{
									Console.WriteLine(" " + player.Name + " has been attacked by " + secondPlayer.Name + ". ");
									Console.WriteLine(" " + player.Name + " is unsuccessful in stealing some money.");
								}
								else
								{
									Console.WriteLine(" " + player.Name + " successfully steals $100!");
									player.Cash += 100;
								}
							}
						}
					}

					Console.WriteLine("");
				}

				Console.Write("\n Press enter to continue...");
				Console.ReadLine();
				Console.Clear();

				// Displays each player's lives and checks to see if any player has died (lives = 0)
				Console.WriteLine(" *** Lives after Round " + round + "***\n");

				foreach (Player player in playerList)
				{
					Console.WriteLine(" " + player.Name + " has " + player.Lives + " lives.");
					if (player.Lives == 0)
					{
						playerList.Remove(player);
						Console.WriteLine(" " + player.Name + " has been killed!");
					}
				}

				Console.Write("\n Press enter to continue...");
				Console.ReadLine();
				Console.Clear();
			}
        }
    }
}
