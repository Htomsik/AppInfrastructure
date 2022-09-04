using AppInfrastructure.Services.NavigationServices.Navigation;
using AppInfrastructure.Stores.DefaultStore;
using AppInfrastructureTests.ServicesTests.INavigationServiceTests.Base;

namespace AppInfrastructureTests.ServicesTests.INavigationServiceTests.FullNavigation.Base;

public abstract class BaseAbstractLazyStoreFullNavigationService<TStore, TNavService, TValue> : BaseAbstractLazyStoreNavigationServiceTests<TStore,TNavService,TValue> 
    where TStore : IStore 
    where TNavService : IFullNavigationService
{
    [TestMethod]
    public void IsBaseLazyStoreFullNavigationServiceClose()
    {
        //Arrange
        TValue newIfno = GenerateValue();

        TStore someStore = GenerateStore();
    
        var SomeService = GenerateService(someStore,newIfno);
        
        //Act
        SomeService.Navigate();
    
        Assert.AreEqual(newIfno,someStore.CurrentValue);
        
        SomeService.Close();
        
        //Assert
        Assert.IsNull(someStore.CurrentValue);
    }
}