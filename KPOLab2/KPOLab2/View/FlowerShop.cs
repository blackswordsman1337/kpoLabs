using System;
using System.Collections.Generic;

namespace KPOLab2
{
    internal class FlowerShop
    {
        public static int FunctioningShopsCount { get; private set; }
        public static int ActionsMade { get; private set; } // number of actions made

        public readonly string Name;

        private readonly static int s_defaultFlowerCount;

        private int _flowerCount;

        static FlowerShop()
        {
            s_defaultFlowerCount = 100;
        }

        public FlowerShop()
        {
            FunctioningShopsCount++;

            Name = "Flower Shop " + FunctioningShopsCount.ToString();
            _flowerCount = s_defaultFlowerCount;
        }

        public FlowerShop(string name)
        {
            FunctioningShopsCount++;

            Name = name;
            _flowerCount = s_defaultFlowerCount;
        }

        public FlowerShop(string name, int flowerCount) : this(name)
        {
            _flowerCount = flowerCount;
        }

        public Bouquet MakeBouquet(List<Flower> flowers)
        {
            if (flowers == null)
                throw new ArgumentException("Flowers list is null!");

            ActionsMade++;

            return ObjectCreator.CreateBouquet(flowers);
        }

        public Flower BuyFlower(ColorsEnum color)
        {
            if (_flowerCount <= 0)
                throw new InvalidOperationException("The shop is empty.");

            ActionsMade++;

            _flowerCount--;

            return ObjectCreator.CreateFlower(color);
        }

        public Bouquet BuyBouquet(List<ColorsEnum> colors)
        {
            if (colors == null)
                throw new ArgumentException("Colors list is null!");

            if (_flowerCount - colors.Count <= 0)
                throw new InvalidOperationException("The shop doesn't have this many flowers.");

            ActionsMade++;

            _flowerCount -= colors.Count;

            var flowers = MakeFlowersList(colors);
            return MakeBouquet(flowers);
        }

        private List<Flower> MakeFlowersList(List<ColorsEnum> colors)
        {
            var flowers = new List<Flower>();
            foreach (var color in colors)
            {
                flowers.Add(ObjectCreator.CreateFlower(color));
            }

            return flowers;
        }
    }
}