namespace DevSource.Stack.Notifications.Tests.ForDateTime;

[TestClass]
public class IsDayOfWeekTest
{
    [TestMethod]
    public void WhenDayOfWeekIsCorrect_NotReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        var date = DateTime.Now;
        var dayOfWeek = date.DayOfWeek;
        
        // Act
        // Validate that the current date is within the specified date range
        validation.IsDayOfWeek("Date", date, dayOfWeek);
        
        // Assert
        // Verify that there are no validation notifications, indicating the date is within the range
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenDayOfWeekIsIncorrect_ReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        var date = DateTime.Now;
        var dayOfWeek = date.AddDays(1).DayOfWeek;
        
        // Act
        // Validate that the current date is within the specified date range
        validation.IsDayOfWeek("Date", date, dayOfWeek);
        
        // Assert
        // Verify that there are no validation notifications, indicating the date is within the range
        Assert.IsTrue(validation.HasNotifications);
    }
}