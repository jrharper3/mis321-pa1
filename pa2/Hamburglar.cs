using System;

namespace pa2
{
    public class Hamburglar : Character
    {
        public Hamburglar() {
            Random rd = new Random();
            
            name = "Hamburglar";
            health = 100;
            special = "Hamburglarize";
            maxPower = rd.Next(1, 100);
            throwPower = rd.Next(1, maxPower);
            defensivePower = rd.Next(1, maxPower);
        }
    }
}