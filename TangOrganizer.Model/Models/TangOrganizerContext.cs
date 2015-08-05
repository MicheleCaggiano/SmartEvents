using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TangOrganizer.Model.Models.Mapping;

namespace TangOrganizer.Model.Models
{
    public partial class TangOrganizerContext : DbContext
    {
        static TangOrganizerContext()
        {
            Database.SetInitializer<TangOrganizerContext>(null);
        }

        public TangOrganizerContext()
            : base("Name=TangOrganizerContext")
        {
        }

        public DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public DbSet<Attivita> Attivitas { get; set; }
        public DbSet<Evento> Eventoes { get; set; }
        public DbSet<Pacchetto> Pacchettoes { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<TipoAttivita> TipoAttivitas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new C__RefactorLogMap());
            modelBuilder.Configurations.Add(new AttivitaMap());
            modelBuilder.Configurations.Add(new EventoMap());
            modelBuilder.Configurations.Add(new PacchettoMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TipoAttivitaMap());
        }
    }
}
