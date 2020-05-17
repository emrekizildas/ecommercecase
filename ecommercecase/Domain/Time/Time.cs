using System;
using System.Linq;
using ecommercecase.Domain.Exceptions;

namespace ecommercecase.Domain.Time
{
    public class Time : ITime
    {
        public int Hour { get; set; }
        public DateTime DateTime { get { return DateTime.Now.Date.AddHours(Hour); } }
        public event EventHandler<TimeEventArgs> OnTimeIncreaseProcess;

        public Time()
        {
            OnTimeIncreaseProcess += Process;
        }


        public void Increase(string[] args)
        {
            try
            {
                int appendHour = int.Parse(args[1]);
                OnTimeIncreaseProcess?.Invoke(this, new TimeEventArgs(appendHour));
            }
            catch
            {
                throw new CommandException(701, "The time could not be increased.");
            }
        }

        private void Process(object sender, TimeEventArgs e)
        {
            Hour += e.IncreaseTime;

            var activeCampaigns = Context.Campaigns.Where(i => i.Status == Campaign.Campaign.CampaignStatus.Active).ToList();
            activeCampaigns.ForEach(i => i.Process());

            var deactivedCampaings = Context.Campaigns.Where(i => i.Status == Campaign.Campaign.CampaignStatus.Ended && i.Product.Price != i.Product.MainPrice).ToList();
            deactivedCampaings.ForEach(i => i.Deactive());
        }


    }
}
