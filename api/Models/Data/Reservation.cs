using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public string TimeStamp { get; set; }
        public string Status { get; set; }
      
        //Foreign Key
        public int ProjectionId { get; set; }
        public int UserId { get; set; }
        
    }
}