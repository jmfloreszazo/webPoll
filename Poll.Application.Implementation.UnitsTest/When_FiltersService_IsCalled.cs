using System.Collections.Generic;
using Poll.Application.Implementation.Contracts.Models;
using Poll.Application.Implementation.Services;
using Xunit;

namespace Poll.Application.Implementation.UnitTest
{
    public class When_FiltersService_IsCalled
    {
        private readonly FiltersService _filtersService;

        public When_FiltersService_IsCalled()
        {
            _filtersService = new FiltersService();
        }

        [Fact]
        public void Given_FiltersService_CanGetFilters()
        {
            string rawFilter = "{\"root\":[{\"academic_year\": \"2\",\"age\": \"20\",\"gender\": \"F\",\"studies\": \"Systems Engineering\"},{\"academic_year\": \"2\",\"age\": \"20\",\"gender\": \"F\",\"studies\": \"Systems Engineering\"}]}";
            var result = _filtersService.GetFilter(rawFilter);
            Assert.True(result.Count>0);
        }

    }
}