using ASTS.DTOs;
using ASTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASTS.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> AddNewUser(NewUserRequest newUserRequest, string identityId);
        string GeneratePassword();
    }
}
