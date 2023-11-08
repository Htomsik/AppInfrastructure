using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructure.Stores.Repositories.BaseTypes;

/// <summary>
///     Base lazy realize for iRepository.
/// </summary>
public class BaseLazyRepository : BaseLazyStore, IRepository
{
    #region Methods

    #region Add : Add some value from store

    public bool Add(object value)
    {
        bool isAdded;
        try
        {
           isAdded = add(value);
        }
        catch
        {
            isAdded = false;
        }

        return isAdded;
    }

    /// <summary>
    ///     Add method for child.
    ///     Base: Set CurrentValue = value if CurrentValue != value
    /// </summary>
    /// <param name="value">Removed value</param>
    protected virtual bool add(object value)
    {
        if (CurrentValue is null || !CurrentValue.Equals(value))
        {
            CurrentValue = value;
            return true;
        }
        
        return false;
    } 

    #endregion
    
    #region Remove :  Remove some value from store
    
    public bool Remove(object value)
    {
        bool isRemoved;
        try
        {
          isRemoved = remove(value);
        }
        catch
        {
            isRemoved = false;
        }

        return isRemoved;
    }

    /// <summary>
    ///     Remove method for child.
    ///     Base: Set current value to null if CurrentValue == value
    /// </summary>
    /// <param name="value">Removed value</param>
    protected virtual bool remove(object value)
    {
        if ((bool)CurrentValue?.Equals(value))
        {
            Close();
            return true;
        }
        return false;
    }

    #endregion
    public void Close() => CurrentValue = default;
    
    #endregion

    #region Constructors

    public BaseLazyRepository(object value) : base(value){}

    public BaseLazyRepository(){}

    #endregion
}

/// <summary>
///     Base lazy generic realize for iRepository.
/// </summary>
/// <typeparam name="TValue"></typeparam>
public class BaseLazyRepository<TValue> : BaseLazyStore<TValue>, IRepository<TValue>
{
    #region Methods

    #region Add : Add some value from store

    public bool Add(TValue value)
    {
        bool isAdded;
            
        try
        {
            isAdded = add(value);
        }
        catch (Exception)
        {
            isAdded = false;
        }

        return isAdded;
    }
    
    /// <summary>
    ///     Add method for child.
    ///     Base: Set CurrentValue = value if CurrentValue != value
    /// </summary>
    /// <param name="value">Added value</param>
    protected virtual bool add(TValue value)
    {
        
        if (_currentValue.Value is null || !_currentValue.Value.Equals(value))
        {
            CurrentValue = value;
            return true;
        }

        return false;
    } 

    #endregion

    #region Remove : Remove some value from store

    public bool Remove(TValue value)
    {
        bool isRemoved;
        try
        {
            isRemoved = remove(value);
        }
        catch
        {
            isRemoved = false;
        }

        return isRemoved;
    }
    
    /// <summary>
    ///     Remove method for child.
    ///     Base: Set current value to null if CurrentValue == value
    /// </summary>
    /// <param name="value">Removed value</param>
    protected virtual bool remove(TValue value)
    {
        if ((bool)_currentValue?.Value?.Equals(value))
        {
            Close();
            return true;
        }
        
        return false;
    }

    #endregion
    
    public void Close() => CurrentValue = default;
    
    #endregion
    
    #region Constructors

    public BaseLazyRepository(TValue value) : base(value){}

    public BaseLazyRepository(){}

    #endregion
}


