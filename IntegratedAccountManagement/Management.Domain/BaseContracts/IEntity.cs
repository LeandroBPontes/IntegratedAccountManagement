namespace IntegratedAccountManagement.Domain.BaseContracts;

public interface IEntity<TId> : IEquatable<IEntity<TId>>
{
    TId Id { get; }
}