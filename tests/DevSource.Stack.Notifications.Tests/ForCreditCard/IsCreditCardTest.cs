namespace DevSource.Stack.Notifications.Tests.ForCreditCard;

[TestClass]
public class IsCreditCardTest
{
    [TestMethod]
    public void WhenCreditCardIsValidVisa_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validCard = "4532015112830366"; // Valid Visa test card
        
        // Act
        validation.IsCreditCard("CreditCard", validCard);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCreditCardIsValidMastercard_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validCard = "5425233430109903"; // Valid Mastercard test card
        
        // Act
        validation.IsCreditCard("CreditCard", validCard);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCreditCardHasSpaces_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validCard = "4532 0151 1283 0366";
        
        // Act
        validation.IsCreditCard("CreditCard", validCard);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCreditCardHasDashes_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validCard = "4532-0151-1283-0366";
        
        // Act
        validation.IsCreditCard("CreditCard", validCard);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCreditCardIsInvalid_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCard = "1234567890123456"; // Invalid according to Luhn
        
        // Act
        validation.IsCreditCard("CreditCard", invalidCard);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCreditCardContainsLetters_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCard = "4532015112830ABC";
        
        // Act
        validation.IsCreditCard("CreditCard", invalidCard);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCreditCardIsEmpty_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCard = "";
        
        // Act
        validation.IsCreditCard("CreditCard", invalidCard);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}
