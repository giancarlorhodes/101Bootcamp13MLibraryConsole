using ConsoleLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLibrary
{
    [TestClass]
    public class UnitTestPrinter
    {
        [TestMethod]
        public void Printer_End_Should_Print_One_Line()
        {
            // arrange
            var _expected = "Library App Console Ending. Press Enter ....";

            // act
            var _actual = Printer.End();

            // assert
            Assert.IsNotNull(_expected);
            Assert.AreEqual(_expected, _actual);
        }
    }
}
