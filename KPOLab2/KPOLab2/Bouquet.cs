namespace KPOLab2
{
    internal class Bouquet
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
            if (flowers == null) throw new ArgumentException("Flowers array is null!");

            Flowers = flowers;

            BouquetsMade++;
        }
    }
}
