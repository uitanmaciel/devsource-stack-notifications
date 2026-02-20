namespace DevSource.Stack.Notifications.Tests.ForCreditCard;

[TestClass]
public class IsCreditCardNotExpiredTest
{
    const string Key = "creditCardExpiration";

    [TestMethod]
    public void WhenCreditCardIsNotExpired_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var futureDate = DateTime.Now.AddYears(2);
        
        // Act
        validation.IsCreditCardNotExpired(Key, futureDate.Month, futureDate.Year);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCreditCardExpiresThisMonth_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();       
        var currentDate = DateTime.Now;
        
        // Act
        validation.IsCreditCardNotExpired(Key, currentDate.Month, currentDate.Year);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCreditCardIsExpired_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var pastDate = DateTime.Now.AddYears(-1);
        
        // Act
        validation.IsCreditCardNotExpired(Key, pastDate.Month, pastDate.Year);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCreditCardExpiredLastMonth_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var lastMonth = DateTime.Now.AddMonths(-1);
        
        // Act
        validation.IsCreditCardNotExpired(Key, lastMonth.Month, lastMonth.Year);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}
