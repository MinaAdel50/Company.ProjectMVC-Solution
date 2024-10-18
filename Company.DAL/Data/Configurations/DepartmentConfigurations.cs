using Company.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.DAL.Data.Configurations
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Dpartment>
    {
        public void Configure(EntityTypeBuilder<Dpartment> builder)
        {
            builder.Property(x => x.Id).UseIdentityColumn(10,10);

        }
    }
}
