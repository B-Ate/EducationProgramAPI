using System;
using educationprogramAPI.Models.Responses;
using MediatR;

namespace educationprogramAPI.Models.Requests
{
    public class GetProgramWithIdRequest : IRequest<GetProgramWithIdResponse>
    {
        public Guid Id { get; set; }
    }
}