namespace UchetSI.Data.Models
{
    public class ScheduleTO
    {
        public int Id { get; set; }
        public int? NumberMonth { get; set; }
        public int? PlanDataTOFrom { get; set; }
        public int? PlanDateTOTo { get; set; }
        public int? FactDateTOFrom { get; set; }
        public int? FactDateTOTo { get; set; }
        public int TypeTOId { get; set; }
        public TypeTO TypeTO { get; set; }
        public int HoldingTOId { get; set; }
        public HoldingTO HoldingTO { get; set; }
    }
}
