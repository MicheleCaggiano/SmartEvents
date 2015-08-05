using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TangOrganizer.Model.Models.Mapping
{
    public class EventoMap : EntityTypeConfiguration<Evento>
    {
        public EventoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Luogo)
                .IsRequired()
                .HasMaxLength(300);

            this.Property(t => t.BaseInfo_CreatoDa)
                .HasMaxLength(255);

            this.Property(t => t.BaseInfo_ModificatoDa)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Evento");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Descrizione).HasColumnName("Descrizione");
            this.Property(t => t.DataInizio).HasColumnName("DataInizio");
            this.Property(t => t.DataFine).HasColumnName("DataFine");
            this.Property(t => t.Luogo).HasColumnName("Luogo");
            this.Property(t => t.Cancellato).HasColumnName("Cancellato");
            this.Property(t => t.BaseInfo_DataCreazione).HasColumnName("BaseInfo_DataCreazione");
            this.Property(t => t.BaseInfo_CreatoDa).HasColumnName("BaseInfo_CreatoDa");
            this.Property(t => t.BaseInfo_DataUltimaModifica).HasColumnName("BaseInfo_DataUltimaModifica");
            this.Property(t => t.BaseInfo_ModificatoDa).HasColumnName("BaseInfo_ModificatoDa");
        }
    }
}
