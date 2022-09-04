﻿using AppInfrastructure.Services.StoreServices;
using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.ServicesTests.Base;

namespace AppInfrastructureTests.ServicesTests;

[TestClass]
public class BaseNotGenericLazyStoreNavigationServiceTests: BaseAbstractLazyStoreNavigationServiceTests<BaseLazyStore,BaseLazyStoreNavigationService,object>
{
    protected override object GenerateValue() => "NewValue";
    
    protected override BaseLazyStore GenerateStore() => new ();
    
    protected override BaseLazyStoreNavigationService GenerateService(BaseLazyStore store, object newInfo) =>
        new (store, ()=> newInfo);

}