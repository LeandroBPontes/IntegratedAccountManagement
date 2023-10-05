using IntegratedAccountManagement.Domain.BaseContracts;
using IntegratedAccountManagement.Domain.Enums;

namespace IntegratedAccountManagement.Domain.Entities;

public class Account : IAggregateRoot<Guid>
{
    private Account(){}
    
    public Guid Id { get; private set; }
    
    public EAccountType Type { get; private set; }
    
    public decimal Amount { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public string Teste { get; private set; }
    
    public bool Equals(IEntity<Guid>? other)
    {
        return other is Account account &&
               Id == account.Id;
    }
}