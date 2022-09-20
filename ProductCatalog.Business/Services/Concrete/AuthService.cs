using ProductCatalog.BackgroundWorkers.Entities;
using ProductCatalog.BackgroundWorkers.Services.Mail.RabbitMQ.Abstract;
using ProductCatalog.Business.Constants;
using ProductCatalog.Business.Services.Abstract;
using ProductCatalog.Business.ValidationRules.CustomValidation.AuthRules;
using ProductCatalog.Business.ValidationRules.FluentValidation.AuthValidation;
using ProductCatalog.Core.Aspects.Autofac.Validation;
using ProductCatalog.Core.Utilities.Business;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.Core.Utilities.Security.Hashing;
using ProductCatalog.Core.Utilities.Security.JWT;
using ProductCatalog.Entities.Concrete;
using ProductCatalog.Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IAuthRule _authRule;
        private IProducerService _producerService;

        public AuthService(IUserService userService, ITokenHelper tokenHelper, IAuthRule authRule, IProducerService producerService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _authRule = authRule;
            _producerService = producerService;
        }

        [ValidationAspect(typeof(UserForRegisterDtoValidator))]

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            var result = BusinessRules.Run(_authRule.CheckIfEmailExist(userForRegisterDto.Email));

            if (result != null)
            {
                return new ErrorDataResult<User>(result.Message);
            }

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        [ValidationAspect(typeof(UserForLoginDtoValidator))] 
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.LoginWarning);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.LoginWarning);
            }

            var email = new EmailToSend
            {
                To = userForLoginDto.Email,
                Subject = "Welcome",
                Body = "We missed you",
            };
            _producerService.Publish(email, RabbitMqQueue.EmailSenderQueue.ToString());

            return new SuccessDataResult<User>(userToCheck, Messages.SuccesfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.LoginWarning);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.TokenGenerated);
        }
    }
}
