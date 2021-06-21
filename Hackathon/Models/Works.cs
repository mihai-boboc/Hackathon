using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Models
{
    public class Works
    {
        public int Id { get; set; }
        public Status Status { get; set; }
        public string Details { get; set; }
        public virtual Pins Pin { get; set; }
        public int PinId { get; set; }
        public Departments Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
