using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.Stores.StoreTests.Base;

namespace AppInfrastructureTests.Stores.StoreTests.BaseLazyStoreTests;

[TestClass]
public class BaseNotGenericLazyStoreTests : BaseAbstractLazyStoreTests<IStore,object>
{
    protected override IStore GenerateStore() => new BaseLazyStore();
    
    protected override object GenerateValue() => "NewValue";

}