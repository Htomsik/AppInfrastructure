namespace AppInfrastructure.Stores.Repositories;

public class BaseLazyCollectionRepository<TCollection, TValue> : BaseLazyRepository<TCollection>, ICollectionRepository<TCollection, TValue>
    where TCollection : ICollection<TValue>
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
        bool isAdded;
            
        try
        {
            isAdded = removeFromEnumerable(value);
        }
        catch (Exception)
        {
            isAdded = false;
        }

        return isAdded;
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
    
    public virtual TValue Find(TValue parameter) => Contains(parameter) ? CurrentValue.FirstOrDefault(parameter) : default;

    public virtual bool Contains(TValue value) => (bool)CurrentValue?.FirstOrDefault(value)?.Equals(value);
    
    #endregion

    #region Constructors

    public BaseLazyCollectionRepository(TCollection value) : base(value){}

    public BaseLazyCollectionRepository(){}

    #endregion
}
  
