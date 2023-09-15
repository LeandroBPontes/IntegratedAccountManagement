using System.ComponentModel;

namespace IntegratedAccountManagement.Domain.Enums;
public enum EAccountType
{
    [Description("Crédito")]
    Credit,

    [Description("Débito")]
    Debt
}