using Application.Parameters;

namespace Application.Features.Employees.Queries.GetAllEmployees
{
    public class GetAllEmployeesParameters : RequestParameter
    {
        public string Name { get; set; }
        public int CurrentPosition { get; set; }
    }
}
