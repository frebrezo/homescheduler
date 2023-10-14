namespace HomeScheduler.Common.Dto;

public class GetResponseDto<T>
{
    public GetResponseDto() { }

    public GetResponseDto(List<T> data, int? pageSize = null)
    {
        Data = data;
        Count = data.Count;
        PageSize = pageSize ?? data.Count;
    }

    public List<T> Data { get; set; } = null!;
    public int Count { get; set; } = 0;
    public int PageSize { get; set; }
}
