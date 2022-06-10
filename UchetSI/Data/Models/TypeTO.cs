namespace UchetSI.Data.Models
{
    public class TypeTO
    {
        public int Id { get; set; }
        public string NameTO { get; set; }

        public List<ScheduleTO> ScheduleTOs { get; set; }
    }
}
