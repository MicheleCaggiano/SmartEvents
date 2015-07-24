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

        public DbSet<Event> Events { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new LessonMap());
            modelBuilder.Configurations.Add(new TeacherMap());
        }
    }
}
