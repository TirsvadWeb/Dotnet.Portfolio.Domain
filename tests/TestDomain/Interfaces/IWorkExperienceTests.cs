using TirsvadWeb.Portfolio.Domain.Interfaces;

namespace TestDomain.Interfaces;

[TestClass]
public class IWorkExperienceTests
{
    private class TestWorkExperience : IWorkExperience
    {
        public Guid Id { get; set; }
        public string Company { get; private set; } = string.Empty;
        public string Role { get; private set; } = string.Empty;
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string Responsibilities { get; private set; } = string.Empty;

        public TestWorkExperience(string company, string role, DateTime startDate, DateTime? endDate, string responsibilities)
        {
            Id = Guid.NewGuid();
            Company = company;
            Role = role;
            StartDate = startDate;
            EndDate = endDate;
            Responsibilities = responsibilities;
        }

        public void Update(string role, DateTime? endDate, string responsibilities)
        {
            Role = role;
            EndDate = endDate;
            Responsibilities = responsibilities;
        }
    }

    [TestMethod]
    public void Update_ChangesRoleEndDateAndResponsibilities()
    {
        // Arrange
        var work = new TestWorkExperience("Contoso", "Developer", new DateTime(2021, 1, 1), null, "Initial");
        var newRole = "Lead Developer";
        DateTime? newEndDate = new DateTime(2023, 1, 1);
        var newResponsibilities = "Led the team.";

        // Act
        work.Update(newRole, newEndDate, newResponsibilities);

        // Assert
        Assert.AreEqual(newRole, work.Role);
        Assert.AreEqual(newEndDate, work.EndDate);
        Assert.AreEqual(newResponsibilities, work.Responsibilities);
    }
}