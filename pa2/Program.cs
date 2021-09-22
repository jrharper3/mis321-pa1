using System;
using System.Threading;

namespace pa2
{
    class Program
    {
        static string RandFood() {
            string[] food = {"fries", "chicken nuggets", "hash brown", "hamburger", "chicken sandwich", "filet-o-fish", "ice cream", "mcflurry", "apple pie"};
            Random rd = new Random();
            return food[rd.Next(0,9)];
        }
        static void BattlePrep() {
            Console.Clear();
            Character Player1;
            Character Player2;
            Console.WriteLine("Let's get ready to Foooooooood Fight!!\n\nPlayer One, select from one of the characters below:");

            while (true) {
            Console.WriteLine("1. Hamburglar (Type: Savory)\n2. Ronald McDonald (Type: Sweet)\n3. FryKids (Type: Salty)");

            //player one selects
            int userSelection = int.Parse(Console.ReadLine());
            if (userSelection == 1) {
                Console.WriteLine("You have selected the Hamburglar!");
                Player1 = new Hamburglar();
                break;
            }
            else if (userSelection == 2) {
                Console.WriteLine("You have selected Ronald McDonald!");
                Player1 = new RonaldMcD();
                break;
            }
            else if (userSelection == 3) {
                Console.WriteLine("You have selected the Fry Kids!");
                Player1 = new FryKids();
                break;
            }
            else {
                Console.WriteLine("Invalid selection. Please try again.");
            }
            }

            Console.Clear();
            //player 2 selects
            Console.WriteLine("Player Two, select from one of the characters below:");

            while (true) {
            Console.WriteLine("1. Hamburglar (Type: Savory)\n2. Ronald McDonald (Type: Sweet)\n3. FryKids (Type: Salty)");

            int userSelection = int.Parse(Console.ReadLine());
            if (userSelection == 1) {
                Console.WriteLine("You have selected the Hamburglar!");
                Player2 = new Hamburglar();
                break;
            }
            else if (userSelection == 2) {
                Console.WriteLine("You have selected Ronald McDonald!");
                Player2 = new RonaldMcD();
                break;
            }
            else if (userSelection == 3) {
                Console.WriteLine("You have selected the Fry Kids!");
                Player2 = new FryKids();
                break;
            }
            else {
                Console.WriteLine("Invalid selection. Please try again.");
            }
            }

            CoinToss(Player1, Player2);
            Thread.Sleep(2000);
        }

        static void CoinToss(Character p1, Character p2) {
            Console.Clear();
            Console.WriteLine("Let's see who goes first! Flipping a coin...");
            Random rd = new Random();
            int coin = rd.Next(0,2);

            if (coin == 0) {
                Console.WriteLine("Heads! Player 1 will go first.");
                BattlePhase(p1, p2);
            }

            else if (coin == 1) {
                Console.WriteLine("Tails! Player 2 will go first.");
                BattlePhase(p2, p1);
            }
        }

