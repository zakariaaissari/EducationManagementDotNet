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
           


                
                
                
                


        }

        DbSet<Product> products { get; set; }
        DbSet<Studant> studants { get; set; }
        DbSet<Semestre> semestrees { get; set;}
        DbSet<Module> modules { get; set; }
        DbSet<Filiere> filieres { get; set; }
        DbSet<Chapitre> chapitres { get; set; }

    }
}
