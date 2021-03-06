﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

using BolfTracker.Models;

namespace BolfTracker.Infrastructure.EntityFramework
{
    public class ShotTypeConfiguration : EntityTypeConfiguration<ShotType>
    {
        public ShotTypeConfiguration()
        {
            HasKey(st => st.Id);

            Property(st => st.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(st => st.Name).IsRequired().IsVariableLength().HasMaxLength(50);
            Property(st => st.Description).IsRequired().IsVariableLength().HasMaxLength(100);

            ToTable("ShotType");
        }
    }
}
