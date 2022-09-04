using AppInfrastructure.Services.StoreServices;
using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.ServicesTests.INavigationServiceTests.FullNavigation.Base;

namespace AppInfrastructureTests.ServicesTests.INavigationServiceTests.FullNavigation;

[TestClass]
public class BaseNotGenericLazyStoreFullNavigationService : BaseAbstractLazyStoreFullNavigationService<BaseLazyStore,BaseLazyStoreFullNavigationService,object>
{
    protected override object GenerateValue() => "NewValue";
    protected override BaseLazyStore GenerateStore() => new();
    protected override BaseLazyStoreFullNavigationService GenerateService(BaseLazyStore store, object newInfo) =>
        new(store, ()=> newInfo);

}