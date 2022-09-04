using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.StoresTests.StoreTests.Base;

namespace AppInfrastructureTests.StoresTests.StoreTests.BaseLazyCustomDefaultStoreTests;

[TestClass]
public class BaseGenericLazyCustomDefaultStore:BaseAbstractLazyStoreTests<BaseLazyCustomDefaultStore<int>,int>
{
    private static readonly int Def = 123;

    protected override BaseLazyCustomDefaultStore<int> GenerateStore() => new(Def);

    protected override int GenerateValue() => 321;
    
    [TestMethod]
    public void IsNotGeneriCurrentValueHaveCutomDefaultParams()
    {
        //Arrange
        var someStore = GenerateStore();
        
        //Act
        someStore.CurrentValue = GenerateValue();

        someStore.CurrentValue = default;
        
        //Assert
        Assert.AreEqual(Def,someStore.CurrentValue);
    }

}