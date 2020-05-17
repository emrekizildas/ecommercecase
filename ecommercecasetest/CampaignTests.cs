using System;
using System.Linq;
using ecommercecase;
using ecommercecase.Domain.Command;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ecommercecasetest
{
    [TestClass]
    public class CampaignTests
    {
        public CampaignTests()
        {
            Context.Initialize();
        }

        [TestMethod]
        public void Create_Campaign()
        {
            string console = "create_campaign C1 P1 5 20 100";
            string[] cmdValues = console.Split(' ');
            string cmd = cmdValues[0];

            Command myCommand = Context.Commands.SingleOrDefault(i => i.Code == cmd.ToLower());
            myCommand.Verify(cmdValues);
            myCommand.Run();


            Assert.AreNotEqual(1, Context.Campaigns.Count);
        }
    }
}
