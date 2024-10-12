namespace Pacagroup.Ecommerce.Domain.Common;

public abstract class BaseEntity : BaseAuditableEntity
{
    public int Id { get; set; }
}
