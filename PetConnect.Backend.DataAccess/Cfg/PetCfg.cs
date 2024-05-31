using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

using PetConnect.Backend.Core;

namespace PetConnect.Backend.DataAccess.Cfg;

internal class PetCfg : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.HasKey(p => p.Id);
    }
}
