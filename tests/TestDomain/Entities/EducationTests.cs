using TirsvadWeb.Portfolio.Domain.Entities;

namespace TestDomain.Entities;

[TestClass]
public class EducationTests
{
    [TestMethod]
    public void Constructor_SetsAllProperties()
    {
        // Arrange
        var institution = "Test University";
        var degree = "BSc";
        var startDate = new DateTime(2020, 1, 1);
        DateTime? endDate = new DateTime(2023, 1, 1);
        var description = "Computer Science";

        // Act
        var edu = new Education(institution, degree, startDate, endDate, description);

        // Assert
        Assert.AreEqual(institution, edu.Institution);
        Assert.AreEqual(degree, edu.Degree);
        Assert.AreEqual(startDate, edu.StartDate);
        Assert.AreEqual(endDate, edu.EndDate);
        Assert.AreEqual(description, edu.Description);
    }

    [TestMethod]
    public void Constructor_ThrowsIfInstitutionIsNullOrEmpty()
    {
        // Act & Assert
        var ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = new Education("", "BSc", DateTime.UtcNow, null, "desc");
        });
    }

    [TestMethod]
    public void Constructor_ThrowsIfDegreeIsNullOrEmpty()
    {
        // Act & Assert
        var ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            _ = new Education("Test University", "", DateTime.UtcNow, null, "desc");
        });
    }

    [TestMethod]
    public void Constructor_ThrowsIfStartDateInFuture()
    {
        // Act & Assert
        var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            _ = new Education("Test University", "BSc", DateTime.UtcNow.AddDays(1), null, "desc");
        });
    }

    [TestMethod]
    public void Constructor_ThrowsIfEndDateBeforeStartDate()
    {
        // Arrange
        var start = new DateTime(2022, 1, 1);
        var end = new DateTime(2021, 1, 1);

        // Act & Assert
        var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            _ = new Education("Test University", "BSc", start, end, "desc");
        });
    }

    [TestMethod]
    public void Update_ChangesDegreeEndDateAndDescription()
    {
        // Arrange
        var edu = new Education("Test University", "BSc", new DateTime(2020, 1, 1), null, "desc");
        var newDegree = "MSc";
        var newEndDate = new DateTime(2024, 1, 1);
        var newDescription = "Updated desc";

        // Act
        edu.Update(newDegree, newEndDate, newDescription);

        // Assert
        Assert.AreEqual(newDegree, edu.Degree);
        Assert.AreEqual(newEndDate, edu.EndDate);
        Assert.AreEqual(newDescription, edu.Description);
    }

    [TestMethod]
    public void Update_ThrowsIfDegreeIsNullOrEmpty()
    {
        // Arrange
        var edu = new Education("Test University", "BSc", new DateTime(2020, 1, 1), null, "desc");

        // Act & Assert
        var ex = Assert.ThrowsException<ArgumentException>(() =>
        {
            edu.Update("", null, "desc");
        });
    }

    [TestMethod]
    public void Update_ThrowsIfEndDateBeforeStartDate()
    {
        // Arrange
        var edu = new Education("Test University", "BSc", new DateTime(2020, 1, 1), null, "desc");

        // Act & Assert
        var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            edu.Update("MSc", new DateTime(2019, 1, 1), "desc");
        });
    }
}