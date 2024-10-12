using Pacagroup.Ecommerce.Domain.Common;
using Pacagroup.Ecommerce.Domain.Enums;

namespace Pacagroup.Ecommerce.Domain.Entities;

public class Discount : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Percent { get; set; }

    public DiscountStatus  Status { get; set; }
}
