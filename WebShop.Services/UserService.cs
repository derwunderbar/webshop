using AutoMapper;
using WebShop.Data.Repositories;
using WebShop.Services.Models;

namespace WebShop.Services
{
    public interface IUserService
    {
        UserProfile Get(string userName);
        bool AddIfNotExists(string userName);
    }

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserProfile Get(string userName)
        {
            return Mapper.Map<UserProfile>(_userRepository.Get(userName));
        }

        public bool AddIfNotExists(string userName)
        {
            return _userRepository.AddIfNotExists(userName);
        }
    }
}