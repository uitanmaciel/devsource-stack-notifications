namespace DevSource.Stack.Notifications.Tests.ForPhone;

[TestClass]
public class IsBrazilianPhoneTest
{
    [TestMethod]
    public void WhenPhoneIsValidWithParenthesesAndDash_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validPhone = "(11) 98765-4321";
        
        // Act
        validation.IsBrazilianPhone("Phone", validPhone);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenPhoneIsValidWithoutFormatting_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validPhone = "11987654321";
        
        // Act
        validation.IsBrazilianPhone("Phone", validPhone);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenLandlineIsValid_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validPhone = "(11) 3456-7890";
        
        // Act
        validation.IsBrazilianPhone("Phone", validPhone);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenPhoneHasInvalidAreaCode_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidPhone = "(00) 98765-4321";
        
        // Act
        validation.IsBrazilianPhone("Phone", invalidPhone);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenPhoneIsEmpty_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidPhone = "";
        
        // Act
        validation.IsBrazilianPhone("Phone", invalidPhone);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}
