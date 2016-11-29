using System.Runtime.Serialization;

namespace api.Models.Data
{
    [DataContract]
    public class Movie
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Year { get; set; }
        [DataMember]
        public string Rated { get; set; }
        [DataMember]
        public string Released { get; set; }
        [DataMember]
        public string Runtime { get; set; }
        [DataMember]
        public string Genre { get; set; }
        [DataMember]
        public string Director { get; set; }
        [DataMember]
        public string Writer { get; set; }
        [DataMember]
        public string Actors { get; set; }
        [DataMember]
        public string Plot { get; set; }
        [DataMember]
        public string Language { get; set; }
        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public string Awards { get; set; }
        [DataMember]
        public string Poster { get; set; }
        [DataMember]
        public string Metascore { get; set; }
        [DataMember]
        public string imdbRating { get; set; }
        [DataMember]
        public string imdbVotes { get; set; }
        [DataMember]
        public string ImdbId { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Response { get; set; }
        public bool InTheaters { get; set; }
    }
}