using System.Collections.Generic;

namespace Coding_Challenge.Models.Persistance
{
    interface ICitiesRepository
    {
        Cities Get(int id);
        IEnumerable<Cities> GetAll();
        IEnumerable<Cities> GetSuggestionsByCriteria(string q, float? latitude, float? longitude);
    }
}
