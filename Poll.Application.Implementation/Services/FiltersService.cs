using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Poll.Application.Implementation.Contracts.Models;
using Poll.Application.Implementation.Contracts.Services;

namespace Poll.Application.Implementation.Services
{
    public class FiltersService : IFiltersService
    {
        public List<AcademicModel> GetFilter(string rawFilter)
        {
            var arrJson = JsonConvert.DeserializeObject<Root> (rawFilter);
            return arrJson.root.ToList();
        }
    }
}