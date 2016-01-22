using Coding_Challenge.Models.Persistance;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Coding_Challenge.Controllers
{
    [RoutePrefix("suggestions")]
    public class SuggestionsController : ApiController
    {

        static readonly ICitiesRepository CitiesRepository = new CitiesRepository();

        /// <summary>
        /// Function to retrieve all suggestions
        /// </summary>
        /// <returns>A collection of Cities</returns>
        /// http://localhost:62048/suggestions/GetAllSuggestions
        [Route("GetAllSuggestions")]
        public IEnumerable<Cities> GetSuggestions()
        {
            return CitiesRepository.GetAll();
        }

        /// <summary>
        /// Function to retrieve the suggestions by criteria
        /// </summary>
        /// <param name="q">Name of the city</param>
        /// <param name="lat">Latitude</param>
        /// <param name="long">Longitude</param>
        /// <returns>A collection of Cities</returns>
        [Route("{q:alpha:minlength(3)?}/{lat:float?}/{long:float?}")]
        public IEnumerable<Cities> GetSuggestionsByCriteria(string q = null, float? lat = null, float? @long = null)
        {
            var cities = CitiesRepository.GetSuggestionsByCriteria(q, lat, @long);

            if (cities != null && cities.Count() == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return cities;
        }

    }
}
