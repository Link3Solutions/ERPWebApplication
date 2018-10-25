using ERPWebApplication.AppClass.DataAccess;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPWebApplicationTest
{
    [TestFixture]
    public class CompanySetupControllerTest
    {
        CalculatorController _objCalculatorController;
        [TestCase]
        public void AddMethodTest()
        {
            _objCalculatorController = new CalculatorController();
            Assert.AreEqual(37, _objCalculatorController.Add(19, 17));
        }


    }
}
