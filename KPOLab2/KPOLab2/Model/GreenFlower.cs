namespace KPOLab2
{
    [Serializable]
    internal class GreenFlower : Flower
    {
        public GreenFlower(double price = 5.5, double weight = 37.8)
        {
            Color = ColorsEnum.Green;
            Price = price;
            WeightGrams = weight;
        }
    }
}
