using Challenge.API.Enums;
using Challenge.API.Models;
using System.Linq.Expressions;

namespace Challenge.API.Repositories.Interfaces
{
    public interface ILeadRepository
    {
        Task<List<LeadModel>> GetAll(int skip, int take);
        Task<List<LeadModel>> GetByStatus(LeadStatus status, int skip, int take);
        int Count();
        int Count(Expression<Func<LeadModel, bool>> filter);
        Task<LeadModel> GetById(int id);
        Task<LeadModel> Update(int id, LeadModel lead);
    }
}
