using NHibernate.Linq;
using System.Collections.Generic;
using System.Linq;

namespace Coding_Challenge.Models.Persistance
{
    public class CitiesRepository : ICitiesRepository
    {

        public const string CANADA = "Canada";
        public const string UNITED_STATES = "United States";

        /// <summary>
        /// Function used to retrieve a city by it's ID
        /// </summary>
        /// <param name="id">ID of a city</param>
        /// <returns>An object of type Cities</returns>
        public Cities Get(int id)
        {
            using (var session = Utility.NHibernateUtility.OpenSession())
                return session.Get<Cities>(id);
        }

        /// <summary>
        /// Function used to retrieve all cities. 
        /// </summary>
        /// <returns>Collection of Cities</returns>
        public IEnumerable<Cities> GetAll()
        {
            using (var session = Utility.NHibernateUtility.OpenSession())
                return session.Query<Cities>().ToList();
        }

        /// <summary>
        /// Function used to retrieve cities by criteria. CA suggestions are returned first.
        /// </summary>
        /// <param name="q">Name of the city</param>
        /// <param name="lat">Latitude</param>
        /// <param name="long">Longitude</param>
        /// <returns>Collection of Cities filtered by criteria and sorted by score descending</returns>
        public IEnumerable<Cities> GetSuggestionsByCriteria(string q, float? lat = null, float? @long = null)
        {
            using (var session = Utility.NHibernateUtility.OpenSession())

                //Very simple score algorithm based on country, CA being proposed first
                return session.Query<Cities>().ToList().Select(c => new Cities
                {
                    Id = c.Id,
                    name = (c.name + ", " + c.stateprov + ", " + (c.country == "CA" ? CANADA : UNITED_STATES)), // Display proper Country from Country code
                    lat = c.lat,
                    @long = c.@long,
                    score = (c.country == "CA" ? 1 : 0) //Score algorithm should be moved in a separate function if further complexity is added
                })
                                                    .Where(c => (string.IsNullOrEmpty(q) || c.name.ToLower().StartsWith(q.ToLower()))
                                                                && (lat == null || c.lat == lat)
                                                                && (@long == null) || c.@long == @long)
                                                    .OrderByDescending(c => c.score);
        }

    }
}