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
    public class InvoiceItemConfig: IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.HasKey(ii => ii.Id);

            builder.Property(ii => ii.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(ii => ii.Qty)
                   .IsRequired();

            builder.Property(ii => ii.Discount)
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0);

            builder.HasOne(ii => ii.Invoice)
                   .WithMany(i => i.Items)
                   .HasForeignKey(ii => ii.InvoiceId);

            builder.HasOne(ii => ii.Item)
                   .WithMany(i => i.InvoiceItems)
                   .HasForeignKey(ii => ii.ItemId);
        }
    }
}
