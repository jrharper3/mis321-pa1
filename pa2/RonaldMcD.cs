using System;

namespace pa2
{
    public class RonaldMcD : Character
    {
        public RonaldMcD() {
            Random rd = new Random();
            
            name = "Ronald McDonald";
            health = 100;
            special = "Clown Around";
            maxPower = rd.Next(1, 100);
            throwPower = rd.Next(1, maxPower);
            defensivePower = rd.Next(1, maxPower);
        }
    }
}