namespace Hackathon.Models
{
    public class Issues
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public string PhotoName { get; set; }
        public string OwnerEmail { get; set; }
        public virtual Pins Pin { get; set; }
        public int PinId { get; set; }

    }
}
