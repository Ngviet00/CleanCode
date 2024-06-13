using Clean_Code.Contexts;

namespace CleanCode.Services.Client
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
