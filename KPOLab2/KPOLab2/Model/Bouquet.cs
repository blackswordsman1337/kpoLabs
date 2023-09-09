using System;
using System.Collections.Generic;

namespace KPOLab2
{
    internal class Bouquet : IEnumerable<Flower>
    {
        public static int BouquetsMade { get; private set; } // number of bouquets made

        public List<Flower> Flowers { get; private set; }

        public double WeightGrams
        {
            get
            {
                var weight = 0d;
                foreach (var flower in Flowers)
                {
                    weight += flower.WeightGrams;
                }

                return weight;
            }
        }
        public double Price
        {
            get
            {
                var price = 0d;
                foreach (var flower in Flowers)
                {
                    price += flower.Price;
                }

                return price;
            }
        }

        public Flower TheCheapestFlower
        {
            get
            {
                var theCheapestFlower = Flowers[0];
                foreach (var flower in Flowers)
                {
                    if (flower.Price < theCheapestFlower.Price)
                        theCheapestFlower = flower;
                }

                return theCheapestFlower;
            }
        }
        public Flower TheMostExpensiveFlower
        {
            get
            {
                var theMostExpensiveFlower = Flowers[0];
                foreach (var flower in Flowers)
                {
                    if (flower.Price > theMostExpensiveFlower.Price)
                        theMostExpensiveFlower = flower;
                }

                return theMostExpensiveFlower;
            }
        }

        public Bouquet(List<Flower> flowers)
        {
            if (flowers == null)
                throw new ArgumentException("Flowers list is null!");

            Flowers = flowers;

            BouquetsMade++;
        }

        public Bouquet(List<Flower> flowers, int capacity)
        {
            if (flowers == null)
                throw new ArgumentException("Flowers list is null!");

            Flowers = new List<Flower>(capacity);
            for (int i = 0; i < capacity; i++)
            {
                Flowers.Add(flowers[i]);
            }

            BouquetsMade++;
        }

        public Flower this[int index]
        {
            get
            {
                return Flowers[index];
            }
            set
            {
                Flowers[index] = value;
            }
        }

        public void LeaveOnlyRedFlowers()
        {
            Flowers.RemoveAll(flower => !(flower is RedFlower));
        }

        public void LeaveOnlyBlueFlowers()
        {
            Flowers.RemoveAll(flower => !(flower is BlueFlower));
        }

        public void LeaveOnlyGreenFlowers()
        {
            Flowers.RemoveAll(flower => !(flower is GreenFlower));
        }

        public IEnumerator<Flower> GetEnumerator()
        {
            return Flowers.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Flowers.GetEnumerator();
        }
    }
}