using System;

namespace educationprogramAPI.Models.ViewModel
{
    public class EducationVM
    {
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}