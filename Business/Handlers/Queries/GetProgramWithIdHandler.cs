using System;
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
    public class GetProgramWithIdHandler : IRequestHandler<GetProgramWithIdRequest, GetProgramWithIdResponse>
    {
        private readonly IEducationService _educationService;
        private GetProgramWithIdResponse _response;

        public GetProgramWithIdHandler(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<GetProgramWithIdResponse> Handle(GetProgramWithIdRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var program = _educationService.GetProgramwithId(request.Id);

                var model = new EducationProgramVM{
                    Id = program.Id,
                    Name = program.Name,
                    StartDate = program.StartDate,
                    EndDate = program.EndDate,
                    Status = program.Status,
                    Educations = program.Educations.Select(q => new EducationVM{
                        Id = q.Id,
                        ProgramId = q.ProgramId,
                        Name = q.Name,
                        Description = q.Description,
                        Link = q.Link
                    }).ToList()
                };

                _response = new GetProgramWithIdResponse{
                    IsSuccess = true,
                    Data = model
                };
            }
            catch (Exception ex)
            {
                _response = new GetProgramWithIdResponse
                {
                    IsSuccess = false,
                    Status = "ERROR",
                    Message = string.Format("Error while getting the program. Program : {0}", request.Id),
                    Exception = ex
                };
            }

            return await Task.FromResult(_response);
        }
    }
}
