using System;
using AppInfrastructure.Services.NavigationServices.Navigation.Parametrize;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructureTests.ServicesTests.IParametrizeNavigationServiceTests.Base;

public abstract class BaseAbstractLazyParamNavigationService<TStore,TService,TInput,TOutput>
where TStore : IStore<TOutput>
where TService : IParamNavigationService<TInput>
{
    [TestMethod]
    public void isParametrizeServicenavigate()
    {
        //Arrange
        var inputValue = GenerateInputValue();
        
        var outputValue = GenerateOutputValue();
        
        var someFunc = GenerateFunc(inputValue,outputValue);
        
        var someStore = GenerateStore();

        var someService = GenerateService(someStore, someFunc);
        //Act
        someService.Navigate(inputValue);
        
        //Assert
        Assert.AreEqual(someStore.CurrentValue,outputValue);
    }

    protected abstract TInput GenerateInputValue();
    
    protected abstract TOutput GenerateOutputValue();
    
    protected virtual Func<TInput, TOutput> GenerateFunc(TInput input, TOutput output) => 
        (input) =>
            input.Equals(GenerateInputValue()) 
                ? GenerateOutputValue() 
                : throw new ArgumentException(nameof(input));
    
  
    protected abstract TStore GenerateStore();

    protected abstract TService GenerateService(IStore<TOutput> store, Func<TInput, TOutput> action);
}