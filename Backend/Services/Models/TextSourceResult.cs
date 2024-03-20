namespace Services.Models
{
    [Serializable]
    public class TextSourceResult
    {
        public int Id { get; set; }
        public string TextData { get; set; } = default!;
    }
}