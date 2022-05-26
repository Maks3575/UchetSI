namespace UchetSI.Data.Models
{
    public class VerificationInterval
    {
        public int Id { get; set; }

        public int Interval { get; set; }

        public List<DescriptionMI> DescriptionsMI { get; set; } = new List<DescriptionMI>();
    }
}
