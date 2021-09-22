using System;

namespace pa2
{
    public class Character : IThrow
    {
        public string name {get; set;}
        public int maxPower {get; set;}
        public int health {get; set;}
        public int throwPower {get; set;}
        public int defensivePower{get; set;}
        public string special{get; set;}
        public Character() {
            name = null;
            maxPower = 0;
            health = 0;
            throwPower = 0;
            defensivePower = 0;
        }

        public Character (string n, int mp, int h, int tp, int dp) {
            name = n;
            maxPower = mp;
            health = h;
            throwPower = tp;
            defensivePower = dp;
        }

        public void ShowStats() {
            Console.WriteLine(name + " - Max Power: " + maxPower + " Health: " + health);
        }

        public int TakeDamage(int damage) {
            Console.WriteLine(this.name + " took " + damage + " points of damage!");
            health -= damage;
            if (health <= 0) return 0;
            else return 1;
        }

        private double CalculateDamage(int oPower, int dPower, double multiplier) {
            if (dPower > oPower) {
                Console.WriteLine("But all damage was blocked!");
                return 0;
            }
            return (oPower - dPower) * multiplier;
        }

        private void RandomizeThrowPower() {
            Random rd = new Random();
            throwPower = rd.Next(1, maxPower);
        }

        private void RandomizeDefensivePower() {
            Random rd = new Random();
            defensivePower = rd.Next(1, maxPower);
        }

        public static string DetermineType(string food) {
            if (food == "fries" || food == "hash brown" || food == "chicken nuggets") return "salty";
            else if (food == "hamburger" || food == "chicken sandwich" || food == "filet-o-fish") return "savory";
            else if (food == "ice cream" || food == "mcflurry" || food == "apple pie") return "sweet";
            else return "salty";
        }

        public void ThrowFood(string foodType, Character target) {
            this.RandomizeThrowPower();
            target.RandomizeDefensivePower();

            if (foodType == "salty" && target.name == "Ronald McDonald" || foodType == "sweet" && target.name == "Hamburglar" || foodType == "savory" && target.name == "Fry Kids") {
                //super effective
                Console.WriteLine(this.name + " threw with a power of " + this.throwPower + "! " + target.name + " defended with a power of " + target.defensivePower + "! It's super effective!");
                target.TakeDamage(Convert.ToInt32(CalculateDamage(this.throwPower, target.defensivePower, 1.2)));
            }
            else if (foodType == "salty" && target.name == "Hamburglar" || foodType == "savory" && target.name == "Ronald McDonald" || foodType == "sweet" && target.name == "Fry Kids") {
                //not as effective
                Console.WriteLine(this.name + " threw with a power of " + this.throwPower + "! " + target.name + " defended with a power of " + target.defensivePower + "! It's not very effective...");
                target.TakeDamage(Convert.ToInt32(CalculateDamage(this.throwPower, target.defensivePower, .8)));
            }
            else {
                //normally effective
                Console.WriteLine(this.name + " threw with a power of " + this.throwPower + "! " + target.name + " defended with a power of " + target.defensivePower + "!");
                target.TakeDamage(Convert.ToInt32(CalculateDamage(this.throwPower, target.defensivePower, 1)));
            }
        }
    }
}