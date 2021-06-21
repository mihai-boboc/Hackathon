using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Models
{
    public class Pins
    {
        public int Id { get; set; }
        public virtual PinTypes PinType { get; set; }
        public int PinTypeId { get; set; }
        public float GpsCoordX { get; set; }
        public float GpsCoordY { get; set; }
        public string Description { get; set; }

        public virtual List<Issues> Issues { get; set; }
        public virtual List<Works> Works { get; set; }
    }
}