        static void BattlePhase(Character p1, Character p2) {
            Thread.Sleep(2000);
            Console.Clear();
            int p1SpecialCharge = 1;
            int p2SpecialCharge = 1;
            Console.WriteLine("Ready... Set... Food Fight!");

            while (true) {
                p1.ShowStats();
                p2.ShowStats();
                Console.WriteLine("\n");
                //p1 turn
                string food1 = RandFood();
                string food2 = RandFood();
                Console.Write(p1.name + ", what move will you make?\n1. Throw " + food1 + "\n2. Throw " + food2);
                if (p1SpecialCharge != 0) Console.WriteLine("\n3. " + p1.special);
                else Console.WriteLine("\n");

                int userSelection = int.Parse(Console.ReadLine());

                if (userSelection == 1) {
                    p1.ThrowFood(Character.DetermineType(food1), p2);
                }
                else if (userSelection == 2) {
                    p1.ThrowFood(Character.DetermineType(food2), p2);
                }
                else if (userSelection == 3 && p1SpecialCharge != 0) {
                    p1SpecialCharge = 0;
                    if (p1.special == "Extra Fries") {
                        p1.ThrowFood(Character.DetermineType("fries"), p2);
                        Console.WriteLine("\nWant some Extra Fries with that?\n");
                        p1.ThrowFood(Character.DetermineType("fries"), p2);
                    }
                    else if (p1.special == "Hamburglarize") {
                        p1.ThrowFood(Character.DetermineType("hamburger"), p2);
                        Console.WriteLine("\nRobble robble, this looks tasty!\n\nRestored 25 health!\n");
                        p1.health += 25;
                    }
                    else if (p1.special == "Clown Around") {
                        int temp = p1.maxPower;
                        p1.maxPower = 100;
                        Console.WriteLine("\nLet's put a smile on that face!\n");
                        p1.ThrowFood(Character.DetermineType("chicken nuggets"), p2);
                        p1.maxPower = temp;
                    }
                }
                else {
                Console.WriteLine("\nInvalid selection. Please try again.");
                }

                p1.ShowStats();
                p2.ShowStats();

                if (p2.health <= 0) {
                    Console.WriteLine(p2.name + " has no health remaining. You win the Food Fight!\n\nThanks for playing!");
                    Thread.Sleep(6000);
                    return;
                }
                Thread.Sleep(5000);
                Console.Clear();
                //p2 turn
                p1.ShowStats();
                p2.ShowStats();
                Console.WriteLine("\n");
                food1 = RandFood();
                food2 = RandFood();
                Console.Write(p2.name + ", what move will you make?\n1. Throw " + food1 + "\n2. Throw " + food2);
                if (p2SpecialCharge != 0) Console.WriteLine("\n3. " + p2.special);
                else Console.WriteLine("\n");

                userSelection = int.Parse(Console.ReadLine());

                if (userSelection == 1) {
                    p2.ThrowFood(Character.DetermineType(food1), p1);
                }
                else if (userSelection == 2) {
                    p2.ThrowFood(Character.DetermineType(food2), p1);
                }
                else if (userSelection == 3 && p2SpecialCharge != 0) {
                    p2SpecialCharge = 0;
                    if (p2.special == "Extra Fries") {
                        p2.ThrowFood(Character.DetermineType("fries"), p1);
                        Console.WriteLine("\nWant some Extra Fries with that?\n");
                        p2.ThrowFood(Character.DetermineType("fries"), p1);
                    }
                    else if (p2.special == "Hamburglarize") {
                        p2.ThrowFood(Character.DetermineType("hamburger"), p1);
                        Console.WriteLine("\nRobble robble, this looks tasty!\n\nRestored 25 health!\n");
                        p2.health += 25;
                    }
                    else if (p2.special == "Clown Around") {
                        int temp = p2.maxPower;
                        p2.maxPower = 100;
                        Console.WriteLine("\nLet's put a smile on that face!\n");
                        p2.ThrowFood(Character.DetermineType("chicken nuggets"), p1);
                        p2.maxPower = temp;
                    }
                }
                else {
                Console.WriteLine("\nInvalid selection. Please try again.");
                }

                p1.ShowStats();
                p2.ShowStats();
                if (p1.health <= 0) {
                    Console.WriteLine(p1.name + " has no health remaining. You win the Food Fight!\n\nThanks for playing!");
                    Thread.Sleep(6000);
                    return;
                }
                Thread.Sleep(5000);
                Console.Clear();
            }
        }
        static void DisplayMenu() {

            while (true) {
            Console.Clear();
            Console.WriteLine("Hello, and welcome to the Ultimate Food Fight, Battle of the Ages! Please make a selection:\n\n1. Play the game with two players\n2. View type effectiveness summary\n3. Exit");
            int userSelection = int.Parse(Console.ReadLine());

            if (userSelection == 1) {
                BattlePrep();
            }
            else if (userSelection == 2) {
                Console.WriteLine("There are three types of food in this fight. Salty, Savory, and Sweet. Each character will also have one of these types.\nCharacters hit by a food type they are weak to receive 20% more damage, while receiving 20% less against foods they are the same type as.\n");
                Console.WriteLine("Savory beats/resists Sweet, Sweet beats/resists Salty, and Salty beats/resists Savory.\n"); 
                Console.WriteLine("\nEach character has their own special ability.\nFry Kids - Extra Fries: Throws fries at the opponent twice\nRonald McDonald - Clown Around: Maxes out maxpower for one throw of chicken nuggets\nHamburglar - Hamburglarize: Throws a hamburger, then restores 25 health.");
                Thread.Sleep(20000);
            }
            else if (userSelection == 3) {
                Console.WriteLine("\nThank you for playing! Exiting the fight...");
                return;
            }
            else {
                Console.WriteLine("\nInvalid selection. Please try again.");
            }
            }

        }
        static void Main(string[] args)
        {
            DisplayMenu();
        }
    }
}
