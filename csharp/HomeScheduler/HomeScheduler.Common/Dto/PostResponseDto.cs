namespace HomeScheduler.Common.Dto
{
    public class PostResponseDto<T>
    {
        public T Data { get; set; }
        public int ChangeCount { get; set; }
    }
}
