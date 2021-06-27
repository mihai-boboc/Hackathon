using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hackathon.Models
{
    public class Issues
    {
        [Key]
        public int Id { get; set; }
        public string Details { get; set; }
        public string PhotoName { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime Date { get; set; }
        public virtual Pins Pin { get; set; }
        public int PinId { get; set; }
        public virtual Status Status { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }

    }
}
