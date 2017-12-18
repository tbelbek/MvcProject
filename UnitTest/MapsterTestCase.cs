using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data.Entity;
using Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class MapsterTestCase : BaseUnitTestCase
    {
        [TestMethod]
        public void MapSample()
        {
            // bir customer nesnesinin degerlerini, customerViewModel'e kopyala
            // CustomerViewModel customerViewModel = TypeAdapter.Adapt<CustomerViewModel>(customer);

            // degisiklikleri yansitalim
            // Customer customer = customerViewModel.Adapt<Customer>();
        }
    }
}
