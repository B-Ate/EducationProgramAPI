using educationprogramAPI.Models.Responses;
using MediatR;
using System.Collections.Generic;
using System;

namespace educationprogramAPI.Models.Requests
{
    public class AddProgramRequest : IRequest<AddProgramResponse>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }
        public List<EducationRequest> Educations { get; set; }
    }

    public class EducationRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}