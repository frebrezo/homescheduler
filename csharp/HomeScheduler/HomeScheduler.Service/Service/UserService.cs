using HomeScheduler.Common.Dto;
using HomeScheduler.Data;
using HomeScheduler.Data.Entity;
using HomeScheduler.Data.Repository;

namespace HomeScheduler.Service.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _repo;

    public UserService(IUserRepository repo)
    {
        _repo = repo;
    }

    public List<UserDto> GetUsers()
    {
        List<UserDto> result = _repo.GetUsers().Select(Map).ToList();
        return result;
    }

    public UserDto? GetUser(int id)
    {
        UserDto? result = Map(_repo.GetUser(id));
        return result;
    }

    public UpdateResponseDto<UserDto> AddUser(RequestDto<UserRequestDto> dto)
    {
        User entity = Map(dto);
        UpdateResponse<User> result = _repo.AddUser(entity);
        return new UpdateResponseDto<UserDto>
        {
            Data = Map(result.Data),
            ChangeCount = result.ChangeCount
        };
    }

    public UpdateResponseDto<UserDto> UpdateUser(int id, RequestDto<UserRequestDto> dto)
    {
        User entity = Map(dto);
        UpdateResponse<User> result = _repo.UpdateUser(id, entity);
        return new UpdateResponseDto<UserDto>
        {
            Data = Map(result.Data),
            ChangeCount = result.ChangeCount
        };
    }

    private User Map(RequestDto<UserRequestDto> dto)
    {
        DateTime dt = DateTime.UtcNow;

        return new User
        {
            UserName = dto.Data.UserName,
            FirstName = dto.Data.FirstName,
            LastName = dto.Data.LastName,
            CreatedBy = dto.UpdatedBy,
            CreatedDate = dt,
            UpdatedBy = dto.UpdatedBy,
            UpdatedDate = dt
        };
    }

    private UserDto? Map(User? entity)
    {
        if (entity == null) return null;

        return new UserDto
        {
            UserId = entity.UserId,
            UserName = entity.UserName,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            CreatedBy = entity.CreatedBy,
            CreatedDate = entity.CreatedDate,
            UpdatedBy = entity.UpdatedBy,
            UpdatedDate = entity.UpdatedDate
        };
    }
}
