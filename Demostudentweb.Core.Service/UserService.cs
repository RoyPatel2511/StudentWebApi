using Demostudentweb.Configuration;
using Demostudentweb.Core.Builder;
using Demostudentweb.Core.Contract;
using Demostudentweb.Core.Domain.Exception;
using Demostudentweb.Core.Domain.RequestModel;
using Demostudentweb.Infra.Contract;
using Demostudentweb.Infra.Domain.Entities;
using Demostudentweb.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userrepository;
        private readonly GenerateToken _generateToken;

        public UserService(IUserRepository userrepository,GenerateToken generateToken)
        {
            _userrepository = userrepository;
            _generateToken = generateToken;
        }

        public async Task AddUserAync(UserRequestModel userRequestModel)
        {

            try
            {
                var hmc = new HMACSHA512();
                var password = hmc.ComputeHash(Encoding.ASCII.GetBytes(userRequestModel.Password));
                var passwordKey = hmc.Key;
                var user = UserBuilder.Build(userRequestModel, password, passwordKey);
                var count = await _userrepository.AddUser(user);
                if (count == 0)
                {
                    throw new BadRequestException("User is not created succssfully.");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<string> LoginUserAync(LoginModel loginModel)
        {
            try
            {
                var user = await _userrepository.LoginUser(loginModel.UserName);

                if (user == null)
                {
                    throw new BadRequestException("User Does not exist!!");
                }
                var hmc = new HMACSHA512(user.PasswordKey);
                var hmcData = hmc.ComputeHash(Encoding.ASCII.GetBytes(loginModel.Password));
                if (hmcData.SequenceEqual(user.Password))
                {
                    var token = await _generateToken.GenerateTokenData(user);
                    return token;
                }
                else
                {
                    throw new NotFoundException("not found!!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
