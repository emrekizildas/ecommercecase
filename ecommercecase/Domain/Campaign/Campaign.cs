using System;
using System.Collections.Generic;
using System.Linq;
using ecommercecase.Domain.Exceptions;

namespace ecommercecase.Domain.Campaign
{
    public class Campaign: ICampaign
    {
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public string Name { get; set; }
        public Product.Product Product { get; set; }
        public int Duration { get; set; }
        public int PML { get; set; }
        public int Target { get; set; }
        public CampaignStatus Status { get { return Context.Time.Hour > EndTime ? CampaignStatus.Ended : CampaignStatus.Active; } }

        public Campaign(string[] args) => Verify(args); 

        public string GetInfo()
        {
            List<Order.Order> sales = Context.Orders.Where(i => i.ActionTime < EndTime && i.ActionTime >= StartTime && i.Product.Code == Product.Code).ToList();
            int totalSales = sales.Count;
            string averagePrice = totalSales > 0 ? String.Format("{0:0.00}", sales.Average(i => i.UnitPrice)) : "-";
            int turnover = totalSales * Target;
            return $"Campaign {Name} info; Status {Status}, Target Sales {Target}, Total Sales {totalSales}, Turnover {turnover}, Average Item Price {averagePrice}";
        }

        public void Verify(string[] args)
        {
            if (Context.Campaigns.SingleOrDefault(i => i.Name.ToLower() == Name.ToLower()) != null)
                throw new CommandException(502, "Aynı isme sahip kampanya mevcut.");

            try
            {
                int startTime = Context.Time.Hour;
                StartTime = startTime;
                Name = args[1];
                Product = Context.Products.SingleOrDefault(i => i.Code.ToLower() == args[2].ToLower()) ?? throw new Exception();
                Duration = int.Parse(args[3]);
                PML = int.Parse(args[4]);
                Target = int.Parse(args[5]);
                EndTime = startTime + Duration;
            }
            catch
            {
                throw new CommandException(501, "Kampanya oluştururken bir hata meydana geldi.");
            }
        }

        public enum CampaignStatus
        {
            Active,
            Ended
        }
    }
}
