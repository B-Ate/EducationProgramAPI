using System;
using System.Collections.Generic;

namespace educationprogramAPI.Models.ViewModel
{
    public class EducationProgramVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
        public List<EducationVM> Educations { get; set; }
    }
}