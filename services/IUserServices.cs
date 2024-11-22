using code_dotnet.entities;

namespace code_dotnet.services
{
    public interface IUserService
    {
        Task<UserEntity> GetUserByIdAsync(int id);
        Task<IEnumerable<UserEntity>> GetAllUsersAsync();
        Task AddUserAsync(CreateUserDto user);
        Task UpdateUserAsync(UserEntity user);
        Task DeleteUserAsync(int id);
        Task UpdateUserAsync(int id);
    }
}
