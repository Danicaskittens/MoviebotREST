using api.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using api.DAL;

namespace api.Models.OutputModels
{
    /// <summary>
    /// Information of a specific cinema
    /// </summary>
    public class CinemaOutputModel
    {
        private Cinema cinema;
        /// <summary>
        /// Create a new cinema output model based on a specific cinema
        /// </summary>
        /// <param name="cinema"></param>
        public CinemaOutputModel(Cinema cinema)
        {
            this.cinema = cinema;
        }
        /// <summary>
        /// Name of the cinema (ex. Cinema Orfeo)
        /// </summary>
        public string Name { get { return this.cinema.Name; } }
        /// <summary>
        /// Unique integer value of the cinema (ex. 15)
        /// </summary>
        public int CinemaID { get { return this.cinema.CinemaId; } }
        /// <summary>
        /// Physical address of the cinema
        /// </summary>
        public string Address { get { return this.cinema.Address; } }
        /// <summary>
        /// Latitude of the cinema (ex. 48.4017343) 
        /// </summary>
        public double Latitude { get { return this.cinema.Latitude; } }
        /// <summary>
        /// Latitude of the cinema (ex 20.2327984)
        /// </summary>
        public double Longitude { get { return this.cinema.Longitude; } }
        /// <summary>
        /// Phone number of the cinema (ex. +39123456789)
        /// </summary>
        public string PhoneNumber { get { return this.cinema.PhoneNumber; } }
        /// <summary>
        /// Region in which the cinema is located (ex. Banská Bystrica)
        /// </summary>
        public string Region { get { return this.cinema.Region; } }
        /// <summary>
        /// Province (or district) in which the cinema is located (ex. Rimavská Sobota)
        /// </summary>
        public string Province { get { return this.cinema.Province; } }
        /// <summary>
        /// City in which the cinema is located 
        /// </summary>
        public string City { get { return this.cinema.City; } }
    }
}