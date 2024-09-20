using System.Collections.Generic;
using System.Threading.Tasks;
using code_dotnet.entities;
using code_dotnet.repositories;

namespace code_dotnet.services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserEntity> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }

        public async Task AddUserAsync(CreateUserDto user)
        {
            UserEntity userEntity = UserEntity.FromDto(user);
            await _userRepository.AddUserAsync(userEntity);
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }
    }
}
