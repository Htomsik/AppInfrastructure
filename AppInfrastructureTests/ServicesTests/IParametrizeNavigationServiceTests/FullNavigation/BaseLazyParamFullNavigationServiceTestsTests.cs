using System;
using AppInfrastructure.Services.StoreServices.Parametrize;
using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.ServicesTests.IParametrizeNavigationServiceTests.FullNavigation.Base;

namespace AppInfrastructureTests.ServicesTests.IParametrizeNavigationServiceTests.FullNavigation;

[TestClass]
public class BaseLazyParamFullNavigationServiceTestsTests :BaseAbstractLazyParamFullNavigationServiceTests<BaseLazyStore<object>,BaseLazyParamFullNavigationService<object,object>,object,object>
{
    protected override object GenerateInputValue() => "Input";
    
    protected override object GenerateOutputValue() => "Output";

    protected override BaseLazyStore<object> GenerateStore() => new ();


    protected override BaseLazyParamFullNavigationService<object, object> GenerateService(IStore<object> store,
        Func<object, object> action) => new (store,action);

}