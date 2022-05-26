namespace UchetSI.Data.Models
{
    public class Maker
    {
        public int Id { get; set; }
       
        public string NameMaker { get; set; }

        public List<TypeOfEquipment> TypeOfEquipment { get; set; } = new List<TypeOfEquipment>();
    }
}
