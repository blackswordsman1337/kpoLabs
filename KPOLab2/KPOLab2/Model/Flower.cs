using System.Xml.Serialization;

namespace KPOLab2
{
    public enum ColorsEnum
    {
        Red,
        Green,
        Blue
    }

    [XmlInclude(typeof(BlueFlower))]
    [XmlInclude(typeof(RedFlower))]
    [XmlInclude(typeof(GreenFlower))]
    [Serializable]
    public abstract class Flower
    {
        public static int FlowersBought { get; set; } //number of flowers bought

        public ColorsEnum Color { get;  set; }

        public double Price { get;  set; }
        public double WeightGrams { get;  set; }

        public override string ToString()
        {
            return string.Format("Color: {0}, Price: {1}, Weight: {2}", Color, Price, WeightGrams);
        }
    }
}
