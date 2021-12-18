using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Infra.EF.Configuration
{
    public class TransactionConfig : IEntityTypeConfiguration<TransactionConfig>
    {
        public void Configure(EntityTypeBuilder<TransactionConfig> builder)
        {
            
        }
    }
}
