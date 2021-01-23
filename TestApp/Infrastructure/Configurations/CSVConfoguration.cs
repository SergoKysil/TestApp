using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain.Entities;

namespace TestApp.Infrastructure.Configurations
{
    public class CSVConfoguration : IEntityTypeConfiguration<CSV>
    {

        public void Configure(EntityTypeBuilder<CSV> builder)
        {
            builder.ToTable("CSV");

            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(50);

            builder.Property(p => p.DateofBirth)
                .IsRequired()
                .HasColumnName("date")
                .HasColumnName("datetime");

            builder.Property(p => p.IsMarried)
                .IsRequired()
                .HasColumnName("is_married")
                .HasColumnType("bit");

            builder.Property(p => p.Phone)
                .IsRequired()
                .HasColumnName("phone");

            builder.Property(p => p.Salary)
                .IsRequired()
                .HasColumnName("salary")
                .HasColumnType("decimal");
        }
    }
}
