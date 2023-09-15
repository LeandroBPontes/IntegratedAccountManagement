using IntegratedAccountManagement.Domain.Entities;
using IntegratedAccountManagement.Persistence.PostgresExtensionsMaps;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntegratedAccountManagement.Persistence.Maps;

internal class AccountMap : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");

        builder.HasKey(x => x.Id);

        builder.MapUuid(x => x.Id, "id");

        builder.MapEnumAsVarchar(x => x.Type, "account_type",10, true);
        
        builder.MapNumeric(p => p.Amount, 18, 2, "account_amount");

        builder.MapTimestamp(x => x.CreatedAt, "created_at");
    }
}