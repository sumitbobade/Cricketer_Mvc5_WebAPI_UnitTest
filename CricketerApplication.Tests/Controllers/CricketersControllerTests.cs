using Microsoft.VisualStudio.TestTools.UnitTesting;
using CricketerApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace CricketerApplication.Controllers.Tests
{
    [TestClass()]
    public class CricketersControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            // Arrange
            CricketersController controller = new CricketersController();

            // Act
            ViewResult result = controller.Index("","") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            // Arrange
            CricketersController controller = new CricketersController();

            // Act
            ViewResult result = controller.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
           // Assert.AreEqual("Details",result.ViewName);
           // Assert.AreEqual("SUMIT", result.ViewData["Name"]);

            
           // Assert.AreEqual("",result.)
        }
    }
}