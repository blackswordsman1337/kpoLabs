using System;
using System.Collections.Generic;

namespace KPOLab2
{
    internal static class ObjectCreator
    {
        public static int flowerCount;
        public static int bouqetCount;

        public static Flower CreateFlower(ColorsEnum color)
        {
            flowerCount++;
            if (color == ColorsEnum.Red)
                return new RedFlower();
            else if (color == ColorsEnum.Green)
                return new GreenFlower();
            else
                return new BlueFlower();
        }

        public static Bouquet CreateBouquet(List<Flower> flowers)
        {
            bouqetCount++;
            return new Bouquet(flowers);
        }

        public static Bouquet CreateBouquet(List<Flower> flowers, int capacity)
        {
            bouqetCount++;
            return new Bouquet(flowers, capacity);
        }

        public static List<Flower> CreateFlowers(List<ColorsEnum> colors)
        {
            var flowers = new List<Flower>();
            foreach (var color in colors)
            {
                flowers.Add(CreateFlower(color));
                flowerCount++;
            }

            return flowers;
        }

        public static List<Bouquet> CreateBouquets(int count)
        {
            var bouquets = new List<Bouquet>();
            for (int i = 0; i < count; i++)
            {
                bouquets.Add(CreateBouquet(CreateFlowers(
                    new List<ColorsEnum> { ColorsEnum.Red, ColorsEnum.Green, ColorsEnum.Blue })));
                bouqetCount++;
            }

            return bouquets;
        }
    }
}