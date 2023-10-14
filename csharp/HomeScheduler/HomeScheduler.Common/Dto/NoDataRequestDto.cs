namespace HomeScheduler.Common.Dto;

public class NoDataRequestDto
{
    public NoDataRequestDto() {}

    public NoDataRequestDto(string updatedBy)
    {
        UpdatedBy = updatedBy;
    }

    public string UpdatedBy { get; set; } = null!;
}
