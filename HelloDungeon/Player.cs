using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{
    class Player : Character
    {
        //establishes what a player has and can do
        private string _playerChoice;
        private float _playerLives=3;

        public Player()
        {
            _playerChoice = "";
        }

        //construct
        //establishes what the things a player has actually means
        //       |                                                                                                                          |
        //       V                                                                                                                          V meant to call character function to get stats
        public Player(string name, float health, float damage, float defense, float defenseboost, float stamina, Weapon currentWeapon) : base( name, health, damage, defense, defenseboost, stamina, currentWeapon) 
        {
            _playerChoice = "";
        }

        public float GetLives()
        {
            return _playerLives;
        }

        public string GetInput(string prompt, string option1, string option2)
        {
            _playerChoice = "";

            Console.WriteLine(prompt);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.Write(">");

            _playerChoice = Console.ReadLine();

            return _playerChoice;
        }

        public string GetInput(string prompt, string option1, string option2, string option3)
        {
            _playerChoice = "";

            Console.WriteLine(prompt);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.Write(">");

            _playerChoice = Console.ReadLine();

            return _playerChoice;
        }

        public string GetInput(string prompt, string option1, string option2, string option3, string option4)
        {
            _playerChoice = "";

            Console.WriteLine(prompt);
            Console.WriteLine("1." + option1);
            Console.WriteLine("2." + option2);
            Console.WriteLine("3." + option3);
            Console.WriteLine("4." + option4);
            Console.Write(">");

            _playerChoice = Console.ReadLine();

            return _playerChoice;
        }

        public override void PrintStats()
        {
            base.PrintStats();
            Console.WriteLine("lives: " + _playerLives);
        }
    }
}
