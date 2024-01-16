using Challenge.API.Enums;
using Challenge.API.Models;
using Challenge.API.Repositories.Interfaces;
using MediatR;

namespace Challenge.API.Commands.DeclineLead
{
    public class DeclineLeadHandler : IRequestHandler<DeclineLeadCommand, LeadModel>
    {
        private readonly ILeadRepository _leadRepository;

        public DeclineLeadHandler(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<LeadModel> Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
        {
            LeadModel result = await _leadRepository.GetById(request.Id);

            if (result.Status != LeadStatus.Received) throw new Exception("It is not possible to change this lead!");

            result.Status = LeadStatus.Decline;

            await _leadRepository.Update(request.Id, result);

            return await Task.FromResult(result);
        }
    }
}
