using Challenge.API.Commands.AcceptLead;
using Challenge.API.Commands.DeclineLead;
using Challenge.API.Enums;
using Challenge.API.Models;
using Challenge.API.Queries.GetAllLeads;
using Challenge.API.Queries.GetAllLeadsByStatus;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [Route("api/leads")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetAllLeadsViewModel> Get([FromQuery] int skip = 0, [FromQuery] int take = 25)
        {
            return await _mediator.Send(new GetAllLeadsQuery(skip, take));
        }

        [HttpGet("status/{status}")]
        public async Task<GetAllLeadsByStatusViewModel> GetByStatus([FromRoute] LeadStatus status, [FromQuery] int skip = 0, [FromQuery] int take = 25)
        {
            return await _mediator.Send(new GetAllLeadsByStatusQuery(status, skip, take));
        }

        [HttpPost("{id}/accept")]
        public async Task<LeadModel> Accept([FromRoute] int id)
        {
            return await _mediator.Send(new AcceptLeadCommand(id));
        }

        [HttpPost("{id}/decline")]
        public async Task<LeadModel> Decline([FromRoute] int id)
        {
            return await _mediator.Send(new DeclineLeadCommand(id));
        }
    }
}
