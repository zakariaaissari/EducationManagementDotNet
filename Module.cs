using System.Text.Json.Serialization;

namespace isgasoir
{
    public class Module
    {
        long id;
        string name;
        double coiff;

        [JsonIgnore]
        Semestre sem;

        List<Studant>? studants;

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Coiff { get => coiff; set => coiff = value; }
        [JsonIgnore]
        public Semestre Sem { get => sem; set => sem = value; }
        public List<Studant>? Studants { get => studants; set => studants = value; }
    }
}
