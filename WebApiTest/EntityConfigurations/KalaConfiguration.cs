using System.Data.Entity.ModelConfiguration;
using WebApiTest.Models;

namespace WebApiTest.EntityConfigurations
{
    public class KalaConfiguration : EntityTypeConfiguration<Kala>
    {
        public KalaConfiguration()
        {
            HasKey(k => k.Id);

            Property(k => k.Name)
                .IsRequired()
                .HasMaxLength(255);

            Property(k => k.Model)
                .HasMaxLength(255);

            Property(k => k.Color)
                .HasMaxLength(20);
        }
    }
}