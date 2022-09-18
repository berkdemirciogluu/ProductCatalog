using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.Core.Utilities.Security.JWT;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.User;

namespace ProductCatalog.Business.Services.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
