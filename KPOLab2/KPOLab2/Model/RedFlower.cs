using System.Diagnostics;
using System.Xml.Serialization;

namespace KPOLab2
{
    [Serializable]
    public class RedFlower : Flower
    {
        public RedFlower() 
        {
            Color = ColorsEnum.Green;
            Price = 5;
            WeightGrams = 40.2;
        }

        public RedFlower(double price, double weight)
        {
            Color = ColorsEnum.Red;
            Price = price;
            WeightGrams = weight;
        }
    }
}
