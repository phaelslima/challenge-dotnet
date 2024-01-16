using Challenge.API.Models;
using Challenge.API.Repositories.Interfaces;
using MediatR;

namespace Challenge.API.Queries.GetAllLeads
{
    public class GetAllLeadsHandler : IRequestHandler<GetAllLeadsQuery, GetAllLeadsViewModel>
    {
        private readonly ILeadRepository _leadRepository;

        public GetAllLeadsHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<GetAllLeadsViewModel> Handle(GetAllLeadsQuery request, CancellationToken cancellationToken)
        {
            List<LeadModel> data = await _leadRepository.GetAll(request.Skip, request.Take);
            int count = _leadRepository.Count();

            GetAllLeadsViewModel result = new GetAllLeadsViewModel { Skip = request.Skip, Take = request.Take, Data = data, Count = count };
            return await Task.FromResult(result);
        }
    }
}
