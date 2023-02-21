using System;
using System.Threading;
using System.Threading.Tasks;
using educationprogramAPI.Business.services;
using educationprogramAPI.DataAccessLayer.DataModel;
using educationprogramAPI.Models.Requests;
using educationprogramAPI.Models.Responses;
using MediatR;

namespace Sales.Persis.SaleProcessor.Data.Commands
{
    public class AddEducationHandler : IRequestHandler<AddEducationRequest, AddEducationResponse>
    {
        private readonly IEducationService _educationService;
        private AddEducationResponse _response;

        public AddEducationHandler(IEducationService educationService)
        {
            _educationService = educationService;
        }

        public async Task<AddEducationResponse> Handle(AddEducationRequest request, CancellationToken cancellationToken)
        {
            try
            {  
                var program = _educationService.GetProgramwithId(request.ProgramId);

                if(program is null)
                    throw new Exception(string.Format("Program is not found. ProgramId : {0}", request.ProgramId));
                
                _educationService.AddEducation(new Education{
                        Id = Guid.NewGuid(),
                        ProgramId = request.ProgramId,
                        Name = request.Name,
                        Description = request.Description,
                        Link = request.Link
                    }    
                );

                _response = new AddEducationResponse
                {
                    IsSuccess = true,
                    Message = string.Format("This education {0} is added to {1} Program.", request.Name, program.Name)
                };
            }
            catch (Exception ex)
            {
                _response = new AddEducationResponse
                {
                    IsSuccess = false,
                    Status = "ERROR",
                    Message = string.Format("Error while adding education to the program. Education : {0}", request.Name),
                    Exception = ex
                };
            }

            return await Task.FromResult(_response);
        }
    }
}
