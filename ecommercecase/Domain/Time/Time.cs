using System;
using System.Linq;
using ecommercecase.Domain.Exceptions;

namespace ecommercecase.Domain.Time
{
    public class Time: ITime
    {
        public int Hour { get; set; }
        public DateTime DateTime { get { return DateTime.Now.Date.AddHours(Hour); } }


        public void Increase(string[] args)
        {
            try
            {
                int appendHour = int.Parse(args[1]);
                Hour += appendHour;
                var activeCampaigns = Context.Campaigns.Where(i => i.Status == Campaign.Campaign.CampaignStatus.Active).ToList();
                foreach (Campaign.Campaign campaign in activeCampaigns)
                {
                    int lowerPrice = campaign.Product.MainPrice * (100 - campaign.PML) / 100;
                    if(lowerPrice < campaign.Product.Price)
                    {
                        campaign.Product.Price -= campaign.Product.Price - 5 > lowerPrice ? 5 : (campaign.Product.Price - lowerPrice); 
                    }
                }

                var deactivedCampaings = Context.Campaigns.Where(i => i.Status == Campaign.Campaign.CampaignStatus.Ended).ToList();
                deactivedCampaings.ForEach(i => i.Product.Price = i.Product.MainPrice);
            }
            catch
            {
                throw new CommandException(701, "Süre artırılamadı.");
            }
        }


    }
}
