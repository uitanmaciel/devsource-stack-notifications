namespace DevSource.Stack.Notifications.Tests.ForCollections;

[TestClass]
public class ContainsItemTest
{
    [TestMethod]
    public void WhenCollectionContainsItem_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3, 4, 5 };
        
        // Act
        validation.ContainsItem("Collection", collection, 3);
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionDoesNotContainItem_ReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<int> { 1, 2, 3, 4, 5 };
        
        // Act
        validation.ContainsItem("Collection", collection, 10);
        
        // Assert
        Assert.IsTrue(validation.HasNotifications);
    }
    
    [TestMethod]
    public void WhenCollectionContainsStringItem_NotReturnNotification()
    {
        // Arrange
        var validation = new ValidationRules<object>();
        var collection = new List<string> { "apple", "banana", "cherry" };
        
        // Act
        validation.ContainsItem("Collection", collection, "banana");
        
        // Assert
        Assert.IsTrue(!validation.HasNotifications);
    }
}
