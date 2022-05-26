namespace UchetSI.Data.Models
{
    public class History
    {
        public int Id { get; set; }

        public int PositionId { get; set; }
        public int StatusId { get; set; }
        public int MeashuringToolId { get; set; }
        public DateTime DateTimeChange { get; set; }

        public Position Position { get; set; }

        public Status Status { get; set; }

        public MeashuringTool MeashuringTool { get; set; }

    }
}
