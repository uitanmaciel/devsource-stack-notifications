namespace DevSource.Stack.Notifications.Tests.ForBrazilianDocuments;

[TestClass]
public class IsCnpjTest
{
    [TestMethod]
    public void WhenCnpjIsValid_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validCnpj = "11.222.333/0001-81"; // Valid CNPJ with formatting
        
        // Act
        validation.IsCnpj("CNPJ", validCnpj);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCnpjIsValidWithoutFormatting_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validCnpj = "11222333000181"; // Valid CNPJ without formatting
        
        // Act
        validation.IsCnpj("CNPJ", validCnpj);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCnpjHasInvalidCheckDigits_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCnpj = "11.222.333/0001-00"; // Invalid check digits
        
        // Act
        validation.IsCnpj("CNPJ", invalidCnpj);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCnpjHasAllSameDigits_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCnpj = "11.111.111/1111-11";
        
        // Act
        validation.IsCnpj("CNPJ", invalidCnpj);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCnpjIsEmpty_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCnpj = "";
        
        // Act
        validation.IsCnpj("CNPJ", invalidCnpj);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCnpjHasWrongLength_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCnpj = "11.222.333";
        
        // Act
        validation.IsCnpj("CNPJ", invalidCnpj);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}
