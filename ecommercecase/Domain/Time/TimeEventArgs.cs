using System;
namespace ecommercecase.Domain.Time
{
    public class TimeEventArgs: EventArgs
    {
        public int IncreaseTime { get; set; }

        public TimeEventArgs(int increaseTime)
        {
            this.IncreaseTime = increaseTime;
        }
    }
}
