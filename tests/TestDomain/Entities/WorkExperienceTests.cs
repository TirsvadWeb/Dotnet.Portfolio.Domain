using TirsvadWeb.Portfolio.Domain.Entities;

namespace TestDomain.Entities;

[TestClass]
public class WorkExperienceTests
{
    [TestMethod]
    public void Constructor_SetsAllProperties()
    {
        // Arrange
        var company = "Contoso";
        var role = "Developer";
        var startDate = new DateTime(2021, 1, 1);
        DateTime? endDate = new DateTime(2022, 1, 1);
        var responsibilities = "Developed software.";

        // Act
        var work = new WorkExperience(company, role, startDate, endDate, responsibilities);

        // Assert
        Assert.AreEqual(company, work.Company);
        Assert.AreEqual(role, work.Role);
        Assert.AreEqual(startDate, work.StartDate);
        Assert.AreEqual(endDate, work.EndDate);
        Assert.AreEqual(responsibilities, work.Responsibilities);
    }

    [TestMethod]
    public void Update_ChangesRoleEndDateAndResponsibilities()
    {
        // Arrange
        var work = new WorkExperience("Contoso", "Developer", new DateTime(2021, 1, 1), null, "Initial");
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