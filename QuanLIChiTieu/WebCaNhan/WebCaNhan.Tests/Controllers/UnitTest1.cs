using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebCaNhan.Controllers;
using System.Linq;

namespace WebCaNhan.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new Expenditure99Entities();
            var controller = new ManagementController();
            var result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result.Model, typeof(List<QuanLyChiTieuCaNhan>));
            Assert.AreEqual(db.QuanLyChiTieuCaNhans.Count(), (result.Model as List<QuanLyChiTieuCaNhan>).Count);
        }
    }
}
