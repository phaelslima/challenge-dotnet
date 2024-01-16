using Challenge.API.Enums;
using MediatR;

namespace Challenge.API.Queries.GetAllLeadsByStatus
{
    public class GetAllLeadsByStatusQuery : IRequest<GetAllLeadsByStatusViewModel>
    {
        public GetAllLeadsByStatusQuery(LeadStatus status, int skip, int take)
        {
            Status = status;
            Skip = skip;
            Take = take;
        }

        public LeadStatus Status { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
