using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.StoresTests.StoreTests.Base;

namespace AppInfrastructureTests.StoresTests.StoreTests.BaseLazyStoreTests;

[TestClass]
public class BaseNotGenericLazyStoreTests : BaseAbstractLazyStoreTests<IStore,object>
{
    protected override IStore GenerateStore() => new BaseLazyStore();
    
    protected override object GenerateValue() => "NewValue";

}