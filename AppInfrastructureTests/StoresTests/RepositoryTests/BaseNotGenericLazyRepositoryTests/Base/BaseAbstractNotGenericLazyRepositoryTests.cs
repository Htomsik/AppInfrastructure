using AppInfrastructure.Stores.Repositories;
using AppInfrastructureTests.StoresTests.StoreTests.Base;

namespace AppInfrastructureTests.StoresTests.RepositoryTests.BaseNotGenericLazyRepositoryTests.Base;

public abstract class BaseAbstractNotGenericLazyRepositoryTests<TRepository,TValue>:BaseAbstractLazyStoreTests<TRepository,TValue>
    where TRepository : IRepository
{
    protected override abstract TRepository GenerateStore();
    
    protected override abstract TValue GenerateValue();


    [TestMethod]
    public virtual void IsAddWorkingRight()
    {
        //Arrange
        var SomeRepository = GenerateStore();

        var SomeValue = GenerateValue();
        
        //Act + Assert
        IsAddWorkingRightChild(SomeRepository, SomeValue);

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