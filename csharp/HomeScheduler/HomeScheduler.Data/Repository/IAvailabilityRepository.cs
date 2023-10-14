using HomeScheduler.Data.Entity;

namespace HomeScheduler.Data.Repository;

public interface IAvailabilityRepository
{
    List<Availability> GetAvailabilities();
    Availability? GetAvailability(int id);
    Availability? GetAvailabilityByUserId(int userId);
    UpdateResponse<Availability> AddAvailability(Availability entity);
    UpdateResponse<Availability> UpdateAvailability(int id, Availability entity);
}
