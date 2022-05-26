namespace UchetSI.Data.Models
{
    public class UnitOfMeasurement
    {
        public int Id { get; set; }
        public string UnitName { get; set; }
        public List<DescriptionMI> DescriptionsMI { get; set; } = new List<DescriptionMI>();
    }
}
