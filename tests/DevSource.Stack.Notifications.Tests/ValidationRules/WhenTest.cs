namespace DevSource.Stack.Notifications.Tests.ValidationRules;

[TestClass]
public class WhenTest
{
    [TestMethod]
    public void WhenConditionIsTrue_ExecuteValidations()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        const string value = "";
        
        // Act
        validation.When(true, v => v.IsNotNull("Value", value));
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenConditionIsFalse_DoNotExecuteValidations()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        const string value = "";
        
        // Act
        validation.When(false, v => v.IsNotNull("Value", value));
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenConditionFunctionReturnsTrue_ExecuteValidations()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        const string value = "";
        var shouldValidate = true;
        
        // Act
        validation.When(() => shouldValidate, v => v.IsNotNull("Value", value));
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenConditionFunctionReturnsFalse_DoNotExecuteValidations()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        const string value = "";
        var shouldValidate = false;
        
        // Act
        validation.When(() => shouldValidate, v => v.IsNotNull("Value", value));
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenMultipleConditions_ExecuteAccordingly()
    {
        // Arrange
        var validation = new Validations.ValidationRules<object>();
        const string value1 = "";
        const string value2 = "test";
        
        // Act
        validation
            .When(true, v => v.IsNotNull("Value1", value1))
            .When(false, v => v.IsNotNull("Value2", value2));
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
        Assert.AreEqual(1, validation.Notifications.Count);
    }
}
