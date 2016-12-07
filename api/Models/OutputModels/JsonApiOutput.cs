using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api.Models.OutputModels
{   /// <summary>
    /// Base response of the api that follows the Jsonapi standard
    /// </summary>
    /// <typeparam name="T">Type of the data object</typeparam>
    public class JsonApiOutput<T>
    {

        private T data;

        public JsonApiOutput()
        {
           
        }

        /// <summary>
        /// Create a new Base Output model 
        /// </summary>
        public JsonApiOutput(T data)
        {
            this.data = data;
        }
        /// <summary>
        /// Returns or sets the data object of the response
        /// </summary>
        public T Data
        {
            get { return data; }
            set { data = value; }
        }

    }
}