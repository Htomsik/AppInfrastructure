using AppInfrastructure.Services.StoreServices;
using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.ServicesTests.INavigationServiceTests.Base;

namespace AppInfrastructureTests.ServicesTests.INavigationServiceTests.Navigation;

[TestClass]
public class BaseGenericLazyStoreNavigationServiceTests:BaseAbstractLazyStoreNavigationServiceTests<BaseLazyStore<string>,BaseLazyStoreNavigationService<string>,string>
{
    protected override string GenerateValue() => "newValue";
    
    protected override BaseLazyStore<string> GenerateStore() => new ();
    
    protected override BaseLazyStoreNavigationService<string> GenerateService(BaseLazyStore<string> store,
        string newInfo) => new (store, () => newInfo);

}