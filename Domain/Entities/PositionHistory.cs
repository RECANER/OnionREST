namespace Domain.Entities
{
    public class PositionHistory : AuditableBaseEntity
    {
        public int EmployeeId { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}