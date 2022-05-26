namespace UchetSI.Data.Models
{
    public class TypeLocation
    {

        public int Id { get; set; }
        public string NameTypelocation { get; set; }

        public List<Location> Locations { get; set; } = new List<Location>();
    }
}
