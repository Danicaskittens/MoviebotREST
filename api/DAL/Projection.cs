//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace api.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Projection
    {
        public int ProjectionId { get; set; }
        public System.DateTime Date { get; set; }
        public int FreeSeats { get; set; }
        public int CinemaId { get; set; }
        public string ImdbId { get; set; }
    
        public virtual Movie Movie { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
