//Lab 2 v1.0
//Kirilyuk Artem 10701321
//28.03.2023
//Flower Shop

namespace KPOLab2
{
    public class Program
    {

            internal static void sort(List<Flower> f) {
                foreach (var flower in f)
                {
                    Console.WriteLine("{0} flower: price {1}, weight {2}", flower.Color, flower.Price, flower.WeightGrams);
                }
            }
            internal static void SearchFlower(List<Flower> flowers, ColorsEnum color)
            {
                bool found = false;
                foreach (var flower in flowers)
                {
                    if (flower.Color == color)
                    {
                        Console.WriteLine("Цветок найден: {0}, стоимость: {1}, вес: {2}", flower.Color, flower.Price, flower.WeightGrams);
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Нет совпадений");
                }
            }

            internal static void SearchFlower(List<Flower> flowers, double weight)
            {
                bool found = false;
                foreach (var flower in flowers)
                {
                    if (flower.WeightGrams == weight)
                    {
                        Console.WriteLine("Цветок найден: {0}, стоимость: {1}, вес: {2}", flower.Color, flower.Price, flower.WeightGrams);
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Нет совпадений");
                }
            }

            internal static void SearchFlower(List<Flower> flowers, double price,string s)
            {
                bool found = false;
                foreach (var flower in flowers)
                {
                    if (flower.Price == price)
                    {
                        Console.WriteLine("Цветок найден: {0}, стоимость: {1}, вес: {2}", flower.Color, flower.Price, flower.WeightGrams);
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Нет совпадений");
                }
            }

            public static void Main()
            {
                var flowerShop = new FlowerShop();

                var flowers = new List<Flower>();
                flowers.Add(flowerShop.BuyFlower(ColorsEnum.Red));
                flowers.Add(flowerShop.BuyFlower(ColorsEnum.Green));
                flowers.Add(flowerShop.BuyFlower(ColorsEnum.Blue));

                var sortedFlowersByWeight = flowers.OrderBy(flower => flower.WeightGrams).ToList();
                var sortedFlowersByPrice = flowers.OrderBy(flower => flower.Price).ToList();
                var sortedFlowersByColor = flowers.OrderBy(flower => flower.Color).ToList();

                Console.WriteLine("Sorted by color:");
                sort(sortedFlowersByColor);


                Console.WriteLine("\nSorted by price:");
                sort(sortedFlowersByPrice);

                // Сортировка по весу

                Console.WriteLine("\nSorted by weight:");
                sort(sortedFlowersByWeight);

                var bouquet1 = flowerShop.MakeBouquet(flowers.ToArray());
                Console.WriteLine("Bouquet 1 price: {0}", bouquet1.Price);
                Console.WriteLine("Bouquet 1 weight: {0}", bouquet1.WeightGrams);
                Console.WriteLine("Bouquet 1 the cheapest flower price: {0}", bouquet1.TheCheapestFlower.Price);
            
                var bouquet2 = flowerShop.BuyBouquet(new ColorsEnum[] { ColorsEnum.Green, ColorsEnum.Blue });
                Console.WriteLine("Bouquet 2 price: {0}", bouquet2.Price);
                Console.WriteLine("Bouquet 2 weight: {0}", bouquet2.WeightGrams);
                Console.WriteLine("Bouquet 2 the most expensive flower price: {0}", bouquet2.TheMostExpensiveFlower.Price);


                Console.WriteLine("Flower create: {0}",ObjectCreator.flowerCount);
                Console.WriteLine("Bouquet create: {0}", ObjectCreator.bouqetCount);



                Console.Write("Введите цвет цветка (Red, Green или Blue): ");
                string colorString = Console.ReadLine();

                // Преобразовать строку в enum
                ColorsEnum color;
                if (!Enum.TryParse(colorString, out color))
                {
                    Console.WriteLine("Ошибка: неправильный формат цвета");
                    return;
                }
                SearchFlower(flowers, color);
             

                Console.Write("Введите вес цветка: ");
                double weight = double.Parse(Console.ReadLine());
                SearchFlower(flowers, weight);

                Console.Write("Введите цену цветка: ");
                double price = double.Parse(Console.ReadLine());
                SearchFlower(flowers, price,"price");
        }
    }
}