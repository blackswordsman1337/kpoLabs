//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Principal;
//using KPOLab2;

//namespace TestProject1
//{
//    [TestClass]
//    public class ProgramTests
//    {
//        [TestMethod]
//        public void SearchFlower_WhenMatchingColorExists_ShouldReturnMatchingFlower()
//        {
//            // Arrange
//            var flowers = new List<Flower>
//            {
//                new Flower { Color = "Red", Price = 10, WeightGrams = 20 },
//                new Flower { Color = "Blue", Price = 5, WeightGrams = 30 },
//                new Flower { Color = "Yellow", Price = 15, WeightGrams = 10 }
//            };

//            // Act
//            var consoleOutput = CaptureConsoleOutput(() =>
//            {
//                FlowerShop.SearchFlower(flowers, ColorsEnum.Red);
//            });

//            // Assert
//            Assert.IsTrue(consoleOutput.Contains("Цветок найден: Red, стоимость: 10, вес: 20"));
//        }

//        [TestMethod]
//        public void SearchFlower_WhenNoMatchingColorExists_ShouldReturnNoMatches()
//        {
//            // Arrange
//            var flowers = new List<Flower>
//            {
//                new Flower { Color = "Red", Price = 10, WeightGrams = 20 },
//                new Flower { Color = "Blue", Price = 5, WeightGrams = 30 },
//                new Flower { Color = "Yellow", Price = 15, WeightGrams = 10 }
//            };

//            // Act
//            var consoleOutput = CaptureConsoleOutput(() =>
//            {
//                FlowerShop.SearchFlower(flowers, ColorsEnum.Green);
//            });

//            // Assert
//            Assert.IsTrue(consoleOutput.Contains("Нет совпадений"));
//        }

//        // Вспомогательный метод для перехвата вывода на консоль
//        private string CaptureConsoleOutput(Action action)
//        {
//            var consoleOut = new System.IO.StringWriter();
//            Console.SetOut(consoleOut);

//            action();

//            return consoleOut.ToString().Trim();
//        }
//    }

//    public class Flower
//    {
//        public string Color { get; set; }
//        public int Price { get; set; }
//        public int WeightGrams { get; set; }
//    }

//    public static class FlowerShop
//    {
//        public static bool SearchFlower(List<Flower> flowers, ColorsEnum color)
//        {
//            bool found = false;
//            foreach (var flower in flowers)
//            {
//                if (flower.Color == color.ToString())
//                {
//                    Console.WriteLine("Цветок найден: {0}, стоимость: {1}, вес: {2}", flower.Color, flower.Price, flower.WeightGrams);
//                    found = true;
//                }
//            }
//            if (!found)
//            {
//                Console.WriteLine("Нет совпадений");
//            }
//            return found;
//        }
//    }
//    public enum ColorsEnum
//    {
//        Red,
//        Blue,
//        Yellow,
//        Green
//    }
//}
