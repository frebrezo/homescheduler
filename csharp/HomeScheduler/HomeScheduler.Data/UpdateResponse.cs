namespace HomeScheduler.Data;

public class UpdateResponse<T>
{
    public T? Data { get; set; } = default(T);
    public int ChangeCount { get; set; }
}
