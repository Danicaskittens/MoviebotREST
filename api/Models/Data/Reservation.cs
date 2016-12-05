using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using api.Models.Data;

namespace api.Models
{
    public class Reservation
    {
        [Key]
        public string ReservationID { get; set; }

        public int Quantity { get; set; }
        public DateTime TimeStamp { get; set; }
     
        public enum Status
        {
            [Description("InProcess")]
            InProcess,
            [Description("Complete")]
            Complete
        };
        public Status StatusType { get; set; }

        //Foreign Key

        //ManyToOne
        public string ProjectionId { get; set; }
        public Projection Projection { get; set; }

        //OneToOne
        public string UserId { get; set; }
        
    }
}