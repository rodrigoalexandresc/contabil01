using Microsoft.EntityFrameworkCore;

namespace Fluxo.Data
{
    public abstract class AbstractRepository 
    {
        public DbContext _dbContext { get; set; }

        protected AbstractRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit() => await _dbContext.SaveChangesAsync();
    }
}
