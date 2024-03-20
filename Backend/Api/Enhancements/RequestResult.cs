namespace Api.Enhancements;

public class RequestResult<T>
{
    public T Data { get; set; } = default!;
    public string MessageText { get; set; } = default!;
    public string MessageType { get; set; } = default!;
}