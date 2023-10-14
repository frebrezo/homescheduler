using HomeScheduler.Common.Dto;

namespace HomeScheduler.Service.Service
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
        UserDto? GetUser(int id);
        UpdateResponseDto<UserDto> AddUser(RequestDto<UserRequestDto> dto);
        UpdateResponseDto<UserDto> UpdateUser(int id, RequestDto<UserRequestDto> dto);
    }
}
