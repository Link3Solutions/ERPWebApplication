using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ERPWebApplication.AppClass.DataAccess;

namespace ERPWebApplicationUnitTest
{
    [TestClass]
    public class CalculatorControllerUnitTest
    {
        CalculatorController _objCalculatorController;
        [TestMethod]
        public void TestAdd()
        {
            _objCalculatorController = new CalculatorController();
            Assert.AreEqual(32, _objCalculatorController.Add(15, 17));
        }
    }
}
