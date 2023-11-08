using AppInfrastructure.Services.StoreServices;
using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.Services.NavigationService.FullNavigation.Base;

namespace AppInfrastructureTests.Services.NavigationService.FullNavigation;

[TestClass]
public class BaseNotGenericLazyStoreFullNavigationService : BaseAbstractLazyStoreFullNavigationService<BaseLazyStore,BaseLazyStoreFullNavigationService,object>
{
    protected override object GenerateValue() => "NewValue";
    protected override BaseLazyStore GenerateStore() => new();
    protected override BaseLazyStoreFullNavigationService GenerateService(BaseLazyStore store, object newInfo) =>
        new(store, ()=> newInfo);

}