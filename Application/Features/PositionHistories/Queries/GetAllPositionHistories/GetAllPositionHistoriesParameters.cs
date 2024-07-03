using Application.Parameters;

namespace Application.Features.PositionHistories.Queries.GetAllPositionHistories
{
    public class GetAllPositionHistoriesParameters : RequestParameter
    {
        public int? EmployeeId { get; set; }
        public string Position { get; set; }
    }
}
