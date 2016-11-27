using api.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;

namespace api.Adapters
{
    /// <summary>
    /// Collection of omdb adapter functions
    /// </summary>
    public class OmdbAdapters
    {
        /// <summary>
        /// Returns the movie information from the omdb database for the specified imdbID
        /// </summary>
        /// <param name="imdbID">imdb id of the movie to search the result</param>
        /// <returns>the movie object containing the information of the specified movie</returns>
        public static Movie GetMovieInfo(string imdbID)
        {
            string UrlRequest = $"http://www.omdbapi.com/?i={imdbID}&plot=short&r=json";
            try
            {
                HttpWebRequest request = WebRequest.Create(UrlRequest) as HttpWebRequest;
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                        throw new Exception(String.Format(
                        "Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Movie));
                    object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                    Movie jsonResponse = objResponse as Movie;
                    return jsonResponse;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}