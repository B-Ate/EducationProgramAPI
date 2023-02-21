using System;
using System.Collections.Generic;
using System.Linq;
using educationprogramAPI.Business.services;
using educationprogramAPI.DataAccessLayer.DataModel;
using Microsoft.EntityFrameworkCore;

namespace Sales.Persis.SaleProcessor.Data.Business.Concrete
{
    public class EducationService : IEducationService
    {
        private readonly EducationDbContext _db;

        public EducationService(EducationDbContext db)
        {
            _db = db;
        }

        public bool AddEducation(Education education)
        {
           _db.Education.Add(education);
           return true;
        }

        public bool AddProgram(EducationProgram program)
        {
            _db.EducationPrograms.Add(program);
            _db.SaveChanges();
            return true;
        }

        public List<EducationProgram> GetPrograms()
        {
            var programs = _db.EducationPrograms.Include("Educations").ToList();
            return programs;
        }

        public EducationProgram GetProgramwithId(Guid id)
        {
            var program = _db.EducationPrograms.FirstOrDefault(q => q.Id == id);
            return program;
        }
    }
}
