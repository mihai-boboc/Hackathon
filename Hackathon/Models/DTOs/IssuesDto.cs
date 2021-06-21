namespace Hackathon.Models.DTOs
{
    public class IssuesDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public byte[] Photo { get; set; }
        public int PinId { get; set; }
    }
}
