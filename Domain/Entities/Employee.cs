namespace Domain.Entities
{
    public class Employee : AuditableBaseEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentPosition { get; set; }
        public decimal Salary { get; set; }

        public decimal CalculateYearlyBonus()
        {
            var bonus = 0.1m; // 10% bonus for regular employees, will need adjustment for managers
            return Salary * bonus;
        }
    }
}
