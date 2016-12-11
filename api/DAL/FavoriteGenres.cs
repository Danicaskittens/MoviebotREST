using api.Models.Data;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace api.DAL
{
    public class FavoriteGenres
    {

        [Key]
        public string UserId { get; set; }
        public List<Genre> Genres { get; set; }

    }
}