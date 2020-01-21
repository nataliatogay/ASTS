using ASTS.DTOs;
using ASTS.EF;
using ASTS.Models;
using ASTS.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTS.Services
{
    public class UserService: IUserService
    {
        private readonly IAsyncRepository _repository;

        public UserService(IAsyncRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> AddNewUser(NewUserRequest newUserRequest, string identityId)
        {
            var newUser = new User()
            {
                FirstName = newUserRequest.FirstName,
                LastName = newUserRequest.LastName,
                DisciplineId = newUserRequest.DisciplineId,
                Abbreviation = newUserRequest.Abbreviation,
                IdentityUserId = identityId,
                PositionId = newUserRequest.PositionId
            };
            return await _repository.AddUser(newUser);
            
        }

        public string GeneratePassword()
        {
            Random random = new Random();
            string letters = "0123456789";
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < 6; ++i)
            {
                password.Append(letters.ElementAt(random.Next(0, letters.Length)));
            }
            return password.ToString();
        }
    }
}
