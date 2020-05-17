using System;
using System.Linq;
using ecommercecase;
using ecommercecase.Domain.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ecommercecasetest
{
    [TestClass]
    public class TimeTests
    {
        public TimeTests()
        {
            Context.Initialize();
        }

        [TestMethod]
        public void Increase_Time()
        {
            string console = "increase_time 2";
            string[] cmdValues = console.Split(' ');
            string cmd = cmdValues[0];

            Command myCommand = Context.Commands.SingleOrDefault(i => i.Code == cmd.ToLower());
            myCommand.Verify(cmdValues);
            myCommand.Run();


            Assert.AreEqual(2, Context.Time.Hour);
        }
    }
}
