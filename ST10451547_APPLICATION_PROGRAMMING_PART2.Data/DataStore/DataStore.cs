using ST10451547_APPLICATION_PROGRAMMING_PART2.Data.Entities;

namespace ST10451547_APPLICATION_PROGRAMMING_PART2.Data.DataStore
{
    public partial class DataStore : IDataStore
    {
        private readonly ApplicationDbContext _dbContext;

        public DataStore(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
