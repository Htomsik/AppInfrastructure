using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.StoresTests.StoreTests.Base;

namespace AppInfrastructureTests.StoresTests.StoreTests.BaseLazyStoreTests;

[TestClass]
public class BaseGenericLazyStoreTests : BaseAbstractLazyStoreTests<BaseLazyStore<int>, int>
{
    protected override BaseLazyStore<int> GenerateStore() => new();
    
    protected override int GenerateValue() => 123;
}
   