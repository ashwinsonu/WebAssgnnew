using System;
using System.Collections.Generic;

#nullable disable

namespace WebAssgn.AssignModel
{
    public partial class Order
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public DateTime? Toa { get; set; }
    }
}
