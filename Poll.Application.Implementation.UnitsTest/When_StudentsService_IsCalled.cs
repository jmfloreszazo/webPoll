using Poll.Application.Implementation.Services;
using System;
using Xunit;

namespace Poll.Application.Implementation.UnitTest
{
    public class When_StudentsService_IsCalled
    {
        private readonly StudentsService _studentsService;

        public When_StudentsService_IsCalled()
        {
            _studentsService = StudentsService.Instance;
        }

        [Fact]
        public void Given_StudentsService_AtLeastHaveData()
        {
            var rawResult = _studentsService.GetRawData();

            Assert.True(rawResult.Count > 0);
        }

        [Fact]
        public void Given_StudentsService_NormalizedData()
        {
            var normalizedResult = _studentsService.GetNormalizeData();
            Assert.True(normalizedResult.Count >0);
        }

    }
}