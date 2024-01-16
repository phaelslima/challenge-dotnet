using Challenge.API.Models;
using Challenge.API.Repositories.Interfaces;
using MediatR;

namespace Challenge.API.Queries.GetAllLeadsByStatus
{
    public class GetAllLeadsByStatusHandler : IRequestHandler<GetAllLeadsByStatusQuery, GetAllLeadsByStatusViewModel>
    {
        private readonly ILeadRepository _leadRepository;

        public GetAllLeadsByStatusHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<GetAllLeadsByStatusViewModel> Handle(GetAllLeadsByStatusQuery request, CancellationToken cancellationToken)
        {
            List<LeadModel> data = await _leadRepository.GetByStatus(request.Status, request.Skip, request.Take);
            int count = _leadRepository.Count(x => x.Status == request.Status);

            GetAllLeadsByStatusViewModel result = new GetAllLeadsByStatusViewModel { Skip = request.Skip, Take = request.Take, Data = data, Count = count };
            return await Task.FromResult(result);
        }
    }
}
