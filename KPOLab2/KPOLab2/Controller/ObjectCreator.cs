namespace KPOLab2
{
    internal static class ObjectCreator
    {
        //public static Flower CreateFlower()
        //{
        //    return new Flower();
        //}

        public static Flower CreateFlower(ColorsEnum color) 
        {
            if (color == ColorsEnum.Red)
                return new RedFlower();
            else if (color == ColorsEnum.Green)
                return new GreenFlower();
            else
                return new BlueFlower();
        }

        public static Bouquet CreateBouquet(Flower[] flowers)
        {
            return new Bouquet(flowers);
        }

        public static Bouquet CreateBouquet(Flower[] flowers, int capacity)
        {
            return new Bouquet(flowers, capacity);
        }

        public static Flower[] CreateFlowers(ColorsEnum[] colors)
        {
            var flowers = new Flower[colors.Length];
            for (int i = 0; i < colors.Length; i++)
            {
                flowers[i] = CreateFlower(colors[i]);
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
            }

            return bouquets;
        }
    }
}
