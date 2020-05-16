using System;
using System.Collections.Generic;
using ecommercecase.Domain.Campaign;
using ecommercecase.Domain.Command;
using ecommercecase.Domain.Order;
using ecommercecase.Domain.Product;
using ecommercecase.Domain.Time;

namespace ecommercecase
{
    public class Context
    {
        private static Context _context;

        public static Time Time { get; private set; }
        public static List<Command> Commands { get; private set; }
        public static List<Product> Products { get; private set; }
        public static List<Campaign> Campaigns { get; private set; }
        public static List<Order> Orders { get; private set; }

        private Context() { }

        public static Context Initialize()
        {
            if (_context == null)
            {
                Time = new Time();
                Commands = CreateCommands();
                Products = new List<Product>();
                Campaigns = new List<Campaign>();
                Orders = new List<Order>();
                _context = new Context();
            }

            return _context;
        }

        static List<Command> CreateCommands()
        {
            List<Command> commands = new List<Command>();
            Dictionary<string, int> commandList = new Dictionary<string, int>
            {
                { Common.Constants.CreateProduct, 3 },
                { Common.Constants.ProductInfo, 1 },
                { Common.Constants.CreateOrder, 2 },
                { Common.Constants.CreateCampaign, 5 },
                { Common.Constants.CampaignInfo, 1 },
                { Common.Constants.IncreaseTime, 1 }
            };

            foreach (KeyValuePair<string, int> cmd in commandList)
                commands.Add(new Command(cmd.Key, cmd.Value));

            return commands;
        }
    }
}
