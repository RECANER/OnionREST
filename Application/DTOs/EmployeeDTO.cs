using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentPosition { get; set; }
        public decimal Salary { get; set; }
        public List<PositionHistoryDTO> PositionHistories { get; set; }
    }

}