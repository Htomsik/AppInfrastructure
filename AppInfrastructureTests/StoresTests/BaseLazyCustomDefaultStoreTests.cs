using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructureTests.StoresTests;

[TestClass]
public class BaseLazyCustomDefaultStoreTests
{
    [TestMethod]
    public void IsCurrentValueHaveCutomDefaultParamsNotGeneric()
    {
        //Arrange
        const string defaultValue = "Default";

        const string currentValue = "Current";
        
        var lazyCustomDefStore = new BaseLazyCustomDefaultStore(currentValue,defaultValue);
        
        //Act+Assert
        
        lazyCustomDefStore.CurrentValue = null;
        
        Assert.AreEqual( lazyCustomDefStore.CurrentValue, defaultValue );

        lazyCustomDefStore.CurrentValue = currentValue;
        
        Assert.AreEqual( lazyCustomDefStore.CurrentValue, currentValue );

        lazyCustomDefStore.CurrentValue = default;
        
        Assert.AreEqual( lazyCustomDefStore.CurrentValue, defaultValue );
    }
    
    [TestMethod]
    public void IsCurrentValueHaveCutomDefaultParamsGeneric()
    {
        //Arrange
        const string defaultValue = "Default";

        const string currentValue = "Current";
        
        var lazyCustomDefStore = new BaseLazyCustomDefaultStore<string>(currentValue,defaultValue);
        
        //Act+Assert
        
        lazyCustomDefStore.CurrentValue = null;
        
        Assert.AreEqual( lazyCustomDefStore.CurrentValue, defaultValue );

        lazyCustomDefStore.CurrentValue = currentValue;
        
        Assert.AreEqual( lazyCustomDefStore.CurrentValue, currentValue );

        lazyCustomDefStore.CurrentValue = default;
        
        Assert.AreEqual( lazyCustomDefStore.CurrentValue, defaultValue );
    }
}