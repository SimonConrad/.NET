using System;
using System.Collections.Generic;

namespace Orders.Web.RequestModels
{
    public class OrderReqModel
    {
        public Guid Id { get; set; }

        public string  Address { get; set; }

        public List<OrderPositionReqModel> Positions { get; set; }
    }
}