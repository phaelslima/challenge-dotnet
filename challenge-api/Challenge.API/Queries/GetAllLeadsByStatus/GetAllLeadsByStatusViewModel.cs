using Challenge.API.Models;

namespace Challenge.API.Queries.GetAllLeadsByStatus
{
    public class GetAllLeadsByStatusViewModel
    {
        public int Skip { get; set; }
        public int Take { get; set; }
        public int Count { get; set; }
        public List<LeadModel> Data { get; set; }
    }
}
