using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using educationprogramAPI.Business.services;
using educationprogramAPI.DataAccessLayer.DataModel;
using educationprogramAPI.Models.Requests;
using educationprogramAPI.Models.Responses;
using educationprogramAPI.Models.ViewModel;
using MediatR;

namespace Sales.Persis.SaleProcessor.Data.Commands
{
    public class GetProgramsHandler : IRequestHandler<GetProgramsRequest, GetProgramsResponse>
    {
        private readonly IEducationService _educationService;
        private GetProgramsResponse _response;
        private List<EducationProgramVM> _programs = new List<EducationProgramVM>();

        public GetProgramsHandler(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<GetProgramsResponse> Handle(GetProgramsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var programs = _educationService.GetPrograms();

                if (programs != null)
                {
                    _programs = programs.Select(q => new EducationProgramVM
                    {
                        Id = q.Id,
                        Name = q.Name,
                        StartDate = q.StartDate,
                        EndDate = q.EndDate,
                        Status = q.Status,
                        Educations = q.Educations.Select(p => new EducationVM
                        {
                            Id = p.Id,
                            ProgramId = p.ProgramId,
                            Name = p.Name,
                            Description = p.Description,
                            Link = p.Link
                        }).ToList()
                    }).ToList();
                }

                _response = new GetProgramsResponse{
                    IsSuccess = true,
                    Data = _programs
                };
            }
            catch (Exception ex)
            {
                _response = new GetProgramsResponse
                {
                    IsSuccess = false,
                    Status = "ERROR",
                    Message = "Error while getting programs",
                    Exception = ex
                };
            }

            return await Task.FromResult(_response);
        }
    }
}
