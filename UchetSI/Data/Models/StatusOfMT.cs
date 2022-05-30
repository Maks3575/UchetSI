namespace UchetSI.Data.Models
{
    public class StatusOfMT
    {
        public int Id { get; set; }

        public string NameStatus { get; set; }

        public List<MeashuringTool> MeashuringTools { get; set; }
    }
}
