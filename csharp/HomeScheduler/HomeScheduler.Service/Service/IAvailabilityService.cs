using HomeScheduler.Common.Dto;

namespace HomeScheduler.Service.Service;

public interface IAvailabilityService
{
    List<AvailabilityDto> GetAvailabilities();
    AvailabilityDto? GetAvailabilityByUserId(int userId);
    UpdateResponseDto<AvailabilityDto> ToggleAvailability(int userId, NoDataRequestDto dto);
}
