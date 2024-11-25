using System.ComponentModel;

namespace Occurrens.Domain.Entities;

public class BaseEntity
{
    public DateTime CreateDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime LastUpdate { get; set; }
    public Guid LastUpdateBy { get; set; }
    
    
    [Description("Set BaseEntity")]
    public void SetBaseEntity(Guid userId)
    {
        if (CreatedBy == null)
        {
            CreatedBy = userId;
            LastUpdateBy = userId;
            CreateDate = DateTime.Now;
            LastUpdate = DateTime.Now;
        }
        else
        {
            LastUpdateBy = userId;
            LastUpdate = DateTime.Now;
        }
    }
}