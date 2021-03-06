namespace api.DAL
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Reservation
    {
        [Key]
        public int ReservationId { get; set; }
        public int Quantity { get; set; }
        public DateTime TimeStamp { get; set; }

        public enum Status
        {
            [Description("InProcess")]
            InProcess,
            [Description("Complete")]
            Complete,
            [Description("Canceled")]
            Canceled
        };
        public Status StatusType { get; set; }
        public int ProjectionId { get; set; }
        public string UserId { get; set; }
        public System.DateTime ProjectionDateTime { get; set; }
        public string ProjectionCity { get; set; }
        public string ProjectionCinema { get; set; }
        public string ProjectionMovie { get; set; }

        public Projection Projection { get; set; }
    }
}
