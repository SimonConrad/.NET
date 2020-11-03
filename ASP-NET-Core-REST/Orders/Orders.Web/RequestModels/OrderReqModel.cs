using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Orders.Web.RequestModels
{
    public class OrderReqModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(10)]
        public string  Address { get; set; }

        [Required]
        public List<OrderPositionReqModel> Positions { get; set; }
    }
}