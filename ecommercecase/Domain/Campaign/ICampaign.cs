﻿using System;
namespace ecommercecase.Domain.Campaign
{
    public interface ICampaign: IEntity
    {
        string GetInfo();
        void Process();
        void Deactive();
    }
}
