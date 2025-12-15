namespace DevSource.Stack.Notifications.Tests.ForCollections;

[TestClass]
public class HasExactItemsTest
{
    [TestMethod]
    public void WhenCollectionHasExactNumberOfItems_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3 };
        
        // Act
        validation.HasExactItems("Collection", collection, 3);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionHasMoreItems_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3, 4 };
        
        // Act
        validation.HasExactItems("Collection", collection, 3);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionHasFewerItems_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2 };
        
        // Act
        validation.HasExactItems("Collection", collection, 3);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
}
