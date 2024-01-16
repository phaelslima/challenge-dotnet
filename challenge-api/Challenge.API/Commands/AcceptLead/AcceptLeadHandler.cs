using Challenge.API.Enums;
using Challenge.API.Models;
using Challenge.API.Repositories.Interfaces;
using Challenge.API.Services.Dto;
using Challenge.API.Services.Interfaces;
using MediatR;

namespace Challenge.API.Commands.AcceptLead
{
    public class AcceptLeadHandler : IRequestHandler<AcceptLeadCommand, LeadModel>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IMailService _mailService;

        public AcceptLeadHandler(ILeadRepository leadRepository, IMailService mailService)
        {
            _leadRepository = leadRepository;
            _mailService = mailService;
        }

        public async Task<LeadModel> Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
        {
            LeadModel result = await _leadRepository.GetById(request.Id);

            if (result.Status != LeadStatus.Received) throw new Exception("It is not possible to change this lead!");

            result.Status = LeadStatus.Accept;

            if (result.Price > 500)
            {
                result.TotalPrice = result.Price - result.Price / 100 * 10;
            }
            else
            {
                result.TotalPrice = result.Price;
            }

            MailDto mail = new MailDto { To = "vendas@test.com", Subject = "Lead #" + result.Id + " Accept", Body = "Lead #" + result.Id + " Accept" };

            _mailService.SendEmail(mail);

            await _leadRepository.Update(request.Id, result);

            return await Task.FromResult(result);
        }
    }
}
