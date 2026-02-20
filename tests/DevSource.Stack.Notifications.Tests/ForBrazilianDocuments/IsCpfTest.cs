namespace DevSource.Stack.Notifications.Tests.ForBrazilianDocuments;

[TestClass]
public class IsCpfTest
{
    [TestMethod]
    public void WhenCpfIsValid_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validCpf = "123.456.789-09"; // Valid CPF with formatting
        
        // Act
        validation.IsCpf("CPF", validCpf);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCpfIsValidWithoutFormatting_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string validCpf = "12345678909"; // Valid CPF without formatting
        
        // Act
        validation.IsCpf("CPF", validCpf);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCpfHasInvalidCheckDigits_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCpf = "123.456.789-00"; // Invalid check digits
        
        // Act
        validation.IsCpf("CPF", invalidCpf);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCpfHasAllSameDigits_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCpf = "111.111.111-11";
        
        // Act
        validation.IsCpf("CPF", invalidCpf);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCpfIsEmpty_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCpf = "";
        
        // Act
        validation.IsCpf("CPF", invalidCpf);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCpfHasWrongLength_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        const string invalidCpf = "123.456.789";
        
        // Act
        validation.IsCpf("CPF", invalidCpf);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}
