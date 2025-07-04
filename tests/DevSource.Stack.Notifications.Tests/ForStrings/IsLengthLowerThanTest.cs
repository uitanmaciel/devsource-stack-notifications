﻿namespace DevSource.Stack.Notifications.Tests.ForStrings;

[TestClass]
public class IsLengthLowerThanTest
{
    [TestMethod]
    public void WhenStringIsLowerThan_NotReturnNotification()
    {
        // Arrange
        // Initialize the validation rules object for a generic type
        var validation = new ValidationRules<object>();
        const string value = "012345";
        const int size = 10;
        
        // Act
        // Validate that the value does not exceed the maximum allowable length
        validation.IsLengthLowerThan("Value", value, size);
        
        // Assert
        // Verify that there are no validation notifications, indicating the value is within the allowed maximum length
        Assert.IsTrue(!validation.HasNotifications);
    }
}