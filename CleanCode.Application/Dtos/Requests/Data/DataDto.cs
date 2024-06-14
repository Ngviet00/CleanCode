namespace CleanCode.Application.Dtos.Requests.Data
{
    public class DataDTO
    {
        public DateTime? Time { get; set; } = DateTime.UtcNow.AddHours(7);
        public string? Model { get; set; } = string.Empty;
        public int? ClientId { get; set; }
        public int? Index { get; set; }
        public string? TimeLine { get; set; }
    }
}
