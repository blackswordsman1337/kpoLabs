namespace KPOLab2
{
    public enum ColorsEnum
    {
        Red,
        Green,
        Blue
    }

    internal abstract class Flower : IComparable<Flower>
    {
        public static int FlowersBought { get; protected set; } //number of flowers bought

        public ColorsEnum Color { get; protected set; }

        public double Price { get; protected set; }
        public double WeightGrams { get; protected set; }
        public int CompareTo(Flower other)
        {
            if (this.Color < other.Color) return -1;
            else if (this.Color > other.Color) return 1;
            else return 0;
        }
    }
}
