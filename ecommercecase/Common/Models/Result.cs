using System;
using System.Collections.Generic;

namespace ecommercecase.Common.Models
{
    public class Result<T> where T: class
    {
        public bool Success { get { return Messages.Count == 0; } }
        public List<string> Messages { get; set; } = new List<string>();
        public T ResultObject { get; set; }
    }
}
