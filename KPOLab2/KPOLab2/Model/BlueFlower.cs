using System.Diagnostics;
using System.Xml.Serialization;

namespace KPOLab2
{
    [Serializable]
    public class BlueFlower : Flower
    {
        public BlueFlower() 
        {
            Color = ColorsEnum.Blue;
            Price = 4.7;
            WeightGrams = 41;
        }

        public BlueFlower(double price, double weight)
        {
            Color = ColorsEnum.Blue;
            Price = price;
            WeightGrams = weight;
        }
    }
}
