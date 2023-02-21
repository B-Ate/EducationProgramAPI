using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using educationprogramAPI.Business.services;
using educationprogramAPI.DataAccessLayer.DataModel;
using educationprogramAPI.Models.Requests;
using educationprogramAPI.Models.Responses;
using MediatR;

namespace Sales.Persis.SaleProcessor.Data.Commands
{
    public class AddProgramHandler : IRequestHandler<AddProgramRequest, AddProgramResponse>
    {
        private readonly IEducationService _educationService;
        private AddProgramResponse _response;

        public AddProgramHandler(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<AddProgramResponse> Handle(AddProgramRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var newId = Guid.NewGuid();

                var program = new EducationProgram{
                    Id = newId,
                    Name = request.Name,
                    StartDate = request.StartDate,
                    EndDate = request.EndDate,
                    Status = request.Status,
                    Educations = request.Educations.Select(q => new Education
                    {
                        Id = Guid.NewGuid(),
                        ProgramId = newId,
                        Name = q.Name,
                        Description = q.Description,
                        Link = q.Link
                    }).ToList()
                };

                _educationService.AddProgram(program);

                _response = new AddProgramResponse
                {
                    IsSuccess = true,
                    Message = string.Format("This program is added. Program : {0}", request.Name)
                };
            }
            catch (Exception ex)
            {
                _response = new AddProgramResponse
                {
                    IsSuccess = false,
                    Status = "ERROR",
                    Message = string.Format("Error while adding the program. Program : {0}", request.Name),
                    Exception = ex
                };
            }

            return await Task.FromResult(_response);
        }
    }
}
