using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetConnect.Backend.Core.Abstractions;
using PetConnect.Backend.Core.Users;

namespace PetConnect.Backend.DataAccess.Cfg;

/// <summary>
/// Конфигурация таблицы с пользователями.
/// </summary>
internal class UserCfg : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        //builder.HasAlternateKey(u => u.Login);
        //builder.HasAlternateKey(u => u.Email);

        builder.HasDiscriminator(u => u.Role)
              .HasValue<PetSitter>(Role.PetSitter)
              .HasValue<PetOwner>(Role.PetOwner)
              .HasValue<Admin>(Role.Admin);

    }
}
    