namespace DevSource.Stack.Notifications.Tests.ForPhone;

[TestClass]
public class IsInternationalPhoneTest
{
    [TestMethod]
    public void WhenPhoneIsValidE164Format_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validPhone = "+5511987654321";
        
        // Act
        validation.IsInternationalPhone("Phone", validPhone);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenPhoneIsValidUSFormat_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validPhone = "+12025551234";
        
        // Act
        validation.IsInternationalPhone("Phone", validPhone);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenPhoneMissesPlusSign_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidPhone = "5511987654321";
        
        // Act
        validation.IsInternationalPhone("Phone", invalidPhone);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenPhoneStartsWithZero_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidPhone = "+0511987654321";
        
        // Act
        validation.IsInternationalPhone("Phone", invalidPhone);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenPhoneIsTooLong_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidPhone = "+5511987654321123456";
        
        // Act
        validation.IsInternationalPhone("Phone", invalidPhone);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}
