using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IAccountManagement
    {
        Task<int> RegisterUserAsync(User user);
        Task<User> SignInAsync(string userName, string password);
        string BuildToken(User user);
    }
}
