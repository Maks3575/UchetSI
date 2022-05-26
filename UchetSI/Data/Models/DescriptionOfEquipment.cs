namespace UchetSI.Data.Models
{
    public class DescriptionOfEquipment
    {
        public int Id { get; set; }
        public string NameDescription { get; set; }

        public List<TypeOfEquipment> TypeOfEquipment { get; set; } = new List<TypeOfEquipment>();
    }
}
