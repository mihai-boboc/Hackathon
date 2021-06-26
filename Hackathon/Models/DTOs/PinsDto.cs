namespace Hackathon.Models.DTOs
{
    public class PinsDto
    {
        public int Id { get; set; }
        public int PinTypeId { get; set; }
        public float GpsCoordX { get; set; }
        public float GpsCoordY { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
