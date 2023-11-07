using System.Collections.Generic;
using AppInfrastructure.Stores.Repositories.BaseTypes;
using AppInfrastructure.Stores.Repositories.Collection;
using AppInfrastructureTests.StoresTests.RepositoryTests.Default.BaseGenericLazyRepositoryTests.Base;

namespace AppInfrastructureTests.StoresTests.RepositoryTests.Collection.Base;

public abstract class BaseAbstractLazyCollectionRepositoryTests<TCollection,TCollectionRepository,TValue> : BaseAbstractGenericLazyRepositoryTests<TCollectionRepository,TCollection>
where TCollectionRepository: ICollectionRepository<TCollection,TValue>, IRepository<TCollection>
where TCollection : ICollection<TValue>
{
    protected override abstract TCollectionRepository GenerateStore();
    
    protected override abstract TCollection GenerateValue();
    
    protected  abstract TValue GenerateFirstValueInCollection();
    
    protected  abstract TValue GenerateSecondValueInCollection();


    #region IsValueAddedInCollectionRepository

    [TestMethod]
    public  void IsValueAddedInCollectionRepository()
    {
        //Arrange
        var someValue = GenerateFirstValueInCollection();
        
        var someCollectionRepo = GenerateStore();

        IsValueAddedChild(someCollectionRepo, someValue);
    }

    private void IsValueAddedChild(TCollectionRepository someCollectionRepo, TValue someValue)
    {
        //Act+Assert
        Assert.IsTrue(someCollectionRepo.AddIntoEnumerable(someValue));
        Assert.IsTrue(someCollectionRepo.Contains(someValue));
    }

    #endregion

    #region IsValueRemovedInCollectionRepository

    [TestMethod]
    public  void IsValueRemovedInCollectionRepository()
    {
        //Arrange
        var someValue = GenerateFirstValueInCollection();
        
        var someCollectionRepo = GenerateStore();
        
        //Act+Assert
        someCollectionRepo.AddIntoEnumerable(someValue);
        
        IsValueRemovedChild(someCollectionRepo, someValue);
    }
    
    
    private void IsValueRemovedChild(TCollectionRepository someCollectionRepo, TValue someValue)
    {
        //Act+Assert
        Assert.IsTrue(someCollectionRepo.RemoveFromEnumerable(someValue));
        Assert.IsFalse(someCollectionRepo.Contains(someValue));
    }

    #endregion
    
    #region IsValueFindingInCollectionRepository

    [TestMethod]
    public void IsValueFindingInCollectionRepository()
    {
        //Arrange
        var someFirstValue = GenerateFirstValueInCollection();
        
        var someSecondValue = GenerateSecondValueInCollection();

        var someCollectionRepo = GenerateStore();
        
        //Act+Assert
        Assert.IsTrue(someCollectionRepo.AddIntoEnumerable(someFirstValue));
        Assert.IsTrue( someCollectionRepo.AddIntoEnumerable(someSecondValue));
       
        IsValueFindingInCollectionRepositoryChild(someCollectionRepo, someFirstValue,someSecondValue);
    }

    protected virtual void IsValueFindingInCollectionRepositoryChild(
        TCollectionRepository someCollectionRepo,
        TValue firstValue, 
        TValue secondValue)
    {
        Assert.AreEqual(firstValue,someCollectionRepo.Find(firstValue));
        
        Assert.AreEqual(secondValue,someCollectionRepo.Find(secondValue));
    }

    #endregion
    
    #region IsCurrentValuePropertyChangedWhenAddIntoCollection
    
    [TestMethod]
    public void IsCurrentValuePropertyChangedWhenAddIntoCollection()
    {
        //Arrange
        var isCurrentValueAdded = false;
        
        var someValue = GenerateFirstValueInCollection();
        
        var someCollectionRepo = GenerateStore();
        
        //Act
        someCollectionRepo.CurrentValueChangedNotifier += ()=> isCurrentValueAdded = someCollectionRepo.Contains(someValue);
            
        someCollectionRepo.AddIntoEnumerable(someValue);
        
        //Assert
        Assert.IsTrue(isCurrentValueAdded);
    }
    
    #endregion

    #region IsCurrentValuePropertyChangedWhenRemoveFromCollection
    
    [TestMethod]
    public void IsCurrentValuePropertyChangedWhenRemoveFromCollection()
    {
        //Arrange
        var isCurrentValueRemoved = false;
        
        var someValue = GenerateFirstValueInCollection();
        
        var someCollectionRepo = GenerateStore();

        someCollectionRepo.AddIntoEnumerable(someValue);
        
        //Act
        someCollectionRepo.CurrentValueChangedNotifier += ()=> isCurrentValueRemoved = !someCollectionRepo.Contains(someValue);
            
        someCollectionRepo.RemoveFromEnumerable(someValue);
        
        //Assert
        Assert.IsTrue(isCurrentValueRemoved);
    }


    #endregion
    
}