using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using UINS;

namespace UITestNS
{
    [TestClass]
    public class UITests
    {
        static UserInterface ui;
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            ui = new UserInterface();
        }
        [TestMethod]
        [DataRow("1+1", "2")]
        [DataRow("1-1", "0")]
        public void CorrectInput(string input, string expRes)
        {
            StringReader stringReader = new StringReader(input + "\nexit");
            Console.SetIn(stringReader);
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            ui.RunProgramm();

            Assert.AreEqual(stringWriter.ToString().Contains(expRes), true);
        }


        [TestMethod]
        public void IncorrectInput()
        {
            StringReader stringReader = new StringReader("1/0\nexit");
            Console.SetIn(stringReader);
            StringWriter stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            ui.RunProgramm();

            Assert.AreEqual(stringWriter.ToString().Contains("ошибка при вводе данных:"), true);
        }
    }
}
