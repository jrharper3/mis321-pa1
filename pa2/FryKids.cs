using System;

namespace pa2
{
    public class FryKids : Character
    {
        public FryKids() {
            Random rd = new Random();
            
            name = "Fry Kids";
            health = 100;
            special = "Extra Fries";
            maxPower = rd.Next(1, 100);
            throwPower = rd.Next(1, maxPower);
            defensivePower = rd.Next(1, maxPower);
        }
    }
}