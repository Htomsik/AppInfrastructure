using AppInfrastructure.Services.NavigationServices.Navigation;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructureTests.Services.NavigationService.Base;


public abstract class BaseAbstractLazyStoreNavigationServiceTests<TStore,TNavService,TValue> 
  where TStore : IStore 
  where TNavService : INavigationServices
{
  [TestMethod]
  public void IsBaseLazyStoreNavigationServiceNavigate()
  {
    //Arrange
    TValue newIfno = GenerateValue();

    TStore someStore = GenerateStore();
    
    var SomeService = GenerateService(someStore,newIfno);
    //Act
    SomeService.Navigate();
    
    //Assert
    Assert.AreEqual(newIfno,someStore.CurrentValue);
  }

  protected abstract TValue GenerateValue();

  protected abstract TStore GenerateStore();

  protected abstract TNavService GenerateService(TStore store, TValue newInfo);


}