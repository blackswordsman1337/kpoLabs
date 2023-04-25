namespace KPOLab2
{
    internal static class ObjectCreator
    {
        //public static Flower CreateFlower()
        //{
        //    return new Flower();
        //}
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

        public static Bouquet CreateBouquet(Flower[] flowers)
        {
            bouqetCount++;
            return new Bouquet(flowers);
        }

        public static Bouquet CreateBouquet(Flower[] flowers, int capacity)
        {
            bouqetCount++;
            return new Bouquet(flowers, capacity);
        }

        public static Flower[] CreateFlowers(ColorsEnum[] colors)
        {
            var flowers = new Flower[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                flowers[i] = CreateFlower(colors[i]);
                flowerCount++;
            }

            return flowers;
        }

        public static Bouquet[] CreateBouquets(int count)
        {
            var bouquets = new Bouquet[count];
            for (int i = 0; i < count; i++)
            {
                bouquets[i] = CreateBouquet(CreateFlowers(
                    new ColorsEnum[] {ColorsEnum.Red, ColorsEnum.Green, ColorsEnum.Blue}));
                bouqetCount++;
            }

            return bouquets;
        }
    }
}
