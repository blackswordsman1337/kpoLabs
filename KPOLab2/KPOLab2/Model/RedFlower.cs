namespace KPOLab2
{
    [Serializable]
    internal class RedFlower : Flower
    {
        public RedFlower(double price = 5, double weight = 40.2)
        {
            Color = ColorsEnum.Red;
            Price = price;
            WeightGrams = weight;
        }
    }
}
