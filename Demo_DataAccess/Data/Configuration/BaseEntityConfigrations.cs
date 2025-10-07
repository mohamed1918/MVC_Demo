using Demo_DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DataAccess.Data.Configuration
{
    internal class BaseEntityConfigrations<TEntity> : IBaseEntityConfigration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(D => D.CreatedOn).HasDefaultValueSql("getdate()");
            builder.Property(D => D.LastModifiedOn).HasComputedColumnSql("getdate()");
        }
    }

    internal interface IBaseEntityConfigration<TEntity>
    {
    }
}
