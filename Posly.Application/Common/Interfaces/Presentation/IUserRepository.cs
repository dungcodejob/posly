using Posly.Domain.Entities;

namespace Posly.Application.Common.Interfaces.Presentation;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void Add(User user);

}