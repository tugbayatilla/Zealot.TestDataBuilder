using Zealot.Tests.TestObjects;

namespace Zealot.Tests;

public class CompanyTests
{
    [Fact]
    public void Should_create_a_company_using_override_to_reference_itself_to_a_property()
    {
        var now = DateTime.Now;
        var company = TestDataBuilder
            .For<Company>()
            .WithDate(now)
            .WithOverride(p=>p.Owner.Company = p)
            .WithRecursionLevel(1)
            .Build();

        company.Should().NotBeNull();

        // Company
        company.CompanyId.Should().Be(1);
        company.Name.Should().MatchRegex($"{nameof(company.Name)}_[0-9]");
        company.FoundAt.Should().Be(now);
        company.Closed.Should().Be(now);
        
        // Branches
        company.Branches.Should().NotBeNull();
        company.Branches.Count.Should().Be(2);
        company.Branches[0].BranchId.Should().NotBeEmpty();
        company.Branches[1].BranchId.Should().NotBeEmpty();
        
        // Main Branch
        company.MainBranch.Should().NotBeNull();
        company.MainBranch.BranchId.Should().NotBeEmpty();
        company.MainBranch.HasBuilding.Should().BeTrue();
        
        // Owner
        company.Owner.Should().NotBeNull();
        company.Owner.Company.Should().NotBeNull();
        company.Owner.Company.Should().BeSameAs(company); 
        
        // Sub Workers
        company.SubWorkers.Should().NotBeNull();
        company.SubWorkers.Count().Should().Be(2);
        company.SubWorkers.First().Company.Should().NotBeSameAs(company);
        company.SubWorkers.Last().Company.Should().NotBeSameAs(company);
        company.SubWorkers.First().Name.Should().MatchRegex("Name_[0-9]");
        company.SubWorkers.Last().Name.Should().MatchBuilderNamingRegex("Name");
        
        // Main Address
        company.MainAddress.Should().NotBeNull();
        company.MainAddress.Name.Should().MatchRegex("Name_[0-9]");
        
        // Main Workers
        company.MainWorkers.Should().NotBeNull();
        company.MainWorkers.Count.Should().Be(2);
    }
}
