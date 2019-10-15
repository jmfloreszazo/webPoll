using System.Collections.Generic;
using Poll.Application.Implementation.Contracts.Models;

namespace Poll.Application.Implementation.Contracts.Services
{
    public interface IStudentsService
    {
        List<StudentModel> GetRawData();
        List<StudentModel> GetNormalizeData();
    }
}