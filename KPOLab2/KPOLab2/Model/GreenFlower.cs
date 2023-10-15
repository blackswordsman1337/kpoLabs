using System.Xml.Serialization;

namespace KPOLab2
{
    [Serializable]
    public class GreenFlower : Flower
    {
        public GreenFlower() 
        {
            Color = ColorsEnum.Green;
            Price = 5.5;
            WeightGrams = 37.8;
        }

        public GreenFlower(double price, double weight)
        {
            Color = ColorsEnum.Green;
            Price = price;
            WeightGrams = weight;
        }
    }
}
