using WebApplication7.Data.Models;
using WebApplication7.Models.DTO;

namespace WebApplication7.Services
{
    public interface IAuthService
    {
        User? GetUserByCredentials(UserCredentialsDto userCredentialsDto);
        void CreateUser(NewUserDto newUserDto);
    }
}
