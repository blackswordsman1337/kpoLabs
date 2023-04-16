namespace KPOLab2
{
    public enum ColorsEnum
    {
        Red,
        Green, 
        Blue
    }

    internal abstract class Flower
    {
        //public static readonly double DefaultPrice;
        //public static readonly double DefaultWeightGrams;

        public static int FlowersBought { get; protected set; } //number of flowers bought

        public ColorsEnum Color { get; protected set; }

        public double Price { get; protected set; }
        public double WeightGrams { get; protected set; }

        //static Flower()
        //{
        //    DefaultPrice = 5.1;
        //    DefaultWeightGrams = 39.7;
        //}

        //public Flower()
        //{
        //    Color = ColorsEnum.Red;
        //    Price = DefaultPrice;
        //    WeightGrams = DefaultWeightGrams;
        //}

        //public Flower(ColorsEnum color)
        //{
        //    Color = color;

        //    if (color == ColorsEnum.Red)
        //    {
        //        Price = 5;
        //        WeightGrams = 40.2;
        //    }
        //    else if (color == ColorsEnum.Green)
        //    {
        //        Price = 5.5;
        //        WeightGrams = 37.8;
        //    }
        //    else
        //    {
        //        Price = 4.7;
        //        WeightGrams = 41;
        //    }

        //    FlowersBought++;
        //}
    }
}
