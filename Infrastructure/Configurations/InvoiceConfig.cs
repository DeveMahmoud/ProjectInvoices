using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.CreatedDate)
                   .IsRequired();

            builder.HasOne(i => i.Store)
                   .WithMany(s => s.Invoices)
                   .HasForeignKey(i => i.StoreId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.Items)
                   .WithOne(ii => ii.Invoice)
                   .HasForeignKey(ii => ii.InvoiceId);
        }
    }
}
