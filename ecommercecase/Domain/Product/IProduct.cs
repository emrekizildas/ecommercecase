using System;
namespace ecommercecase.Domain.Product
{
    public interface IProduct: IEntity
    {
        string GetInfo();
    }
}
