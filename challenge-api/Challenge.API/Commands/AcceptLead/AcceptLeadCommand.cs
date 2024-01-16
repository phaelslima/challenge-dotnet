using Challenge.API.Models;
using MediatR;

namespace Challenge.API.Commands.AcceptLead
{
    public class AcceptLeadCommand : IRequest<LeadModel>
    {
        public AcceptLeadCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
