using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Data
{
    public class CinemaProjections
    {
        public Cinema Cinema { get; set; }
        public IEnumerable<MovieProjections> MovieProjections { get; set; }

    }
}