using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPOLab2.Controller
{
    internal class FlowerComparator : IComparer<Flower>
    {
        public int Compare(Flower x, Flower y)
        {
            return x.WeightGrams.CompareTo(y.WeightGrams);
        }
    }
}
