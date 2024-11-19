namespace Occurrens.Domain.Entities;

public class BaseEntity
{
    public DateTime CreateDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public Guid LastUpdateBy { get; set; }
}