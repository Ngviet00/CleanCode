using Clean_Code.Contexts;

namespace Clean_Code.Services
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
