using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Principal;
using KPOLab2;

namespace TestProject2
{
    [TestClass]
    public class ProgramTests
    {
        [Timeout(1000)]
        [TestMethod]
        public void Sort_OrderByWeight_SortsListByWeight()
        {
            // Arrange
            var flowers = new List<Flower>
            {
                new Flower { Color = "Red", Price = 10, WeightGrams = 20 },
                new Flower { Color = "Blue", Price = 5, WeightGrams = 30 },
                new Flower { Color = "Yellow", Price = 15, WeightGrams = 10 }
            };

            // Act
            var sortedFlowers = Program.sort(flowers, "weight");

            // Assert
            Assert.AreEqual(10, sortedFlowers[0].WeightGrams);
            Assert.AreEqual(20, sortedFlowers[1].WeightGrams);
            Assert.AreEqual(30, sortedFlowers[2].WeightGrams);
        }

        [TestMethod]
        public void Sort_OrderByPrice_SortsListByPrice()
        {
            // Arrange
            var flowers = new List<Flower>
            {
                new Flower { Color = "Red", Price = 10, WeightGrams = 20 },
                new Flower { Color = "Blue", Price = 5, WeightGrams = 30 },
                new Flower { Color = "Yellow", Price = 15, WeightGrams = 10 }
            };

            // Act
            var sortedFlowers = Program.sort(flowers, "price");

            // Assert
            Assert.AreEqual(5, sortedFlowers[0].Price);
            Assert.AreEqual(10, sortedFlowers[1].Price);
            Assert.AreEqual(15, sortedFlowers[2].Price);
        }

        [TestMethod]
        public void Sort_OrderByColor_SortsListByColor()
        {
            // Arrange
            var flowers = new List<Flower>
            {
                new Flower { Color = "Red", Price = 10, WeightGrams = 20 },
                new Flower { Color = "Blue", Price = 5, WeightGrams = 30 },
                new Flower { Color = "Yellow", Price = 15, WeightGrams = 10 }
            };

            // Act
            var sortedFlowers = Program.sort(flowers, "color");

            // Assert
            Assert.AreEqual("Blue", sortedFlowers[0].Color);
            Assert.AreEqual("Red", sortedFlowers[1].Color);
            Assert.AreEqual("Yellow", sortedFlowers[2].Color);
        }
    }
    public class Flower
    {
        public string Color { get; set; }
        public int Price { get; set; }
        public int WeightGrams { get; set; }
    }
    public class Program
    {
        public static List<Flower> sort(List<Flower> f, string s)
        {
            switch (s)
            {
                case "weight":
                    f = f.OrderBy(flower => flower.WeightGrams).ToList();
                    break;
                case "price":
                    f = f.OrderBy(flower => flower.Price).ToList();
                    break;
                case "color":
                    f = f.OrderBy(flower => flower.Color).ToList();
                    break;
                default:
                    break;
            }
            return f;
        }
    }
}
