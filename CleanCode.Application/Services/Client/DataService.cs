using CleanCode.Infrastructure.Context;

namespace CleanCode.Application.Services.Client
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;

        public DataService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
