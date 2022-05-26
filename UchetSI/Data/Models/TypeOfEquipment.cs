namespace UchetSI.Data.Models
{
    public class TypeOfEquipment
    {
        public int Id { get; set; }
        public string NameTypeOfEquipment { get; set; }

        public int MakerId { get; set; }
        public int DescriptionOfEquipmentId { get; set; }
        public Maker Maker { get; set; }

        public DescriptionOfEquipment DescriptionOfEquipment { get; set; }

        public List<DescriptionMI> DescriptionMIs { get; set; } = new List<DescriptionMI>();

    }
}
