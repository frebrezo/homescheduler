using HomeScheduler.Common.Dto;
using HomeScheduler.Data;
using HomeScheduler.Data.Entity;
using HomeScheduler.Data.Repository;

namespace HomeScheduler.Service.Service;

public class AvailabilityService : IAvailabilityService
{
    private readonly IAvailabilityRepository _repo;

    public AvailabilityService(IAvailabilityRepository repo)
    {
        _repo = repo;
    }

    public List<AvailabilityDto> GetAvailabilities()
    {
        List<AvailabilityDto> result = _repo.GetAvailabilities().Select(Map).ToList();
        return result;
    }

    public AvailabilityDto? GetAvailabilityByUserId(int userId)
    {
        AvailabilityDto? dto = Map(_repo.GetAvailabilityByUserId(userId));
        if (dto == null)
        {
            DateTime dt = DateTime.UtcNow;

            Availability entity = new Availability
            {
                Available = true,
                UserId = userId,
                CreatedBy = "SYSTEM",
                CreatedDate = dt,
                UpdatedBy = "SYSTEM",
                UpdatedDate = dt
            };
            UpdateResponse<Availability> result = _repo.AddAvailability(entity);
            dto = Map(result.Data);
        }
        return dto;
    }

    public UpdateResponseDto<AvailabilityDto> ToggleAvailability(int userId, NoDataRequestDto dto)
    {
        DateTime dt = DateTime.UtcNow;

        UpdateResponse<Availability> result = null;
        Availability? entity = _repo.GetAvailabilityByUserId(userId);
        if (entity != null)
        {
            entity.Available = !entity.Available;
            entity.UpdatedBy = dto.UpdatedBy;
            entity.UpdatedDate = dt;

            result = _repo.UpdateAvailability(entity.AvailabilityId, entity);
        }
        else
        {
            entity = new Availability
            {
                Available = false,
                UserId = userId,
                CreatedBy = dto.UpdatedBy,
                CreatedDate = dt,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = dt
            };

            result = _repo.AddAvailability(entity);
        }

        return new UpdateResponseDto<AvailabilityDto>
        {
            Data = Map(result.Data),
            ChangeCount = result.ChangeCount
        };
    }

    private AvailabilityDto? Map(Availability? entity)
    {
        if (entity == null) return null;

        return new AvailabilityDto
        {
            AvailabilityId = entity.AvailabilityId,
            Available = entity.Available,
            UserId = entity.UserId,
            CreatedBy = entity.CreatedBy,
            CreatedDate = entity.CreatedDate,
            UpdatedBy = entity.UpdatedBy,
            UpdatedDate = entity.UpdatedDate
        };
    }
}
