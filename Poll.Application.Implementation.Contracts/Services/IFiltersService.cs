using System.Collections.Generic;
using Poll.Application.Implementation.Contracts.Models;

namespace Poll.Application.Implementation.Contracts.Services
{
    public interface IFiltersService
    {
        List<AcademicModel> GetFilter(string rawFilter);
    }
}