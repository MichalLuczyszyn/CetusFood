namespace CetusFood.Restaurants.Domain.Common;

public class ArchivableEntity : BaseEntity
{
    public bool IsArchived { get; private set; }

    public void Archive() => IsArchived = true;
}