using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fantastyka2.Models
{
    public class ShoppingCartModel
    {
        public Book Book { get; set; }
        public int Amount { get; set; }
    }
}