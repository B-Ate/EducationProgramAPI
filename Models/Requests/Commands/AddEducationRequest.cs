using educationprogramAPI.Models.Responses;
using MediatR;
using System;

namespace educationprogramAPI.Models.Requests
{
    public class AddEducationRequest : IRequest<AddEducationResponse>
    {
        public Guid ProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
    }
}