using CleanCode.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanCode.Application.Services.Client
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;

        public DataService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Domain.Entities.Data>> GetData()
        {
            return await _dbContext.Data.Take(10).ToListAsync();
        }
    }
}
