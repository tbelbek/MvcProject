using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    /// <summary>
    /// Unit test ornegi olarak yazilmistir.
    /// </summary>
    [TestClass]
    public class TrivialUnitTestCase : BaseUnitTestCase
    {
        [TestMethod]
        public void TestTwoPlusTwo()
        {
            int expected = 4;
            int actual = 2 + 2;
            Assert.AreEqual(expected, actual);
        }
    }
}
