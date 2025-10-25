using System.Text.Json.Serialization;

namespace isgasoir
{
    public class Module
    {
        long id;
        string name = string.Empty;
        double coiff;
        long semId;

        [JsonIgnore]
        Semestre sem = new Semestre();

        List<Studant>? studants = new List<Studant>();

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Coiff { get => coiff; set => coiff = value; }
        public long SemId { get => semId; set => semId = value; }
        [JsonIgnore]
        public Semestre Sem { get => sem; set => sem = value; }
        public List<Studant>? Studants { get => studants; set => studants = value; }
    }
}
