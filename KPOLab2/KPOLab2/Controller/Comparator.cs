using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOLab2.Controller
{
    internal class FlowerWeightComparator : IComparer<Flower>
    {
        public int Compare(Flower x, Flower y)
        {
            return x.WeightGrams.CompareTo(y.WeightGrams);
        }
    }
    internal class FlowerColorComparator : IComparer<Flower>
    {
        public int Compare(Flower x, Flower y)
        {
            return x.Color.CompareTo(y.Color);
        }
    }
    internal class FlowerPriceComparator : IComparer<Flower>
    {
        public int Compare(Flower x, Flower y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
