using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructureTests.StoresTests.StoreTests.Base;

public abstract class BaseAbstractLazyStoreTests<TStore,TValue>
where TStore : IStore
{
    [TestMethod]
    public void IsCurrentValueChangedNotifierNotify()
    {
        //Arrange
        TValue newValue = GenerateValue();
        
        TStore someStore = GenerateStore();
        
        //Act+Assert
        someStore.CurrentValueChangedNotifier += () => Assert.AreEqual(someStore.CurrentValue, newValue);

    }

    protected abstract TStore GenerateStore();

    protected abstract TValue GenerateValue();
}