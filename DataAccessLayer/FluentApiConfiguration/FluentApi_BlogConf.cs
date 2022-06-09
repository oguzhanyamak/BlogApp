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
    public class FluentApi_BlogConf : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(x => x.BlogID);
            builder.Property(x => x.BlogTitle).IsRequired();
            builder.Property(x => x.BlogContent).IsRequired();
        }
    }
}
