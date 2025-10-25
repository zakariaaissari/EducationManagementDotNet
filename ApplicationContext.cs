using Microsoft.EntityFrameworkCore;

namespace isgasoir
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          /*  modelBuilder.Entity<Semestre>()

                .HasMany<Module>(s=>s.Modules)
                .WithOne(m=>m.Sem)
                .HasForeignKey(e=>e.Id);
           */
           
           
            // Configure the relationship between Chapitre and Activity
            modelBuilder.Entity<Activity>()
                .HasOne<Chapitre>(a => a.Chapitre)
                .WithMany(c => c.Activities)
                .HasForeignKey("ChapitreId");

            // Configure the relationship between Chapitre and Module
            modelBuilder.Entity<Chapitre>()
                .HasOne<Module>(c => c.Module)
                .WithMany()
                .HasForeignKey("ModuleId");

        }

        public DbSet<Product> products { get; set; }
        public DbSet<Studant> studants { get; set; }
        public DbSet<Semestre> semestrees { get; set;}
        public DbSet<Module> modules { get; set; }
        public DbSet<Filiere> filieres { get; set; }
        public DbSet<Chapitre> chapitres { get; set; }
        public DbSet<Activity> activities { get; set; }

    }
}
