namespace UchetSI.Data.Models
{
    public class OutputSignal
    {
        public int Id { get; set; }

        public string NameOutputSignal { get; set; }

        public List<DescriptionMI> DescriptionsMI { get; set; } = new List<DescriptionMI>();
    }
}
