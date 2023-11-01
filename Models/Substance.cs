namespace ChemistryApiTask.Models
{
    public enum SubstanceType
    {
        None,
        Acid,
        Meadow,
        Main,
        Organic,
        Metal,
        Powder,
        Oxyde,
        Alcohol
    }
    public class Substance 
    {
        public  int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public SubstanceType Type { get; set; } = SubstanceType.None;

        public Substance(int _id, string _name, SubstanceType _type)
        {
            Id = _id;
            Name = _name;
            Type = _type;
        }
        public Substance()
        {
            
        }

    }
}
