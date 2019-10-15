using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;
using Poll.Application.Implementation.Contracts.Models;

namespace Poll.Application.Implementation.Services
{
    public class PollService
    {
        public List<PollResponseModel> GetPoll(List<AcademicModel> filters, List<StudentModel> students)
        {
            const string NONE = "NONE";
            var result = new List<PollResponseModel>();
            int loop = 0;
            foreach (var filter in filters)
            {
                loop++;
                var items = students.Where(o =>
                        o.studies == filter.studies && o.gender == filter.gender &&
                        o.academic_year == filter.academic_year && o.studies == filter.studies).ToList();
                if (items.Count == 0)
                {
                    result.Add(new PollResponseModel()
                    {
                        Case = loop,
                        Students = NONE
                    });
                }
                else
                {
                    result.Add(new PollResponseModel()
                    {
                        Case = loop,
                        Students = string.Join(",", items.Select(x => x.name))
                    });
                }
            }
            return result;
        }
    }
}