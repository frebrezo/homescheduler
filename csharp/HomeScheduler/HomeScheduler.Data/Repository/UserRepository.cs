using HomeScheduler.Data.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;

namespace HomeScheduler.Data.Repository;

public class UserRepository : IUserRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public UserRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public List<User> GetUsers()
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        using HomeSchedulerContext context = scope.ServiceProvider.GetRequiredService<HomeSchedulerContext>();

        return context.Users.ToList();
    }

    public User? GetUser(int id)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        using HomeSchedulerContext context = scope.ServiceProvider.GetRequiredService<HomeSchedulerContext>();
   
        return context.Users.FirstOrDefault(x => x.UserId == id);
    }

    public UpdateResponse<User> AddUser(User entity)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        using HomeSchedulerContext context = scope.ServiceProvider.GetRequiredService<HomeSchedulerContext>();

        EntityEntry<User> entry = context.Users.Add(entity);
        int changeCount = context.SaveChanges();

        return new UpdateResponse<User>
        {
            Data = entry.Entity,
            ChangeCount = changeCount
        };
    }

    public UpdateResponse<User> UpdateUser(int id, User entity)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        using HomeSchedulerContext context = scope.ServiceProvider.GetRequiredService<HomeSchedulerContext>();

        User? existingEntity = context.Users.FirstOrDefault(x => x.UserId == id);

        if (existingEntity == null)
        {
            return new UpdateResponse<User>();
        }

        existingEntity.UserName = entity.UserName;
        existingEntity.FirstName = entity.FirstName;
        existingEntity.LastName = entity.LastName;
        existingEntity.UpdatedBy = entity.UpdatedBy;
        existingEntity.UpdatedDate = entity.UpdatedDate;

        EntityEntry<User> entry = context.Users.Update(existingEntity);
        int changeCount = context.SaveChanges();

        return new UpdateResponse<User>
        {
            Data = entry.Entity,
            ChangeCount = changeCount
        };
    }
}
