using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructureTests.StoresTests.StoreTests.Base;

public abstract class BaseAbstractLazyStoreTests<TStore,TValue>
where TStore : IStore
{
    [TestMethod]
    public void IsCurrentValueChangedNotifierNotify()
    {
        //Arrange
        var isPropertyChanged = false;
        
        TValue newValue = GenerateValue();
        
        TStore someStore = GenerateStore();
        
        //Act
        someStore.CurrentValueChangedNotifier += () => isPropertyChanged = true;

        someStore.CurrentValue = newValue;

        //Assert
        Assert.IsTrue(isPropertyChanged);
    }
    
    [TestMethod]
    public virtual void IsCurrentValueDeletedNotifierNotify()
    {
        //Arrange
        var isPropertyDeleted = false;
        
        TValue newValue = GenerateValue();
        
        TStore someStore = GenerateStore();
        
        //Act
        someStore.CurrentValueDeletedNotifier += () => isPropertyDeleted = true;
        
        someStore.CurrentValue = newValue;
        
        someStore.CurrentValue = null;
        
        //Assert
        Assert.IsTrue(isPropertyDeleted);
        
    }

    protected abstract TStore GenerateStore();

    protected abstract TValue GenerateValue();

   
}