using Microsoft.VisualStudio.TestTools.UnitTesting;
using Progress.Controllers;
using Progress.Domain.Data;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ProgressTest
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexViewResultNotNull()
        {
            //Arrange
            HomeController home = new HomeController();
            //Act
            ViewResult viewResult = home.Index() as ViewResult;
            //Assert
            Assert.IsNotNull(viewResult);
        }
        [TestMethod]
        public void Index_shoud_resturn_ViewWithData()
        {
            var postMethod = typeof(HomeController).GetMethods().FirstOrDefault(p => p.GetCustomAttribute<HttpPostAttribute>(false) != null && p.Name == "Index");
            Assert.IsTrue(postMethod != null);

        }
    }
}
