using AppInfrastructure.Services.StoreServices;
using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.ServicesTests.Base;

namespace AppInfrastructureTests.ServicesTests;

[TestClass]
public class BaseGenericLazyStoreNavigationServiceTests:BaseAbstractLazyStoreNavigationServiceTests<BaseLazyStore<string>,BaseLazyStoreNavigationService<string>,string>
{
    protected override string GenerateValue() => "newValue";
    
    protected override BaseLazyStore<string> GenerateStore() => new ();
    
    protected override BaseLazyStoreNavigationService<string> GenerateService(BaseLazyStore<string> store,
        string newInfo) => new (store, () => newInfo);

}