using AppInfrastructure.Services.NavigationServices.Navigation.Parametrize;
using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.ServicesTests.IParametrizeNavigationServiceTests.Base;

namespace AppInfrastructureTests.ServicesTests.IParametrizeNavigationServiceTests.FullNavigation.Base;

public abstract class BaseAbstractLazyParamFullNavigationServiceTests<TStore,TService,TInput,TOutput> : BaseAbstractLazyParamNavigationService<TStore,TService,TInput,TOutput> 
    where TStore : IStore<TOutput>
    where TService : IFullParamNavigationService<TInput>

{
    [TestMethod]
    public void IsBaseLazyParametrizeFullNavigationServiceClose()
    {
        //Arrange
        var inputValue = GenerateInputValue();
        
        var outputValue = GenerateOutputValue();
        
        var someFunc = GenerateFunc(inputValue,outputValue);
        
        var someStore = GenerateStore();

        var someService = GenerateService(someStore, someFunc);
        
        //Act + Assert
        someService.Navigate(inputValue);
        
        Assert.AreEqual(someStore.CurrentValue,outputValue);
    
        someService.Close();
        
        Assert.IsNull(someStore.CurrentValue);
      
    }
}
