using System;
using System.Collections.Generic;

namespace ecommercecase.Common
{
    public static class Constants
    {
        public const string CreateProduct = "create_product";
        public const string CreateOrder = "create_order";
        public const string CreateCampaign = "create_campaign";

        public const string ProductInfo = "get_product_info";
        public const string CampaignInfo = "get_campaign_info";

        public const string IncreaseTime = "increase_time";

        public const string Using_CreateProduct = "create_product PRODUCTCODE PRICE STOCK";
        public const string Using_CreateOrder = "create_order PRODUCTCODE QUANTITY";
        public const string Using_CreateCampaign = "create_campaign NAME PRODUCTCODE DURATION PMLIMIT TARGETSALESCOUNT";
        public const string Using_ProductInfo = "get_product_info PRODUCTCODE";
        public const string Using_CampaignInfo = "get_campaign_info NAME";
        public const string Using_IncreaseTime = "increase_time HOUR";

    }
}
