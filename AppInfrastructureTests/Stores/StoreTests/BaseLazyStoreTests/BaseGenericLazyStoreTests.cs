using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.Stores.StoreTests.Base;

namespace AppInfrastructureTests.Stores.StoreTests.BaseLazyStoreTests;

[TestClass]
public class BaseGenericLazyStoreTests : BaseAbstractLazyStoreTests<BaseLazyStore<int>, int>
{
    protected override BaseLazyStore<int> GenerateStore() => new();
    
    protected override int GenerateValue() => 123;
}
   