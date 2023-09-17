using Comparison;

namespace KPOLab2.Controller
{
    internal class FlowerWeightComparator : IMyComparer<Flower>
    {
        public int MyCompare(Flower x, Flower y)
        {
            return x.WeightGrams.CompareTo(y.WeightGrams);
        }
    }
    internal class FlowerColorComparator : IMyComparer<Flower>
    {
        public int MyCompare(Flower x, Flower y)
        {
            return x.Color.CompareTo(y.Color);
        }
    }
    internal class FlowerPriceComparator : IMyComparer<Flower>
    {
        public int MyCompare(Flower x, Flower y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
