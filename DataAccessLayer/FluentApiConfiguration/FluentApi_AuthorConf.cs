using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.FluentApiConfiguration
{
    public class FluentApi_AuthorConf : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AuthorName).IsRequired();
            builder.Property(x => x.AuthorMail).IsRequired();
            builder.Property(x => x.AuthorPassword).IsRequired();
        }
    }
}
