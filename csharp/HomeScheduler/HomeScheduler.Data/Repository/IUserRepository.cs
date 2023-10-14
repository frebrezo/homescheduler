using HomeScheduler.Common.Dto;
using HomeScheduler.Data.Entity;

namespace HomeScheduler.Data.Repository;

public interface IUserRepository
{
    List<User> GetUsers();
    User? GetUser(int id);
    UpdateResponse<User> AddUser(User entity);
    UpdateResponse<User> UpdateUser(int id, User entity);
}
