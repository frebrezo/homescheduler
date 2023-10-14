namespace HomeScheduler.Common.Dto;

public class RequestDto<T>
{
    public T Data { get; set; }
    public string UpdatedBy { get; set; }
}
