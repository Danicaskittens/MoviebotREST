﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.Data
{
    public class MovieProjections
    {
        public Movie Movie { get; set; }
        public IEnumerable<Projection> Projections { get; set; }
        public MovieProjections addProjections(IEnumerable<Projection> projections)
        {
            this.Projections=this.Projections.Concat(projections);
            return this;
        }
    }
}