using System;
using System.Linq;
using ecommercecase.Domain.Exceptions;

namespace ecommercecase.Domain.Order
{
    public class Order: IOrder
    {
        public int ActionTime { get; set; }
        public int TotalPrice { get { return UnitPrice * Quantity; } }
        public int Quantity { get; set; }
        public int UnitPrice { get; set; }
        public Product.Product Product { get; set; }

        public Order(string[] args) => Verify(args);

        public void Verify(string[] args)
        {
            try
            {
                int actionTime = Context.Time.Hour;
                ActionTime = actionTime;
                Product = Context.Products.SingleOrDefault(i => i.Code.ToLower() == args[1].ToLower()) ?? throw new Exception();
                UnitPrice = Product.Price;
                Quantity = int.Parse(args[2]);
                Product.Stock -= Quantity;
            }
            catch
            {
                throw new CommandException(601, "Sipariş oluşturulurken bir hata meydana geldi.");
            }
        }
    }
}
