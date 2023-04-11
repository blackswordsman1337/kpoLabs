﻿namespace KPOLab2
{
    internal class FlowerShop
    {
        public static int ActionsMade { get; private set; } //number of actions made

        public Bouquet MakeBouquet(Flower[] flowers)
        {
            if (flowers == null) throw new ArgumentException("Flowers array is null!");

            ActionsMade++;

            return new Bouquet(flowers);
        }

        public Flower BuyFlower(ColorsEnum color)
        {
            ActionsMade++;

            return new Flower(color);
        }

        public Bouquet BuyBouquet(ColorsEnum[] colors) 
        {
            if (colors == null) throw new ArgumentException("Colors array is null!");

            ActionsMade++;

            var flowers = new List<Flower>();
            foreach (var color in colors)
            {
                flowers.Add(new Flower(color));
            }

            return new Bouquet(flowers.ToArray());
        }
    }
}