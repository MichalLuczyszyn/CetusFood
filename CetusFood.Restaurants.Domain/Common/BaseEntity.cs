namespace CetusFood.Restaurants.Domain.Common;

public class BaseEntity
{
    public Guid Id { get; protected set; }
    public bool IsDeleted { get; private set; }

    public void Delete() => IsDeleted = true;
}