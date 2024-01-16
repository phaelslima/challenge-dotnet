using Challenge.API.Models;
using MediatR;

namespace Challenge.API.Commands.DeclineLead
{
    public class DeclineLeadCommand : IRequest<LeadModel>
    {
        public DeclineLeadCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
