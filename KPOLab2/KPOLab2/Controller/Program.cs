using KPOLab2.Controller;
using log4net;
using log4net.Config;
using System;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

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
                BlueFlower blueFlower = new BlueFlower();
                RedFlower redFlower = new RedFlower();
                GreenFlower greenFlower = new GreenFlower();

                XmlSerializer serializer = new XmlSerializer(typeof(Flower));
                //using (FileStream fs = new FileStream("blueflower.xml", FileMode.OpenOrCreate))
                //{
                //    serializer.Serialize(fs, blueFlower);
                //    log.Info("Синий цветок был сериализован");
                //}
                //using (FileStream fs = new FileStream("redflower.xml", FileMode.OpenOrCreate))
                //{
                //    serializer.Serialize(fs, redFlower);
                //    log.Info("Красный цветок был сериализован");
                //}
                //using (FileStream fs = new FileStream("greenflower.xml", FileMode.OpenOrCreate))
                //{
                //    serializer.Serialize(fs, greenFlower);
                //    log.Info("Зеленый цветок был сериализован");
                //}

                using (FileStream fs = new FileStream("blueflower.xml", FileMode.OpenOrCreate))
                {
                    var blueflower_ds = serializer.Deserialize(fs) as BlueFlower;
                    Console.WriteLine("Price: {0}, Weight: {1}", blueflower_ds.Price, blueflower_ds.WeightGrams);
                    log.Info("Синий цветок был десериализован");
                }
                using (FileStream fs = new FileStream("redflower.xml", FileMode.OpenOrCreate))
                {
                    RedFlower? redflower_ds = serializer.Deserialize(fs) as RedFlower;
                    Console.WriteLine("Price: {0}, Weight: {1}", redflower_ds?.Price, redflower_ds?.WeightGrams);
                    log.Info("Красный цветок был десериализован");
                }
                using (FileStream fs = new FileStream("greenflower.xml", FileMode.OpenOrCreate))
                {
                    GreenFlower? greenflower_ds = serializer.Deserialize(fs) as GreenFlower;
                    Console.WriteLine("Price: {0}, Weight: {1}", greenflower_ds?.Price, greenflower_ds?.WeightGrams);
                    log.Info("Зеленый цветок был десериализован");
                }
            }
            catch(Exception ex) { log.Error("Произошла ошибка", ex); }

            IPrinter log4jPrinter = ObjectCreator.PrintersMap[typeof(Log4jPrinter)];
            log4jPrinter.Print("This message will be logged using log4j.");

            //var logSerializer = new XmlSerializer(typeof(Log4jPrinter));
            //FileStream fileStream = new FileStream("log4jprinter.xml", FileMode.OpenOrCreate);
            //logSerializer.Serialize(fileStream, log4jPrinter);

            log.Info("Программа завершена");

        }
    }
}