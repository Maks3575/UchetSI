namespace UchetSI.Data.Models
{
    public class HoldingTO
    {
        public int Id { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public int? PeriodOfTO { get; set; }
        public int? YearEvent { get; set; }
        public List<ScheduleTO> ScheduleTOs { get; set; }
    }
}
