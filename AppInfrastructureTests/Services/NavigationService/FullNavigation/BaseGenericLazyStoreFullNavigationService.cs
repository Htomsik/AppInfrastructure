using AppInfrastructure.Services.StoreServices;
using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.Services.NavigationService.FullNavigation.Base;

namespace AppInfrastructureTests.Services.NavigationService.FullNavigation;

[TestClass]
public class BaseGenericLazyStoreFullNavigationService : BaseAbstractLazyStoreFullNavigationService<BaseLazyStore<string>,BaseLazyStoreFullNavigationService<string>,string>
{
    protected override string GenerateValue() => "NewValue";
    
    protected override BaseLazyStore<string> GenerateStore() => new();
    
    protected override BaseLazyStoreFullNavigationService<string> GenerateService(BaseLazyStore<string> store,
        string newInfo) => new(store,()=> newInfo);

}