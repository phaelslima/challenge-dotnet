using MediatR;

namespace Challenge.API.Queries.GetAllLeads
{
    public class GetAllLeadsQuery : IRequest<GetAllLeadsViewModel>
    {
        public GetAllLeadsQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }
        public int Skip { get; set; }
        public int Take { get; set; }
    }
}
