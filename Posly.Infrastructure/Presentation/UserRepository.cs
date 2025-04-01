



using Posly.Application.Common.Interfaces.Presentation;
using Posly.Domain.Entities;

namespace Posly.Infrastructure.Presentation;



public class UserRepository : IUserRepository
{
    private readonly List<User> _users = [];
    public void Add(User user)
    {
       _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
       return _users.FirstOrDefault(user => user.Email == email);
    }
}