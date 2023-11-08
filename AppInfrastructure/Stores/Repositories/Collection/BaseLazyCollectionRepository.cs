using AppInfrastructure.Stores.Repositories.BaseTypes;

namespace AppInfrastructure.Stores.Repositories.Collection;

public class BaseLazyCollectionRepository<TCollection, TValue> : BaseLazyRepository<TCollection>, ICollectionRepository<TCollection, TValue>
    where TCollection : ICollection<TValue>, new() 
{
    #region Methods
    
    #region AddIntoEnumerable :  Add some value into ICollection

    public bool AddIntoEnumerable(TValue value)
    {
        bool isAdded;
            
        try
        {
            isAdded = addIntoEnumerable(value);
        }
        catch (Exception)
        {
            isAdded = false;
        }

        if (isAdded)
            OnCurrentValueChanged();

        return isAdded;
    }

    /// <summary>
    ///     Add method into collection for child.
    ///     Base: Add value is CurrentValue doesn't contains it
    /// </summary>
    /// <param name="value">Added value</param>
    protected virtual bool addIntoEnumerable(TValue value)
    {
        if (Contains(value))
            return false;
        
        CurrentValue.Add(value);
        return true;
    }

    #endregion
    
    #region RemoveFromEnumerable : Remove some value from ICollection

    public bool RemoveFromEnumerable(TValue value)
    {
        bool isRemoved;
            
        try
        {
            isRemoved = removeFromEnumerable(value);
        }
        catch (Exception)
        {
            isRemoved = false;
        }

        if (isRemoved)
            OnCurrentValueChanged();
        
        return isRemoved;
    }

    /// <summary>
    ///     Remove method from collection for child.
    ///     Base: Remove value is CurrentValue contains it
    /// </summary>
    /// <param name="value">Added value</param>
    protected virtual bool removeFromEnumerable(TValue value)
    {
        if (!Contains(value))
            return false;
        
        return (bool)CurrentValue?.Remove(value);
    }

    #endregion


    public virtual TValue Find(TValue parameter) => Contains(parameter) ? CurrentValue.FirstOrDefault(item=>item.Equals(parameter),default) : default;
    
    public virtual bool Contains(TValue value) =>(bool)CurrentValue?.Contains(value);
    
    
    #endregion

    #region Properties

    public new virtual TCollection? CurrentValue
    {
        get => (TCollection?)_currentValue?.Value;
        set
        {
            _currentValue =  new Lazy<object?>(() => value);
            
            if(value is null || value.Equals(default))
                OnCurrentValueDeleted();
            
            OnCurrentValueChanged();
        }
    }

    #endregion

    #region Constructors

    public BaseLazyCollectionRepository(TCollection value) : base(value)
    {
        
    }

    public BaseLazyCollectionRepository() : this(new TCollection())
    {
        
    }

    #endregion
}
  
