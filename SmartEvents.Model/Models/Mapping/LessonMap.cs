using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartEvents.Model.Models.Mapping
{
    public class LessonMap : EntityTypeConfiguration<Lesson>
    {
        public LessonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.AuthInfo_CreatedBy)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.AuthInfo_ModifiedBy)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Lesson");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AuthInfo_Created).HasColumnName("AuthInfo_Created");
            this.Property(t => t.AuthInfo_CreatedBy).HasColumnName("AuthInfo_CreatedBy");
            this.Property(t => t.AuthInfo_Modified).HasColumnName("AuthInfo_Modified");
            this.Property(t => t.AuthInfo_ModifiedBy).HasColumnName("AuthInfo_ModifiedBy");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
            this.Property(t => t.EventId).HasColumnName("EventId");

            // Relationships
            this.HasRequired(t => t.Event)
                .WithMany(t => t.Lessons)
                .HasForeignKey(d => d.EventId);

        }
    }
}
