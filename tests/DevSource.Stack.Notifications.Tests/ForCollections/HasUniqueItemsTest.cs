namespace DevSource.Stack.Notifications.Tests.ForCollections;

[TestClass]
public class HasUniqueItemsTest
{
    [TestMethod]
    public void WhenCollectionHasUniqueItems_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3, 4, 5 };
        
        // Act
        validation.HasUniqueItems("Collection", collection);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionHasDuplicates_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3, 2, 5 };
        
        // Act
        validation.HasUniqueItems("Collection", collection);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionHasMultipleDuplicates_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<string> { "a", "b", "a", "c", "b" };
        
        // Act
        validation.HasUniqueItems("Collection", collection);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}
