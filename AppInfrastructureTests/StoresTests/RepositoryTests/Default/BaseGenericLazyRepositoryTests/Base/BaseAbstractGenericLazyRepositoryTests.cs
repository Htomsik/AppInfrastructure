using AppInfrastructure.Stores.Repositories.BaseTypes;
using AppInfrastructureTests.StoresTests.StoreTests.Base;

namespace AppInfrastructureTests.StoresTests.RepositoryTests.Default.BaseGenericLazyRepositoryTests.Base;


public abstract class BaseAbstractGenericLazyRepositoryTests<TRepository,TValue>:BaseAbstractLazyStoreTests<TRepository,TValue>
    where TRepository : IRepository<TValue>
{
    protected override abstract TRepository GenerateStore();
    
    protected override abstract TValue GenerateValue();


    [TestMethod]
    public virtual void IsAddWorkingRight()
    {
        //Arrange
        var someRepository = GenerateStore();
        
        var someValue = GenerateValue();
        
        //Act + Assert
        IsAddWorkingRightChild(someRepository, someValue);

    }
    
    protected virtual void IsAddWorkingRightChild(TRepository someRepository, TValue someValue) 
    {
        Assert.IsTrue(someRepository.Add(someValue));
        Assert.IsFalse(someRepository.Add(someValue));
    }
    
    
    [TestMethod]
    public virtual void IsRemoveWorkingRight()
    {
        //Arrange
        var someRepository = GenerateStore();

        var someValue = GenerateValue();
        
        //Act + Assert
        IsRemoveWorkingRightChild(someRepository, someValue);

    }
    
    protected virtual void IsRemoveWorkingRightChild(TRepository someRepository, TValue someValue) 
    {
        Assert.IsFalse(someRepository.Remove(someValue));
        someRepository.Add(someValue);
        Assert.IsTrue(someRepository.Remove(someValue));
    }

}