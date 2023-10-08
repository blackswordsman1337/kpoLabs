using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KPOLab2
{
    public interface IProductFactory
    {
        Flower CreateProduct();
    }

    public class RedFlowerFactory : IProductFactory
    {
        public Flower CreateProduct()
        {
            return new RedFlower();
        }
    }

    public class GreenFlowerFactory : IProductFactory
    {
        public Flower CreateProduct()
        {
            return new GreenFlower();
        }
    }

    public class BlueFlowerFactory : IProductFactory
    {
        public Flower CreateProduct()
        {
            return new BlueFlower();
        }
    }

    public class TextFileFlowerFactory : IProductFactory
    {
        public Flower CreateProduct()
        {
            string[] lines = File.ReadAllLines("flowers.txt");

            string[] parts = lines[0].Split(';');
            string color = parts[0];
            double price = double.Parse(parts[1]);
            double weight = double.Parse(parts[2]);

            if (color == "Red")
            {
                var flower = new RedFlower(price, weight);
                Log.Out(string.Format("Created {0}", flower));
                return flower;
            }
            else if (color == "Blue")
            {
                var flower = new BlueFlower(price, weight);
                Log.Out(string.Format("Created {0}", flower));
                return flower;
            }
            else if (color == "Green")
            {
                var flower = new GreenFlower(price, weight);
                Log.Out(string.Format("Created {0}", flower));
                return flower;
            }
            return null;
        }
    }

    public class BinaryFileFlowerFactory : IProductFactory
    {
        public Flower CreateProduct()
        {
            FileStream stream = new FileStream("flowers.bin", FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();
            Flower flower = (Flower)formatter.Deserialize(stream);
            Log.Out(string.Format("Created {0}", flower));
            return flower;
        }
    }
    public class RandomFlowerFactory : IProductFactory
    {
        public Flower CreateProduct()
        {
            Random rnd = new Random();
            string[] colors = { "Red", "Blue", "Green" };
            double price = Math.Round(rnd.NextDouble() * 10, 3);
            double weight = Math.Round(rnd.NextDouble() * 50, 3);

            int colorIndex = rnd.Next(0, 3);
            string color = colors[colorIndex];

            if (color == "Red")
            {
                var flower = new RedFlower(price, weight);
                Log.Out(string.Format("Created {0}", flower));
                
                return flower;
            }
            else if (color == "Blue")
            {
                var flower = new BlueFlower(price, weight);
                Log.Out(string.Format("Created {0}", flower));
                return flower;
            }
            else if (color == "Green")
            {
                var flower = new GreenFlower(price, weight);
                Log.Out(string.Format("Created {0}", flower));
                return flower;
            }
            return null;
        }
    }
    public class FlowerFactoryTester
    {
        public static void TestFactories()
        {
            IProductFactory factory1 = new RedFlowerFactory();
            IProductFactory factory2 = new TextFileFlowerFactory();
            IProductFactory factory3 = new RandomFlowerFactory();
        }
    }
}
