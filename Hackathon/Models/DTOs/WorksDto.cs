using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Models.DTOs
{
    public class WorksDto
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public int StatusId { get; set; }
        public int PinId { get; set; }
        public int DepartmentId { get; set; }
    }
}
