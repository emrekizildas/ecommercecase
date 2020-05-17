using System;
using System.Linq;
using ecommercecase.Common;
using ecommercecase.Common.Models;
using ecommercecase.Domain.Exceptions;

namespace ecommercecase.Domain.Command
{
    public class Command: ICommand
    {

        public string Code { get; set; }
        public int ArgCount { get; set; }
        public string[] Arguments { get; set; }

        public Command(string commandCode, int argumentsNumber)
        {
            this.Code = commandCode;
            this.ArgCount = argumentsNumber;
        }

        public void Verify(string[] args)
        {
            Arguments = args;
            bool checkEmpty = Arguments.Contains(string.Empty);
            if (checkEmpty)
                throw new CommandException(301, "You cannot submit an empty argument.");

            int argumentNumber = Arguments.Length - 1;
            if (ArgCount != argumentNumber)
                throw new CommandException(302, $"You did not enter a valid argument for the {Code} command.\n{GetUsingInfo()}");
        }

        public string GetUsingInfo()
        {
            switch (Code.ToLower())
            {
                case Constants.CreateProduct:
                    return Constants.Using_CreateProduct;
                case Constants.CreateCampaign:
                    return Constants.Using_CreateCampaign;
                case Constants.CreateOrder:
                    return Constants.Using_CreateOrder;
                case Constants.CampaignInfo:
                    return Constants.Using_CampaignInfo;
                case Constants.ProductInfo:
                    return Constants.Using_ProductInfo;
                case Constants.IncreaseTime:
                    return Constants.Using_IncreaseTime;
                default:
                    return string.Empty;
            }
        }

        public string Run()
        {
            switch (Code.ToLower())
            {
                case Constants.CreateProduct:
                    var product = new Product.Product(Arguments);
                    Context.Products.Add(product);
                    return $"Product created; code {product.Code}, price {product.Price}, stock {product.Stock}";
                case Constants.CreateCampaign:
                    var campaign = new Campaign.Campaign(Arguments);
                    Context.Campaigns.Add(campaign);
                    return $"Campaign created; name {campaign.Name}, product {campaign.Product.Code}, duration {campaign.Duration}, limit {campaign.PML}, target sales count {campaign.Target}";
                case Constants.CreateOrder:
                    var order = new Order.Order(Arguments);
                    Context.Orders.Add(order);
                    return $"Order created; product {order.Product.Code}, quantity {order.Quantity}";
                case Constants.CampaignInfo:
                    var infoCampaign = Context.Campaigns.FirstOrDefault(i => i.Name.ToLower() == Arguments[1].ToLower());
                    return infoCampaign?.GetInfo() ?? "The campaign you were looking for could not be found.";
                case Constants.ProductInfo:
                    var infoProduct = Context.Products.FirstOrDefault(i => i.Code.ToLower() == Arguments[1].ToLower());
                    return infoProduct?.GetInfo() ?? "The product you are looking for could not be found.";
                case Constants.IncreaseTime:
                    Context.Time.Increase(Arguments);
                    return $"Time is {Context.Time.DateTime.ToShortTimeString()}";
                default:
                    return "Command not detected.";
            }
        }
    }
}
