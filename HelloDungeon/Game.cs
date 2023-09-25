using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HelloDungeon
{

        struct Weapon
        {
            public string Name;
            public float Damage;
        }
    class Game
    {





        bool gameOver;
        int currentScene = 0;


        //declares the character (establishing that they exist, not stating their stats)
        //this is the first step?
        Character JoePable;
        Character JohnCena;
        Character LucyJill;
        Character Gu7y;
        Character[] Enemies;
        int currentEnemyIndex = 0;


        // this means its not set to look at anything and when its not set to look at something, it (by default) looks at 0, or in other words; null;
        Player Player;


        void Fight(ref Character monster2)
        {
            Console.WriteLine("\n\n");
            Player.PrintStats();
            Console.WriteLine("\n\n");
            monster2.PrintStats();
            Console.WriteLine("\n\n");

            bool isDefending = false;
            string battleChoice = Player.GetInput("Choose an action", "Attack", "Defend", "Run");

            if (battleChoice == "1")
            {
                monster2.TakeDamage(Player.GetDamage());
                Console.WriteLine("You used " + Player.GetWeapon().Name + " !\n\n");
                
                if (monster2.GetHealth() <= 0)
                {
                    return;
                }
            }
            else if (battleChoice == "2")
            {
                isDefending = true;
                Player.RaiseDefense();
                Console.WriteLine("You grit your teeth.");
            }
            else if (battleChoice == "3")
            {
                Console.WriteLine("You fled from the battle as fast as you could!");
                currentScene = 2;
                return;
            }

            Console.WriteLine(monster2.GetName() + " punches " + Player.GetName() + "!");
            Player.TakeDamage(Player.GetDamage());
            Console.ReadKey(true);

            if (isDefending == true)
            {
                Player.ResetDefense();
            }
        }

        float Heal(Character monster, float healAmount)
        {
            float newHealth = monster.GetHealth() + healAmount;

            return newHealth;
        }




        
        void CharacterSelectScene()
        {
            Player = new Player();
            string characterChoice = Player.GetInput("Choose Your Character", JoePable.GetName(), JohnCena.GetName(), LucyJill.GetName(), Gu7y.GetName());

            if (characterChoice == "1")
            {
                Player = new Player(JoePable.GetName(), JoePable.GetHealth(), JoePable.GetDamage(), JoePable.GetDefense(), JoePable.GetDefenseBoost(), JoePable.GetStamina(), JoePable.GetCurrentWeapon());
            }
            else if (characterChoice == "2")
            {
                Player = new Player(JohnCena.GetName(), JohnCena.GetHealth(), JohnCena.GetDamage(), JohnCena.GetDefense(), JohnCena.GetDefenseBoost(), JohnCena.GetStamina(), JohnCena.GetCurrentWeapon());
            }
            else if (characterChoice == "3")
            {
                Player = new Player(LucyJill.GetName(), LucyJill.GetHealth(), LucyJill.GetDamage(), LucyJill.GetDefense(), LucyJill.GetDefenseBoost(), LucyJill.GetStamina(), LucyJill.GetCurrentWeapon());
            }
            else if (characterChoice == "4")
            {
                Player = new Player(Gu7y.GetName(), Gu7y.GetHealth(), Gu7y.GetDamage(), Gu7y.GetDefense(), Gu7y.GetDefenseBoost(), Gu7y.GetStamina(), Gu7y.GetCurrentWeapon());
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }

            Player.PrintStats();
            Console.ReadKey(true);
            Console.Clear();
            currentScene = 1;
        }

        void BattleScene()
        {
            Fight(ref Enemies[currentEnemyIndex]);

            Console.Clear();

            if (Player.GetHealth() <= 0 || Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                currentScene = 2;
            }
        }

        void WinResultsScene()
        {
            if (Player.GetHealth() > 0 && Enemies[currentEnemyIndex].GetHealth() <= 0)
            {
                Console.WriteLine("The winner is: " + Player.GetName());
                currentScene = 1;
                currentEnemyIndex++;

                if (currentEnemyIndex >= Enemies.Length)
                {
                    gameOver = true;
                }
            }
            else if (Enemies[currentEnemyIndex].GetHealth() > 0 && Player.GetHealth() <= 0)
            {
                Console.WriteLine("The winner is: " + Enemies[currentEnemyIndex].GetName());
                currentScene = 3;
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        void EndGameScene()
        {
            string playerChoice = Player.GetInput("You Died. Play Again?", "Yes", "No");

            if (playerChoice == "1")
            {
                currentScene = 0;
            }
            else if (playerChoice == "2")
            {
                gameOver = true;
            }
            else 
            {
                Console.WriteLine("invalid");
                Console.ReadKey(true);
                Console.Clear();
                return;
            }
            Console.Clear();
        }

        void Start()
        {
            Weapon deezHandz;
            deezHandz.Name = "Deez Handz";
            deezHandz.Damage = 5f;

            Weapon chairAdjustment;
            chairAdjustment.Name = "Chair Adjustment";
            chairAdjustment.Damage = 7f;

            Weapon bidenBlast;

            bidenBlast.Name = "You've done well to make it this far but I've only been using " +
                ".1% of my power. \n Now get ready to face my BIDEN...BLAST!!!!";
            bidenBlast.Damage = 9000.01f;


            Weapon swardd;
            swardd.Name = "swardd";
            swardd.Damage = 6f;

            //these lines are meant to intialize a new character with its stats
            //this is the next step?
            JoePable = new Character("JoePable", 19f, 18f, 3f, 50f, 3f, deezHandz);
            JohnCena = new Character("JOHN.....cena", 21f, 11f, 5f, 25f, 4f, chairAdjustment);
            LucyJill = new Character("Lucy Jill Dirtbag Biden", 18f, 10f, 4f, 5f, 1f, chairAdjustment);

            Gu7y = new Character("Gh7y", 25f, 10f, 4f, 7f, 5f, swardd);



            //                           0         1         2  
            Enemies = new Character[4] { Gu7y, JoePable, JohnCena, LucyJill };

        }

        void Update()
        {
            if (currentScene == 0)
            {
                CharacterSelectScene();
            }
            else if (currentScene == 1)
            {
                BattleScene();
            }
            else if (currentScene == 2)
            {
                WinResultsScene();
            }
            else if (currentScene == 3)
            {
                EndGameScene();
            }
        }

        void End()
        {
            Console.WriteLine("Thanks for playing");
        }

        public void Run()
        {
            //start - called before the first loop
            //Used to initialize variables at the beginning of the game.
            Start();

            while (gameOver == false)
            {
                //update - called every time the game loops
                //Used to update game logic like player input, character positions, game timers, etc.
                Update();
            }

            //end - called after the main game loop exits
            //Used to clean up memory or display end game messages.
            End();
        }
    }
}