namespace CetusFood.Restaurants.Domain.Common;

public class BaseEntity
{
    public bool IsDeleted { get; private set; }

    public void Delete() => IsDeleted = true;
}