﻿using System;
using System.Linq;
using ecommercecase.Domain.Exceptions;

namespace ecommercecase.Domain.Product
{
    public class Product : IProduct
    {
        public string Code { get; set; }
        public int Price { get; set; }
        public int MainPrice { get; set; }
        public int Stock { get; set; }

        public Product(string[] args) => Verify(args);

        public void Verify(string[] args)
        {
            if (Context.Products.SingleOrDefault(i => i.Code.ToLower() == Code.ToLower()) != null)
                throw new CommandException(402, "There is a product with the same code.");

            try
            {
                Code = args[1];
                Price = int.Parse(args[2]);
                MainPrice = int.Parse(args[2]);
                Stock = int.Parse(args[3]);
            }
            catch
            {
                throw new CommandException(401, "There was an error creating the product.");
            }
        }

        public string GetInfo()
        {
            return $"Product {Code} info; price: {Price}, stock {Stock}";
        }

    }
}
