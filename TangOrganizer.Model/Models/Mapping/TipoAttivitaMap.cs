using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TangOrganizer.Model.Models.Mapping
{
    public class TipoAttivitaMap : EntityTypeConfiguration<TipoAttivita>
    {
        public TipoAttivitaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Descrizione)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("TipoAttivita", "Lookup");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Descrizione).HasColumnName("Descrizione");
        }
    }
}
