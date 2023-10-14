namespace HomeScheduler.Common.Dto;

public class AvailabilityDto
{
    public int AvailabilityId { get; set; }
    public int UserId { get; set; }
    public bool Available { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string UpdatedBy { get; set; } = null!;
    public DateTime UpdatedDate { get; set; }
}
