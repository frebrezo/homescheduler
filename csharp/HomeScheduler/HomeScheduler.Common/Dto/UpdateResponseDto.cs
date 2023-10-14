namespace HomeScheduler.Common.Dto
{
    public class UpdateResponseDto<T>
    {
        public T? Data { get; set; } = default(T);
        public int ChangeCount { get; set; } = 0;
    }
}
