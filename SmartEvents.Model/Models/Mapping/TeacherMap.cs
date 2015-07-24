using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SmartEvents.Model.Models.Mapping
{
    public class TeacherMap : EntityTypeConfiguration<Teacher>
    {
        public TeacherMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .HasMaxLength(255);

            this.Property(t => t.LastName)
                .HasMaxLength(255);

            this.Property(t => t.Email)
                .HasMaxLength(255);

            this.Property(t => t.AuthInfo_CreatedBy)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.AuthInfo_ModifiedBy)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Teacher");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.FullName).HasColumnName("FullName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.AuthInfo_Created).HasColumnName("AuthInfo_Created");
            this.Property(t => t.AuthInfo_CreatedBy).HasColumnName("AuthInfo_CreatedBy");
            this.Property(t => t.AuthInfo_Modified).HasColumnName("AuthInfo_Modified");
            this.Property(t => t.AuthInfo_ModifiedBy).HasColumnName("AuthInfo_ModifiedBy");
            this.Property(t => t.IsDeleted).HasColumnName("IsDeleted");
        }
    }
}
