using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Data
{
    public class CinemaProjection
    {
        public Cinema Cinema { get; set; }
        public string ImdbId { get; set; }
        public List<Projection> Projections { get; set; }

    }
}