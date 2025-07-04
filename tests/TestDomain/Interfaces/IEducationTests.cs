using TirsvadWeb.Portfolio.Domain.Interfaces;

namespace TestDomain.Interfaces;

[TestClass]
public class IEducationTests
{
    private class TestEducation : IEducation
    {
        public Guid Id { get; set; }
        public string Institution { get; private set; } = string.Empty;
        public string Degree { get; private set; } = string.Empty;
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; private set; }
        public string Description { get; private set; } = string.Empty;

        public TestEducation(string institution, string degree, DateTime startDate, DateTime? endDate, string description)
        {
            Id = Guid.NewGuid();
            Institution = institution;
            Degree = degree;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
        }

        public void Update(string degree, DateTime? endDate, string description)
        {
            Degree = degree;
            EndDate = endDate;
            Description = description;
        }
    }

    [TestMethod]
    public void Update_ChangesDegreeEndDateAndDescription()
    {
        // Arrange
        var edu = new TestEducation("Uni", "BSc", new DateTime(2020, 1, 1), null, "desc");
        var newDegree = "MSc";
        var newEndDate = new DateTime(2022, 6, 1);
        var newDescription = "updated desc";

        // Act
        edu.Update(newDegree, newEndDate, newDescription);

        // Assert
        Assert.AreEqual(newDegree, edu.Degree);
        Assert.AreEqual(newEndDate, edu.EndDate);
        Assert.AreEqual(newDescription, edu.Description);
    }
}