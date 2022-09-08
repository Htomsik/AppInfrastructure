using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.StoresTests.StoreTests.Base;

namespace AppInfrastructureTests.StoresTests.StoreTests.BaseLazyCustomDefaultStoreTests;

[TestClass]
public class BaseNotGenericLazyCustomDefaultStore : BaseAbstractLazyStoreTests<BaseLazyCustomDefaultStore,object>
{
    private static readonly string Def = "Default";
    
    protected override BaseLazyCustomDefaultStore GenerateStore() => new (Def);
    
    protected override object GenerateValue() => "NewValue";

    [TestMethod]
    public void IsNotGeneriCurrentValueHaveCutomDefaultParams()
    {
        //Arrange
        var someStore = GenerateStore();
        
        //Act
        someStore.CurrentValue = GenerateValue();

        someStore.CurrentValue = null;
        
        //Assert
        Assert.AreEqual(Def,someStore.CurrentValue);
    }
    
    
    [TestMethod]
    public override void IsCurrentValueDeletedNotifierNotify()
    {
        //Arrange
        var newValue = GenerateValue();

        var someStore = GenerateStore();

        //Act+Assert
        someStore.CurrentValueDeletedNotifier += () => Assert.AreEqual(someStore.CurrentValue,Def);

        someStore.CurrentValue = newValue;

        someStore.CurrentValue = default;
    }
}