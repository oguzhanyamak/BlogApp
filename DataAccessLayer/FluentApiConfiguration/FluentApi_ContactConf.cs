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
    public class FluentApi_ContactConf : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(x => x.ContactID);
            //builder.Property(x => x.ContactUserName).IsRequired();
            builder.Property(x => x.ContactMail).IsRequired();
            builder.Property(x => x.ContactMessage).IsRequired();
        }
    }
}
