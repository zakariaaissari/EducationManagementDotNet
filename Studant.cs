namespace isgasoir
{
    public class Studant
    {
        long id;
        string nom, prenom;
        DateTime date;
        string gender;

        List<Module> modules;

        public long Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime Date { get => date; set => date = value; }
        public string Gender { get => gender; set => gender = value; }
        public List<Module> Modules { get => modules; set => modules = value; }
    }
}
