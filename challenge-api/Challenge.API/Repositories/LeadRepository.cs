using Challenge.API.Data;
using Challenge.API.Enums;
using Challenge.API.Models;
using Challenge.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Challenge.API.Repositories
{
    public class LeadRepository : ILeadRepository
    {
        private readonly AppDbContext _dbContext;

        public LeadRepository(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        public async Task<List<LeadModel>> GetAll(int skip, int take)
        {
            return await _dbContext.Leads.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<List<LeadModel>> GetByStatus(LeadStatus status, int skip, int take)
        {
            return await _dbContext.Leads.Where(x => x.Status == status).Skip(skip).Take(take).ToListAsync();
        }

        public int Count()
        {
            return _dbContext.Leads.Count();
        }

        public int Count(Expression<Func<LeadModel, bool>> filter)
        {
            return _dbContext.Leads.Where(filter).Count();
        }

        public async Task<LeadModel> GetById(int id)
        {
            LeadModel result = await _dbContext.Leads.FirstOrDefaultAsync(x => x.Id == id); ;

            if (result == null) throw new Exception("Lead not found!");

            return result;
        }

        public async Task<LeadModel> Update(int id, LeadModel lead)
        {
            LeadModel result = await GetById(id);

            result.Status = lead.Status;
            result.TotalPrice = lead.TotalPrice;

            _dbContext.Leads.Update(result);
            await _dbContext.SaveChangesAsync();

            return result;
        }
    }
}
