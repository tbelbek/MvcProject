using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Data;
using Data.Entity;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class StuffUnitTestCase : BaseUnitTestCase
    {

        // [TestMethod]
        public void InsertStuffUsingRepository()
        {
            var stuffRepository = new StuffRepository();
            var count1 = stuffRepository.GetAll().Count;
            var stuff1 = StuffRepository.SaveSample();
            var count2 = stuffRepository.GetAll().Count;
            Assert.AreNotEqual(count1, count2);
        }
    }
}
