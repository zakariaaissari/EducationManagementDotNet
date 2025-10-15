namespace isgasoir.Services
{
    public interface IService
    {
        public Module addModule(Module module);
        public Module updateModule(long id, Module module);
        public bool deleteModule(long id);
        public Module getModuleById(long id);
        public List<Module> getAllModules();
        public List<Module> getModuleByName(string name);
        public Semestre addSemestre(Semestre semestre);
        public Filiere addFiliere(Filiere filiere);
        public List<Filiere> getAllFilieres();
        public Filiere getFiliereById(long id);

    }
}
