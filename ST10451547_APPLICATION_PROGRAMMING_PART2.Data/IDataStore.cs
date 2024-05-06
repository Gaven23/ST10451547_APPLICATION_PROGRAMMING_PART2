using ST10451547_APPLICATION_PROGRAMMING_PART2.Data.Entities;

namespace ST10451547_APPLICATION_PROGRAMMING_PART2.Data
{
    public interface IDataStore
    {
        Task<User> GetUserAsync(User user, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetUsersAsync(CancellationToken cancellationToken = default);
        Task SaveUserAsync(User user);
        Task SaveProdutAsync(Product product);
        Task<IEnumerable<Product>> GetProdutAsync(CancellationToken cancellationToken = default);
        Task SaveRoleAsync(Role role);
    }
}
