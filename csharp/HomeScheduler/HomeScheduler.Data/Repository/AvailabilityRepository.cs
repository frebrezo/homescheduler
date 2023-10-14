using HomeScheduler.Data.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;

namespace HomeScheduler.Data.Repository;

public class AvailabilityRepository : IAvailabilityRepository
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public AvailabilityRepository(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public List<Availability> GetAvailabilities()
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        using HomeSchedulerContext context = scope.ServiceProvider.GetRequiredService<HomeSchedulerContext>();

        return context.Availabilities.ToList();
    }

    public Availability? GetAvailability(int id)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        using HomeSchedulerContext context = scope.ServiceProvider.GetRequiredService<HomeSchedulerContext>();

        return context.Availabilities.FirstOrDefault(x => x.AvailabilityId == id);
    }

    public Availability? GetAvailabilityByUserId(int userId)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        using HomeSchedulerContext context = scope.ServiceProvider.GetRequiredService<HomeSchedulerContext>();

        return context.Availabilities.FirstOrDefault(x => x.UserId == userId);
    }

    public UpdateResponse<Availability> AddAvailability(Availability entity)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        using HomeSchedulerContext context = scope.ServiceProvider.GetRequiredService<HomeSchedulerContext>();

        EntityEntry<Availability> entityEntry = context.Availabilities.Add(entity);
        int changeCount = context.SaveChanges();

        return new UpdateResponse<Availability>
        {
            Data = entityEntry.Entity,
            ChangeCount = changeCount
        };
    }

    public UpdateResponse<Availability> UpdateAvailability(int id, Availability entity)
    {
        using IServiceScope scope = _serviceScopeFactory.CreateScope();
        using HomeSchedulerContext context = scope.ServiceProvider.GetRequiredService<HomeSchedulerContext>();

        Availability? existingEntity = context.Availabilities.FirstOrDefault(x => x.AvailabilityId == id);

        if (existingEntity == null)
        {
            return new UpdateResponse<Availability>();
        }

        if (existingEntity.Available == entity.Available)
        {
            return new UpdateResponse<Availability>
            {
                Data = existingEntity,
                ChangeCount = 0
            };
        }

        existingEntity.Available = entity.Available;
        existingEntity.UpdatedBy = entity.UpdatedBy;
        existingEntity.UpdatedDate = DateTime.UtcNow;

        EntityEntry<Availability> entry = context.Availabilities.Update(existingEntity);
        int changeCount = context.SaveChanges();

        return new UpdateResponse<Availability>
        {
            Data = entry.Entity,
            ChangeCount = changeCount
        };
    }
}
