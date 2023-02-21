using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using educationprogramAPI.DataAccessLayer.DataModel;

namespace educationprogramAPI.Business.services
{
    public interface IEducationService
    {
        bool AddEducation(Education education);
        bool AddProgram(EducationProgram program);
        List<EducationProgram> GetPrograms();
        EducationProgram GetProgramwithId(Guid id);
    }
}