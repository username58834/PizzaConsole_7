using PizzaConsole_7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class MenuTest
    {
        
        readonly PizzaClass PizzaA = new PizzaClass("PizzaA", 12.5f, 0.500);
        readonly PizzaClass PizzaA2 = new PizzaClass("PizzaA", 10f, 0.400);
        readonly PizzaClass PizzaB = new PizzaClass("PizzaB", 9.65f, 0.450);
        readonly PizzaClass PizzaC = new PizzaClass("PizzaC", 9.65f, 0.450);

        [TestCleanup]
        public void CleanUp()
        {
            Program.pizzas.Clear();
        }

        [TestMethod]
        public void MenuFindByName_Test()
        {
            //Arrange

            Program.pizzas.Add(PizzaA);
            Program.pizzas.Add(PizzaA2);
            Program.pizzas.Add(PizzaB);
            Program.pizzas.Add(PizzaC);

            //Act

            string actual = Program.Find("PizzaA");
            string expected = PizzaA.Show() + "\n" + PizzaA2.Show() + "\n";

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        [DataRow("PizzaA", true)]
        [DataRow("Pizza", false)]
        [DataRow("PizzaB", true)]
        public void MenuDeleteByName_Test(string name, bool expected)
        {
            //Arrange

            Program.pizzas.Add(PizzaA);
            Program.pizzas.Add(PizzaA2);
            Program.pizzas.Add(PizzaB);
            Program.pizzas.Add(PizzaC);

            //Act

            bool actual = Program.Delete(name);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]

        [DataRow(-5, false)]
        [DataRow(500, false)]
        [DataRow(2, true)]
        [DataRow(0, true)]
        public void MenuDeleteByIndex_Test(int index, bool expected)
        {
            //Arrange

            Program.pizzas.Add(PizzaA);
            Program.pizzas.Add(PizzaA2);
            Program.pizzas.Add(PizzaB);
            Program.pizzas.Add(PizzaC);

            //Act

            bool actual = Program.Delete(index);

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuFindByNameNoItemsFound_Test()
        {
            //Arrange

            Program.pizzas.Add(PizzaA);
            Program.pizzas.Add(PizzaA2);
            Program.pizzas.Add(PizzaB);
            Program.pizzas.Add(PizzaC);

            //Act

            string actual = Program.Find("PizzaAA");
            string expected = "No items found";

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuFindByPrice_Test()
        {
            //Arrange

            Program.pizzas.Add(PizzaA);
            Program.pizzas.Add(PizzaA2);
            Program.pizzas.Add(PizzaB);
            Program.pizzas.Add(PizzaC);

            //Act

            string actual = Program.Find(10f);
            string expected = PizzaA2.Show() + "\n" + PizzaB.Show() + "\n" + PizzaC.Show() + "\n";

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuSaveAndLoadFromCSV()
        {
            //Arrange

            Program.pizzas.Add(PizzaA);
            Program.pizzas.Add(PizzaA2);
            Program.pizzas.Add(PizzaB);
            Program.pizzas.Add(PizzaC);

            //Act

            string expected = "";
            foreach (PizzaClass pizza in Program.pizzas)
            {
                expected += pizza.ToString() + "\n";
            }

            Program.SaveToScv("MenuTest");
            Program.pizzas.Clear();
            Program.LoadFromScv("MenuTest");

            string actual = "";
            foreach (PizzaClass pizza in Program.pizzas)
            {
                actual += pizza.ToString() + "\n";
            }

            //Assert

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MenuSaveAndLoadFromJson()
        {
            //Arrange

            Program.pizzas.Add(PizzaA);
            Program.pizzas.Add(PizzaA2);
            Program.pizzas.Add(PizzaB);
            Program.pizzas.Add(PizzaC);

            //Act

            string expected = "";
            foreach (PizzaClass pizza in Program.pizzas)
            {
                expected += pizza.ToString() + "\n";
            }

            Program.SaveToJson("MenuTest");
            Program.pizzas.Clear();
            Program.LoadFromJson("MenuTest");

            string actual = "";
            foreach (PizzaClass pizza in Program.pizzas)
            {
                actual += pizza.ToString() + "\n";
            }

            //Assert

            Assert.AreEqual(expected, actual);
        }
    }
}
