using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Poll.Application.Implementation.Contracts.Models;
using Poll.Application.Implementation.Contracts.Services;

namespace Poll.Application.Implementation.Services
{
    public class StudentsService : IStudentsService
    {
        //TODO - Add config file & DI for config and singleton must admit DI.
        private const string Uri = "https://raw.githubusercontent.com/VoxelGroup/Katas.Code.AnonymousPoll/master/resources/students";

        private static StudentsService instance = new StudentsService();

        public static StudentsService Instance => instance;

        private List<StudentModel> _studentsRaw;

        private StudentsService()
        {
            _studentsRaw = new List<StudentModel>();
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(Uri);
            using (StreamReader sr = new StreamReader(stream))
            {
                while (sr.Peek() >= 0)
                {
                    var line = sr.ReadLine().Split(',');
                    _studentsRaw.Add(new StudentModel()
                    {
                        name = line[0],
                        academic_year = line[4],
                        age = line[2],
                        gender = line[1],
                        studies = line[3]
                    });
                }
            }
        }

        public List<StudentModel> GetRawData()
        {
            return _studentsRaw;
        }

        public List<StudentModel> GetNormalizeData()
        {
            var normalizeData = _studentsRaw.GroupBy(o => new {o.name , o.studies})
                .Select(grp => grp.First())
                .ToList();
            return normalizeData;
        }


    }
}
