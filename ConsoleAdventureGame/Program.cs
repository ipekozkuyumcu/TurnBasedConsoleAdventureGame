using System;

namespace TurnBasedConsoleAdventureGame
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteMsg("Welcome to an endless dungeon!\n" +
                "This is you: \n", ConsoleColor.DarkMagenta);

            Console.WriteLine(@" 
             ////^\\\\
             | ^   ^ |
            @ (o) (o) @
             |   <   |
             |  ___  |
              \_____/
            ____|  |____
           /    \__/    \
          /              \
         /\_/|        |\_/\
        / /  |        |  \ \
       ( <   |        |   > )
        \ \  |        |  / /
         \ \ |________| / /
           
             
                              ");

            WriteMsg("You will face enemies which gets stronger each turn and level.\n" +
                "Read instructions carefully and choose wisely.\n" +
                "Good Luck!\n\n" +
                "Press any key to start.\n", ConsoleColor.DarkMagenta);
            Console.ReadKey();
            Console.Write("\b \b");

            Player p = new Player(150, 200, 10, 1); //mana, health, attack, lvl

            Enemy e = new Enemy(100, 10, 0); //health, attack, magic resistance

            bool gameOver = false;
            int enemiesSlain = 0;

            do
            {
                Random r = new Random();

                if(r.Next(0, 1 + 1) == 0)
                {
                    e.magicResist = 0;
                }
                else
                {
                    e.magicResist = 1;
                }

                //enemy ascii art, if magic resistance different
                if (e.magicResist == 1)
                {
                    Console.WriteLine(@" 
                       ,    ,    /\   /\
                      /( /\ )\  _\ \_/ /_
                      |\_||_/| < \_   _/ >
                      \______/  \|0   0|/
                        _\/_   _(_  ^  _)_
                       ( () ) /`\|V'''V |/`\
                         {}   \  \_____/  /
                         ()   /\   )=(   /\
                         {}  /  \_/\=/\_/  \");

                    Console.WriteLine("Enemy above is what you you will face with. It is magic resistant! You can't apply spell damage. \n");
                }
                else if(e.magicResist == 0)
                {
                    Console.WriteLine(@"         
                          .-.
                         (o.o)
                          |=|
                         __|__
                       //.=|=.\\
                      // .=|=. \\
                      \\ .=|=. //
                       \\(_=_)//
                        (:| |:)
                         || ||
                         () ()
                         || ||
                         || ||
                        ==' '==");

                    Console.WriteLine("You will face with not magic resistant enemy above. You can apply spell damage.\n");
                }
                    

                WriteMsg("Beginning stats: ", ConsoleColor.Green);
                e.showStats();
                p.showStats();
                p.showLvl();
                Console.WriteLine();


                while(e.health > 0 && p.health > 0)
                {
                   WriteMsg("Press -A- for Sword Attack (hits the enemy with your attack value),\n" +
                        "Press -M- for Magic Strike (hits the enemy with your attack value +2) (costs 5 mana),\n" +
                        "Press -P- for Poison Spell (hits the enemy with your attack value +2, enemy can't hit you back) (costs 10 mana),\n"+
                        "Press -H- for Healing Spell (restores 10 health) (costs 7 mana),\n" +
                        "Press -R- to Restore Mana (restores 10 mana),\n" +
                        "Press -Q- to exit the game.\n", ConsoleColor.Blue);

                    ConsoleKeyInfo userPressed = Console.ReadKey();
                    ConsoleKey userKey = userPressed.Key;
                    Console.Write("\b \b");

                    if(userKey == ConsoleKey.A)
                    {
                        //Sword Attack (attack) 
                        WriteMsg("You have attacked the enemy with " + p.attack + " using Sword Attack!\n", ConsoleColor.Cyan);
                        e.health = e.health - p.attack;
                        WriteMsg("Enemy hit you back with " + e.attack + "!\n", ConsoleColor.Red);
                        p.health = p.health - e.attack;

                        WriteMsg("New stats: ", ConsoleColor.DarkYellow);
                        e.showStats();
                        p.showStats();

                    }
                    else if(userKey == ConsoleKey.M)
                    {
                        //Magic Strike (can't if magic resistance) (attack +2) (5 mana)
                        if(e.magicResist == 0)
                        {
                            p.mana = p.mana - 5;
                            WriteMsg("You have attacked the enemy " + (p.attack + 2) + " using Magic Strike!\n", ConsoleColor.Cyan);
                            e.health = e.health - (p.attack + 2);
                            WriteMsg("Enemy hit you back with " + e.attack + "!\n", ConsoleColor.Red);
                            p.health = p.health - e.attack;

                            WriteMsg("New stats: ", ConsoleColor.DarkYellow);
                            e.showStats();
                            p.showStats();
                        }
                        else if(e.magicResist == 1)
                        {
                            p.mana = p.mana - 5;
                            WriteMsg("You can't use magic on an enemy with magic resistance!\n", ConsoleColor.DarkGray);
                            WriteMsg("Enemy hit you with " + e.attack + "!\n", ConsoleColor.Red);
                            p.health = p.health - e.attack;

                            WriteMsg("New stats: ", ConsoleColor.DarkYellow);
                            e.showStats();
                            p.showStats();
                        }
                    }
                    else if (userKey == ConsoleKey.H)
                    {
                        //Healing (10 heatlh) (7 mana)
                        p.mana = p.mana - 7;
                        WriteMsg("You have restored 10 health.\n", ConsoleColor.Cyan);
                        p.health = p.health + 10;
                        WriteMsg("Enemy hit you with " + e.attack + "!\n", ConsoleColor.Red);
                        p.health = p.health - e.attack;

                        WriteMsg("New stats: ", ConsoleColor.DarkYellow);
                        e.showStats();
                        p.showStats();
                    }
                    else if (userKey == ConsoleKey.P)
                    {
                        //Poison Spell (can't if magic resistance) (attack +2) (10 mana)
                        if (e.magicResist == 0)
                        {
                            p.mana = p.mana - 10;
                            WriteMsg("You have attacked the enemy " + (p.attack + 2) + " using Poison Spell. Enemy can only attack you with half damage this turn.\n", ConsoleColor.Cyan);
                            e.health = e.health - (p.attack + 2);
                            WriteMsg("Enemy hit you with " + e.attack/2 + "!\n", ConsoleColor.Red);
                            p.health = p.health - (e.attack/2);

                            WriteMsg("New stats: ", ConsoleColor.DarkYellow);
                            e.showStats();
                            p.showStats();
                        }
                        else if (e.magicResist == 1)
                        {
                            p.mana = p.mana - 10;
                            WriteMsg("You can't use magic on an enemy with magic resistance!\n", ConsoleColor.DarkGray);
                            WriteMsg("Enemy hit you with " + e.attack + "!\n", ConsoleColor.Red);
                            p.health = p.health - e.attack;

                            WriteMsg("New stats: ", ConsoleColor.DarkYellow);
                            e.showStats();
                            p.showStats();
                        }
                    }
                    else if (userKey == ConsoleKey.R)
                    {
                        //Restore Mana (10)
                        WriteMsg("You have restored 10 mana.\n", ConsoleColor.Cyan);
                        p.mana = p.mana + 10;
                        WriteMsg("Enemy hit you with " + e.attack + "!\n", ConsoleColor.Red);
                        p.health = p.health - e.attack;

                        WriteMsg("New stats: ", ConsoleColor.DarkYellow);
                        e.showStats();
                        p.showStats();
                    }
                    else if (userKey == ConsoleKey.Q)
                    {
                        //exit
                        WriteMsg("You have quit the game. Press any key to continue.\n", ConsoleColor.Cyan);
                        Console.ReadKey();
                        gameOver = true;
                        break;
                    }
                    
                    e.attack = e.attack + 3;

                }

                if(p.health > 0)
                {
                    p.lvl++;
                    enemiesSlain++;

                    WriteMsg("End Turn Stats: ", ConsoleColor.DarkYellow);
                    p.showLvl();
                    Console.WriteLine("Total number of enemies slain: " + enemiesSlain + "\n");

                    e.health = 100 + (p.lvl + 2);

                    WriteMsg("Choose an upgrade: \n" +
                        "To gain 50 health press -A-,\n" +
                        "To gain 25 mana press -B-,\n" +
                        "To gain 10 attack press -C-\n", ConsoleColor.Blue);

                    ConsoleKeyInfo userPressed = Console.ReadKey();
                    ConsoleKey userKey = userPressed.Key;
                    Console.Write("\b \b");

                    if (userKey == ConsoleKey.A)
                    {
                        //gain 50 health
                        p.health = p.health + 50;
                        WriteMsg("You have gain 50 health. Your health is " + p.health + " now. Press any key to continue to next level.\n", ConsoleColor.DarkMagenta);
                        Console.ReadKey();
                    }
                    else if (userKey == ConsoleKey.B)
                    {
                        //gain 25 mana
                        p.mana = p.mana + 25;
                        WriteMsg("You have gain 25 mana. Your mana is " + p.mana + " now\n", ConsoleColor.DarkMagenta);
                        Console.ReadKey();
                    }
                    else if (userKey == ConsoleKey.C)
                    {
                        //gain 10 attack
                        p.attack = p.attack + 10;
                        WriteMsg("You have gain 10 attack. Your health is " + p.attack + " now\n", ConsoleColor.DarkMagenta);
                        Console.ReadKey();
                    }


                }
                else if (p.health <= 0 && e.health <= 0)
                {
                    enemiesSlain++;
                    WriteMsg("Your have no more health. Press any key to continue.\n", ConsoleColor.DarkGray);
                    Console.ReadKey();
                    Console.Write("\b \b");
                    gameOver = true;
                }
                else if (p.health <= 0)
                {
                    WriteMsg("Your have no more health. Press any key to continue.\n", ConsoleColor.DarkGray);
                    Console.ReadKey();
                    Console.Write("\b \b");
                    gameOver = true;
                }

            } while (!gameOver);

            WriteMsg("Game is over.\n" +
                "Your score is: " + enemiesSlain, ConsoleColor.DarkMagenta);

        }

        public static void WriteMsg(string msg, ConsoleColor FGColor)
        {
            Console.ForegroundColor = FGColor;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }

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
            Console.WriteLine("Player attack is: " + attack + "\n");
        }
        public void showLvl()
        {
            Console.WriteLine("Player level is: " + lvl + "\n");
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
            Console.WriteLine("Enemy attack is: " + attack + "\n");
        }
    }

}
