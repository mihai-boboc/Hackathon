using System;

namespace Hackathon.Models
{
    public class Issues
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string PhotoName { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime Date { get; set; }
        public virtual Pins Pin { get; set; }
        public int PinId { get; set; }
        public virtual Status Status { get; set; }
        public int StatusId { get; set; }

    }
}
