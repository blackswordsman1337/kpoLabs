using KPOLab2.Controller;
using log4net;
using log4net.Config;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]


namespace KPOLab2
{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        
        private static List<Flower> GetFlowerInstances()
        {
            var flowers = new List<Flower>();

            var dynamicLibrariesDirectory = Directory.GetCurrentDirectory() + "\\DynamicLibraries";
            var files = Directory.GetFiles(dynamicLibrariesDirectory);

            foreach (string file in files)
            {
                if (!file.Contains(".dll"))
                    continue;

                var loadedAssembly = Assembly.LoadFile(file);
                var assemblyTypes = loadedAssembly.GetTypes();

                for (int i = 0; i < assemblyTypes.Length; i++)
                {
                    if (assemblyTypes[i] != null)
                        flowers.Add((Flower)Activator.CreateInstance(assemblyTypes[i]));
                }
            }

            return flowers;
        }

        internal static void Print(List<Flower> f)
        {
            foreach (var flower in f)
            {
                Console.WriteLine("{0} flower: price {1}, weight {2}", flower.Color, flower.Price, flower.WeightGrams);
                log.Debug(new { FlowerColor = flower.Color, FlowerPrice = flower.Price, FlowerWeight = flower.WeightGrams });
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

        internal static void SearchFlower(List<Flower> flowers, double price, string s)
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
            log4net.Config.XmlConfigurator.Configure();
            if (log.IsDebugEnabled)
                log.Debug("Test debug message");
            log.Info("Программа запущена");
            try
            {
                var flowerShop = new FlowerShop();

                var flowers = new List<Flower>()
            {
                flowerShop.BuyFlower(ColorsEnum.Red),
                flowerShop.BuyFlower(ColorsEnum.Green),
                flowerShop.BuyFlower(ColorsEnum.Blue)
            };

                var sortedFlowersByWeight = flowers.OrderBy(flower => flower.WeightGrams).ToList();
                var sortedFlowersByPrice = flowers.OrderBy(flower => flower.Price).ToList();
                var sortedFlowersByColor = flowers.OrderBy(flower => flower.Color).ToList();

                Console.WriteLine("Sorted by color:");
                Print(sortedFlowersByColor);
                
                Console.WriteLine("\nSorted by price:");
                Print(sortedFlowersByPrice);

                // Сортировка по весу

                Console.WriteLine("\nSorted by weight:");
                Print(sortedFlowersByWeight);

                var bouquet1 = flowerShop.MakeBouquet(flowers);
                Console.WriteLine("Bouquet 1 price: {0}\n" +
                    "Bouquet 1 weight: {1}\n" +
                    "Bouquet 1 the cheapest flower price: {2}", bouquet1.Price, bouquet1.WeightGrams,
                    bouquet1.TheCheapestFlower.Price);
                log.Debug(new { Bouqet1 = bouquet1 });

                var bouquet2 = flowerShop.BuyBouquet(new List<ColorsEnum> { ColorsEnum.Green, ColorsEnum.Blue });
                Console.WriteLine("Bouquet 2 price: {0}\n" +
                    "Bouquet 2 weight: {1}\n" +
                    "Bouquet 2 the cheapest flower price: {2}", bouquet2.Price, bouquet2.WeightGrams,
                    bouquet2.TheCheapestFlower.Price);
                log.Debug(new { Bouqet2 = bouquet2 });

                Console.WriteLine("Flower create: {0}", ObjectCreator.flowerCount);
                Console.WriteLine("Bouquet create: {0}", ObjectCreator.bouqetCount);
                log.Debug(new { ObjectCreatorFlorwer = ObjectCreator.flowerCount });
                log.Debug(new { ObjectCreatorBouqet = ObjectCreator.bouqetCount });
                #region CommentedSection 
                //var bouquets =  new List<Bouquet>() { bouquet1, bouquet2 };
                //Console.Write("Введите цвет цветка (Red, Green или Blue): ");
                //string colorString = Console.ReadLine();

                //// Преобразовать строку в enum
                //ColorsEnum color;
                //if (!Enum.TryParse(colorString, out color))
                //{
                //    Console.WriteLine("Ошибка: неправильный формат цвета");
                //    return;
                //}
                //SearchFlower(flowers, color);

                //Console.Write("Введите вес цветка: ");
                //double weight = double.Parse(Console.ReadLine());
                //SearchFlower(flowers, weight);

                //Console.Write("Введите цену цветка: ");
                //double price = double.Parse(Console.ReadLine());
                //SearchFlower(flowers, price, "price");



                // Словарь сортировщиков
                //var sorters = new Dictionary<string, object>();


                //sorters["FlowerColor"] = new FlowerColorComparator();
                //sorters["Bouquet"] = Bouquet.CompareByPrice;
                //Bouquet.currentComparison = (Bouquet.BouquetComparison)sorters["Bouquet"];// Bouquet.CompareByPrice;




                //flowers.Sort((IComparer<Flower>?)sorters["FlowerColor"]);

                //Console.WriteLine("Цветы отсортированы по цвету:");
                //foreach (Flower f in flowers)
                //    Console.WriteLine(f.Color);

                //// Сортировка букетов

                //bouquets.Sort();

                //Console.WriteLine("Букеты отсортированы по цене:");
                //foreach (Bouquet b in bouquets)
                //    Console.WriteLine(b.Price);
                #endregion

                Console.WriteLine("-----------------");

                var bouquet = new Bouquet(new List<Flower> { new GreenFlower(), new BlueFlower(), new RedFlower() });

                foreach (var flower in bouquet.GetFlowers(2))
                {
                    Console.WriteLine(flower.Color);
                }

                Console.WriteLine("-----------------");

                var flowerInstances = GetFlowerInstances();
                for (int i = 0; i < flowerInstances.Count; i++)
                {
                    var flower = flowerInstances[i];

                    Console.WriteLine("Flower {0}\n" +
                        "Color: {1}\n" +
                        "Price: {2}\n" +
                        "Weight: {3}\n", i + 1, flower.Color, flower.Price, flower.WeightGrams);
                    log.Debug(new { FlowerColor = flower.Color, FlowerPrice=flower.Price, FlowerWeight=flower.WeightGrams });
                }

                var textFactory = new TextFileFlowerFactory();
                var textFlower = textFactory.CreateProduct();
                log.Debug(new { TextFactory = textFlower });

                var binFactory = new BinaryFileFlowerFactory();
                var binFlower = binFactory.CreateProduct();
                log.Debug(new { BinFactory = binFlower });

                var randomFactory = new RandomFlowerFactory();
                var randomFlower = randomFactory.CreateProduct();
                log.Debug(new { RandomFactory = randomFlower });
            }
            catch(Exception ex) { log.Error("Произошла ошибка", ex); }

            IPrinter log4jPrinter = new Log4jPrinter();
            log4jPrinter.Print("This message will be logged using log4j.");

            log.Info("Программа завершена");

        }
    }
}