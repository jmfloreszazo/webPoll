using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Poll.Application.Implementation.Services;

namespace Poll.Presentation.WebUI.Controllers
{
    [Route("api/[controller]")]
    public class PollDataController : Controller
    {
        [HttpPost("[action]")]
        public async Task<string> Polls([FromBody]dynamic value)
        {
            PollService _pollService = new PollService();
            FiltersService _filtersService = new FiltersService();
            StudentsService _studentsService = StudentsService.Instance;
            var resultFilter = _filtersService.GetFilter(value.ToString());
            var normalizedStudentsResult = _studentsService.GetNormalizeData();
            var studens = _pollService.GetPoll(resultFilter, normalizedStudentsResult);
            return JsonConvert.SerializeObject(studens);
        }

    }
}
