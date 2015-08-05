using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TangOrganizer.Model.Models.Mapping
{
    public class AttivitaMap : EntityTypeConfiguration<Attivita>
    {
        public AttivitaMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Maestri)
                .HasMaxLength(100);

            this.Property(t => t.Luogo)
                .HasMaxLength(300);

            this.Property(t => t.BaseInfo_CreatoDa)
                .HasMaxLength(255);

            this.Property(t => t.BaseInfo_ModificatoDa)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Attivita");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Tipo).HasColumnName("Tipo");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Maestri).HasColumnName("Maestri");
            this.Property(t => t.Descrizione).HasColumnName("Descrizione");
            this.Property(t => t.DataInizio).HasColumnName("DataInizio");
            this.Property(t => t.DataFine).HasColumnName("DataFine");
            this.Property(t => t.Luogo).HasColumnName("Luogo");
            this.Property(t => t.LimiteIscrizioni).HasColumnName("LimiteIscrizioni");
            this.Property(t => t.Cancellato).HasColumnName("Cancellato");
            this.Property(t => t.BaseInfo_DataCreazione).HasColumnName("BaseInfo_DataCreazione");
            this.Property(t => t.BaseInfo_CreatoDa).HasColumnName("BaseInfo_CreatoDa");
            this.Property(t => t.BaseInfo_DataUltimaModifica).HasColumnName("BaseInfo_DataUltimaModifica");
            this.Property(t => t.BaseInfo_ModificatoDa).HasColumnName("BaseInfo_ModificatoDa");
            this.Property(t => t.EventoId).HasColumnName("EventoId");

            // Relationships
            this.HasRequired(t => t.Evento)
                .WithMany(t => t.Attivitas)
                .HasForeignKey(d => d.EventoId);

        }
    }
}
