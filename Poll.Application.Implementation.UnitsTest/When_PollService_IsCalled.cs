using System.Collections.Generic;
using Poll.Application.Implementation.Contracts.Models;
using Poll.Application.Implementation.Services;
using Xunit;

namespace Poll.Application.Implementation.UnitTest
{
    public class When_PollService_IsCalled
    {
        private readonly PollService _pollService;
        private readonly FiltersService _filtersService;
        private readonly StudentsService _studentsService;

        public When_PollService_IsCalled()
        {
            _filtersService = new FiltersService();
            _studentsService = StudentsService.Instance;
            _pollService = new PollService();
        }

        [Fact]
        public void When_PollService_CanGetPoll()
        {
            string rawFilter = "{\"root\":[{\"academic_year\": \"2\",\"age\": \"20\",\"gender\": \"F\",\"studies\": \"Systems Engineering\"},{\"academic_year\": \"2\",\"age\": \"20\",\"gender\": \"F\",\"studies\": \"Systems Engineering\"}]}";
            var resultFilter = _filtersService.GetFilter(rawFilter);
            Assert.True(resultFilter.Count > 0);
            var normalizedStudentsResult = _studentsService.GetNormalizeData();
            Assert.True(normalizedStudentsResult.Count > 0 );
            var studens = _pollService.GetPoll(resultFilter, normalizedStudentsResult);
            Assert.True(studens.Count>0);
        }

    }
}