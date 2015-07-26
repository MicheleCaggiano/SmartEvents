using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using SmartEvents.Model.Models.Mapping;

namespace SmartEvents.Model.Models
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

        public DbSet<Evento> Eventoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventoMap());
        }
    }
}
