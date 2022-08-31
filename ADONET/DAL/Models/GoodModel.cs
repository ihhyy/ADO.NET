using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class GoodModel
    {
        public int GoodsId { get; set; }

        public string GoodName { get; set; }

        public int GoodType { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }
    }
}
