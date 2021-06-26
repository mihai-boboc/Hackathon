using System;

namespace Hackathon.Models.DTOs
{
    public class IssuesDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public byte[] Photo { get; set; }
        public int PinId { get; set; }
        public int StatusId { get; set; }
        public DateTime Date { get; set; }
    }
}
