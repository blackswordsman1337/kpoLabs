namespace KPOLab2
{
    [Serializable]
    internal class BlueFlower : Flower
    {
        public BlueFlower(double price = 4.7, double weight = 41)
        {
            Color = ColorsEnum.Blue;
            Price = price;
            WeightGrams = weight;
        }
    }
}
