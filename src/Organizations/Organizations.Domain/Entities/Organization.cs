namespace Organizations.Domain.Entities;

public class Organization
{
    public Guid Id { get; private set; }
    
    public string Name { get; private set; }

    public Organization(string name)
    {
        Name = name;
    }
        
    private Organization() {}
}