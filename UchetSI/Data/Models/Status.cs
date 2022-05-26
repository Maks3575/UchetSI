namespace UchetSI.Data.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string NameStatus { get; set; }

        public List<History> Histories { get; set; }
    }
}
