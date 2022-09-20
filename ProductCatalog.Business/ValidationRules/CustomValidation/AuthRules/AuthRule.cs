using ProductCatalog.Business.Constants;
using ProductCatalog.Core.Utilities.Results;
using ProductCatalog.DataAccess.NHibernate.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalog.Business.ValidationRules.CustomValidation.AuthRules
{
    public class AuthRule : IAuthRule
    {
        IUserRepository _userRepository;

        public AuthRule(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult CheckIfEmailExist(string email)
        {
            var result = _userRepository.GetAll(p => p.Email == email).Where(p => p.IsDeleted == false).Any();
            if (result)
            {
                return new ErrorResult(Messages.EmailAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
