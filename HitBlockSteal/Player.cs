using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HitBlockSteal
{
	class Player
	{
		// Fields
		private string name;
		private int lives;
		private int cash;
		private string action;
		private int victim;

		// Properties for each field
		// Every field has both a get and set property except
		// for Name (user is unable to change the player name
		public string Name { get { return name; } }
		public int Lives
		{
			get { return lives; }
			set { lives = value; }
		}
		public int Cash
		{
			get { return cash; }
			set { cash = value; }
		}
		public string Action
		{
			get { return action; }
			set { action = value; }
		}
		public int Victim
		{
			get { return victim; }
			set { victim = value; }
		}

		/// <summary>
		/// Assigns initial values to a character object
		/// </summary>
		/// <param name="name">The name of the player</param>
		public Player(string name)
		{
			this.name = name;
			lives = 3;
			cash = 0;
			action = "";
			victim = 0;
		}
	}
}
