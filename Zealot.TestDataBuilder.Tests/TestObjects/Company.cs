namespace Zealot.Tests.TestObjects;

internal class Company
{
    public int CompanyId { get; set; }
    public string Name { get; set; }
    public DateTime FoundAt { get; set; }
    public DateTime? Closed { get; set; }
    public List<Branch> Branches { get; set; } = default!;
    public MainBranch MainBranch { get; set; }
    public Employee Owner { get; set; }
    public IEnumerable<Employee> SubWorkers { get; set; } = default!;
    public List<Employee> MainWorkers { get; set; } = default!;
    public Address MainAddress { get; set; }
}

internal class Branch
{
    public Guid BranchId { get; set; }
}

internal class MainBranch : Branch
{
    public bool HasBuilding { get; set; }
}

internal class Employee
{
    public string Name { get; set; }
    public Company Company { get; set; }
}

internal class Address
{
    public Address(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
