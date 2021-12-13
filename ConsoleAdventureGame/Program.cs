using System;

namespace TurnBasedConsoleAdventureGame
{
    struct Player
    {
        public int mana;
        public int health;
        public int attack;
        public int lvl;

        public Player(int mana, int health, int attack, int lvl)
        {
            this.mana = mana;
            this.health = health;
            this.attack = attack;
            this.lvl = lvl;
        }

        public void showStats()
        {
            Console.WriteLine("Player health is: " + health);
            Console.WriteLine("Player mana is: " + mana);
        }
        public void showLvl()
        {
            Console.WriteLine("Player level is: " + lvl);
        }
    }

    struct Enemy
    {
        public int health;
        public int attack;
        public int magicResist;

        public Enemy(int health, int attack, int magicResist)
        {
            this.health = health;
            this.attack = attack;
            this.magicResist = magicResist;
        }

        public void showStats()
        {
            Console.WriteLine("Enemy health is: " + health);
            Console.WriteLine("Enemy attack is: " + attack);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Welcome
            Player p = new Player(150, 100, 10, 0); //mana, health, attack, lvl
            //this is you
            //rules
            //starting

            bool gameOver = false;
            int enemiesSlain;

            do
            {
                Random r = new Random();
                int attack = 10;
                Enemy e = new Enemy(150, attack, r.Next(0, 1 + 1)); //health, attack, magic resistance

                WriteMsg("Beginning stats: ", ConsoleColor.Green);
                p.showStats();
                e.showStats();
                if (e.magicResist == 1)
                    Console.WriteLine("Enemy is magic resistant!");
                Console.WriteLine();

                while(e.health > 0)
                {
                    WriteMsg("Press -A- for Sword Attack,\nPress -M- for Magic Strike,\nPress -H- for Healing Spell,\n" +
                        "Press -P- for Poison Spell,\nPress -R- to Restore Mana,\nPress -Q- to exit the game.", ConsoleColor.Blue);

                    ConsoleKeyInfo userPressed = Console.ReadKey();
                    ConsoleKey userKey = userPressed.Key;

                    if(userKey == ConsoleKey.A)
                    {

                    }

                    attack = attack + 3;
                }


            } while (!gameOver);


            
           

            

        }

        public static void WriteMsg(string msg, ConsoleColor FGColor)
        {
            Console.ForegroundColor = FGColor;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
