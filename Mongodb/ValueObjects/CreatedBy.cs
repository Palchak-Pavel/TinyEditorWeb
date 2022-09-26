using News.API.Common;

namespace News.API.Mongodb.ValueObjects;

public class CreatedBy : ValueObject
{
    public CreatedBy(string userName, string role)
    {
        UserName = userName;
        Role = role;
    }
    
    public string UserName { get; private set; }
    public string Role { get; private set; }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return UserName;
        yield return Role;
    }
}