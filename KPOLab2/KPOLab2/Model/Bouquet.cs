using System.Collections;

namespace KPOLab2
{
    internal class Bouquet : IEnumerable<Flower>
    {
        public static int BouquetsMade { get; private set; } //number of bouquets made

        public Flower[] Flowers { get; private set; }

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

        public Bouquet(Flower[] flowers)
        {
            if (flowers == null) 
                throw new ArgumentException("Flowers array is null!");

            Flowers = flowers;

            BouquetsMade++;
        }

        public Bouquet(Flower[] flowers, int capacity)
        {
            if (flowers == null) 
                throw new ArgumentException("Flowers array is null!");

            Flowers = new Flower[capacity];
            for (int i = 0; i < capacity; i++)
            {
                Flowers[i] = flowers[i];
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
            var newFlowers = new List<Flower>();
            FillFlowerList<RedFlower>(newFlowers);

            Flowers = newFlowers.ToArray();
        }

        public void LeaveOnlyBlueFlowers()
        {
            var newFlowers = new List<Flower>();
            FillFlowerList<BlueFlower>(newFlowers);

            Flowers = newFlowers.ToArray();
        }

        public void LeaveOnlyGreenFlowers()
        {
            var newFlowers = new List<Flower>();
            FillFlowerList<GreenFlower>(newFlowers);

            Flowers = newFlowers.ToArray();
        }

        private void FillFlowerList<T>(List<Flower> flowers)
        {
            foreach (var flower in Flowers)
            {
                if (flower is T)
                    flowers.Add(flower);
            }
        }

        public IEnumerator<Flower> GetEnumerator()
        {
            return ((IEnumerable<Flower>)Flowers).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Flowers.GetEnumerator();
        }
    }
}
