namespace isgasoir
{
    public class Semestre
    {
        long id;
        string name;

        List<Module>? modules;
       

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        
        public List<Module>? Modules { get => modules; set => modules = value; }
    }
}
