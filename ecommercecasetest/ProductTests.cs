using System.Linq;
using ecommercecase;
using ecommercecase.Domain.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ecommercecasetest
{
    [TestClass]
    public class ProductTests
    {
        public ProductTests()
        {
            Context.Initialize();
        }

        [TestMethod]
        public void Create_Test()
        {

            string console = "create_product P1 100 1000";
            string[] cmdValues = console.Split(' ');
            string cmd = cmdValues[0];

            Command myCommand = Context.Commands.SingleOrDefault(i => i.Code == cmd.ToLower());
            myCommand.Verify(cmdValues);
            myCommand.Run();


            Assert.AreEqual(1, Context.Products.Count);
            Assert.AreEqual("P1", Context.Products.SingleOrDefault(i => i.Code.ToLower() == cmdValues[1].ToLower()).Code);
            Assert.AreEqual(100, Context.Products.SingleOrDefault(i => i.Code.ToLower() == cmdValues[1].ToLower()).Price);
            Assert.AreEqual(1000, Context.Products.SingleOrDefault(i => i.Code.ToLower() == cmdValues[1].ToLower()).Stock);
        }
    }
}
