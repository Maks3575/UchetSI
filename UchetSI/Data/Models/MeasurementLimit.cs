namespace UchetSI.Data.Models
{
    public class MeasurementLimit
    {
        public int Id { get; set; }

        public float LowerLimit { get; set; }
        public float UpperLimit { get; set; }

        public List<DescriptionMI> DescriptionsMIs { get; set; } = new List<DescriptionMI>();
    }
}
