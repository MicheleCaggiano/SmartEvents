using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace TangOrganizer.Model.Models.Mapping
{
    public class PacchettoMap : EntityTypeConfiguration<Pacchetto>
    {
        public PacchettoMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Nome)
                .IsRequired()
                .HasMaxLength(200);

            this.Property(t => t.BaseInfo_CreatoDa)
                .HasMaxLength(255);

            this.Property(t => t.BaseInfo_ModificatoDa)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("Pacchetto");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Descrizione).HasColumnName("Descrizione");
            this.Property(t => t.Prezzo).HasColumnName("Prezzo");
            this.Property(t => t.BaseInfo_DataCreazione).HasColumnName("BaseInfo_DataCreazione");
            this.Property(t => t.BaseInfo_CreatoDa).HasColumnName("BaseInfo_CreatoDa");
            this.Property(t => t.BaseInfo_DataUltimaModifica).HasColumnName("BaseInfo_DataUltimaModifica");
            this.Property(t => t.BaseInfo_ModificatoDa).HasColumnName("BaseInfo_ModificatoDa");
            this.Property(t => t.EventoId).HasColumnName("EventoId");

            // Relationships
            this.HasRequired(t => t.Evento)
                .WithMany(t => t.Pacchettoes)
                .HasForeignKey(d => d.EventoId);

        }
    }
}
