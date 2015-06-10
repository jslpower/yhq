using System;
using System.Collections.Generic;
using System.Text;

namespace Eyousoft_yhq.Model
{
    public partial class OrderFlight
    {
        public int PCount { get; set; }
        //
        public decimal PPrice { get; set; }
        //机/油
        public decimal jyPrice { get; set; }
        //保险
        public decimal bxPrice { get; set; }
        //快递
        public decimal kdPrice { get; set; }
        //总价
        public decimal totalPrice { get; set; }

    }
}
