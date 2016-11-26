using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class RecommendedMovie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}