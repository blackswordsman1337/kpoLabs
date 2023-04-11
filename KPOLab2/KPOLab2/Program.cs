//Lab 2 v1.0
//Kirilyuk Artem 10701321
//28.03.2023
//Flower Shop

namespace KPOLab2
{
    public class Program
    {
        public static void Main()
        {
            var flowerShop = new FlowerShop();

            var flowers = new List<Flower>();
            flowers.Add(flowerShop.BuyFlower(ColorsEnum.Red));
            flowers.Add(flowerShop.BuyFlower(ColorsEnum.Green));
            flowers.Add(flowerShop.BuyFlower(ColorsEnum.Blue));

            var bouquet1 = flowerShop.MakeBouquet(flowers.ToArray());
            Console.WriteLine("Bouquet 1 price: {0}", bouquet1.Price);
            Console.WriteLine("Bouquet 1 weight: {0}", bouquet1.WeightGrams);
            Console.WriteLine("Bouquet 1 the cheapest flower price: {0}", bouquet1.TheCheapestFlower.Price);
            
            var bouquet2 = flowerShop.BuyBouquet(new ColorsEnum[] { ColorsEnum.Green, ColorsEnum.Blue });
            Console.WriteLine("Bouquet 2 price: {0}", bouquet2.Price);
            Console.WriteLine("Bouquet 2 weight: {0}", bouquet2.WeightGrams);
            Console.WriteLine("Bouquet 2 the most expensive flower price: {0}", bouquet2.TheMostExpensiveFlower.Price);
        }
    }
}