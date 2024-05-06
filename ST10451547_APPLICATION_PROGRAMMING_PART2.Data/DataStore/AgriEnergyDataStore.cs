using Microsoft.EntityFrameworkCore;
using ST10451547_APPLICATION_PROGRAMMING_PART2.Data.Entities;

namespace ST10451547_APPLICATION_PROGRAMMING_PART2.Data.DataStore
{
    partial class DataStore
    {
        public Task<IEnumerable<Product>> GetProdutAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserAsync(User user, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.User.AsNoTracking().ToListAsync(cancellationToken);
        }

        public Task SaveProdutAsync(Product product)
        {
            throw new NotImplementedException();
        }

        public Task SaveRoleAsync(Role role)
        {
            throw new NotImplementedException();
        }

        public Task SaveUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
