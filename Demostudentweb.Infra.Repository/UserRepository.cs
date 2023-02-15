using Demostudentweb.Infra.Contract;
using Demostudentweb.Infra.Domain;
using Demostudentweb.Infra.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demostudentweb.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly  DemostudentwebContext _demostudentwebContext;

        public UserRepository(DemostudentwebContext demostudentwebContext)
        {
           _demostudentwebContext= demostudentwebContext;
        }
        public async Task<int> AddUser(User user)
        {
            await _demostudentwebContext.users.AddAsync(user);


            return await _demostudentwebContext.SaveChangesAsync();
        }

        public async Task<User?> LoginUser(string userName)
        {
            try
            {
                var users = await _demostudentwebContext.users.FirstOrDefaultAsync(x => x.UserName == userName);
                return users;
            }
            catch (Exception)
            {

                throw; 
            }
        }
    }
}
