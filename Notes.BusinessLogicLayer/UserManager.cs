using Notes.DataAccessLayer.Concrete;
using Notes.Entities;
using Notes.WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.BusinessLogicLayer
{
    public class UserManager
    {
        private Repository<User> repo_user = new Repository<User>();
        BusinessLayerResult<User> businessLayerResult = new BusinessLayerResult<User>();
        public BusinessLayerResult<User> RegisterUser(RegisterViewModel registerViewModel)
        {
            User user = repo_user.Find(x => x.UserName == registerViewModel.Username || registerViewModel.Email == x.Email);
            if(user != null)
            {
                if(user.UserName == registerViewModel.Username)
                {
                    businessLayerResult.AddError(Entities.Messages.ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı adı zaten kayıtlı.");
                }
                if(user.Email == registerViewModel.Email)
                {
                    businessLayerResult.AddError(Entities.Messages.ErrorMessageCode.EmailAlreadyExists, "Email adresi zaten kayıtlı.");
                }
            }

            else
            {
                int dbResult = repo_user.Insert(new User()
                {
                    UserName =registerViewModel.Username,
                    Email = registerViewModel.Email,
                    Password = registerViewModel.Password
                });

                if(dbResult > 1)
                {
                    businessLayerResult.Result = repo_user.Find(x => x.UserName == registerViewModel.Username && registerViewModel.Email == x.Email);
                }
            }
            return businessLayerResult;
            

        }

        public BusinessLayerResult<User> LoginUser(LoginViewModel loginViewModel)
        {
            businessLayerResult.Result = repo_user.Find(x => x.UserName == loginViewModel.Username && x.Password == loginViewModel.Password);
            if(businessLayerResult.Result != null)
            {
                if (businessLayerResult.Result.IsActive == false)
                {
                    businessLayerResult.AddError(Entities.Messages.ErrorMessageCode.UserIsNotActive, "Kullanıcı aktifleştirilmemiştir.");
                    businessLayerResult.AddError(Entities.Messages.ErrorMessageCode.CheckYourEmail, "Lütfen e - posta adresinizi kontrol ediniz.");
                   
                }
            }
            else
            {
                businessLayerResult.AddError(Entities.Messages.ErrorMessageCode.UsernameOrPassWrong, "Kullanıcı adı veya şifre uyuşmuyor.");
            }

            return businessLayerResult;
        }
    }
}
