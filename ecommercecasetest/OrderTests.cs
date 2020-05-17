using System;
using System.Linq;
using ecommercecase;
using ecommercecase.Domain.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ecommercecasetest
{
    [TestClass]
    public class OrderTests
    {
        public OrderTests()
        {
            Context.Initialize();
        }

        [TestMethod]
        public void Create_Test()
        {
            string console = "get_product_info P1";
            string[] cmdValues = console.Split(' ');
            string cmd = cmdValues[0];

            Command myCommand = Context.Commands.SingleOrDefault(i => i.Code == cmd.ToLower());
            myCommand.Verify(cmdValues);
            string answer = myCommand.Run();


            Assert.AreNotEqual(1, Context.Orders.Count);
            Assert.AreEqual("The product you are looking for could not be found.", answer);
        }
    }
}
