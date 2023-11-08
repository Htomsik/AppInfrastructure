namespace AppInfrastructure.Stores.DefaultStore;

/// <summary>
///      Base lazy realize for IStore with custom default parameter.
/// </summary>
public class BaseLazyCustomDefaultStore : BaseLazyStore
{
    /// <summary>
    ///     This value is set on CurrentValue when CurrentValue is null
    /// </summary>
    protected readonly object DefaultValue;
    
    #region CurrentValue
    public override object? CurrentValue
    {
        get => _currentValue.Value ?? DefaultValue;
        set
        {
            _currentValue = new Lazy<object?>(() => value);
            
            if(value is null || value == default)
                OnCurrentValueDeleted();
            
            OnCurrentValueChanged();
        }
    }

    #endregion
    
    #region Constructors


    /// <param name="currentValue">First value for CurrentValue</param>
    /// <param name="defaultValue">Value is set on CurrentValue when CurrentValue is null</param>
    /// <exception cref="ArgumentNullException">Then defaultValue is null</exception>
    public BaseLazyCustomDefaultStore(object currentValue, object defaultValue) : this(defaultValue) => CurrentValue = currentValue;

 
    /// <param name="defaultValue">Value is set on CurrentValue when CurrentValue is null</param>
    /// <exception cref="ArgumentNullException">Then defaultValue is null</exception>
    public BaseLazyCustomDefaultStore(object defaultValue) =>  DefaultValue = defaultValue ?? throw new ArgumentNullException(nameof(defaultValue));
    
  
    
    #endregion
}

/// <summary>
///      Base lazy generic realize for IStore with custom default parameter.
/// </summary>
/// <typeparam name="TValue">Some value with IEquatable</typeparam>
public class BaseLazyCustomDefaultStore<TValue> : BaseLazyCustomDefaultStore, IStore<TValue>  where TValue : IEquatable<TValue>
{
    #region Constructors

    
    /// <param name="currentValue">First value for CurrentValue</param>
    /// <param name="defaultValue">Value is set on CurrentValue when CurrentValue is null</param>
    /// <exception cref="ArgumentNullException">Then defaultValue is null</exception>
    public BaseLazyCustomDefaultStore(object currentValue, object defaultValue) : base(currentValue, defaultValue)
    {
    }
    
    /// <param name="defaultValue">Value is set on CurrentValue when CurrentValue is null</param>
    /// <exception cref="ArgumentNullException">Then defaultValue is null</exception>
    public BaseLazyCustomDefaultStore(object defaultValue) : base(defaultValue)
    {
    }

    #endregion

    #region CurrentValue

    public new virtual TValue? CurrentValue
    {
        get
        {
            if (_currentValue?.Value is null) 
                return (TValue?)DefaultValue;
         
            return (TValue?)(((TValue?)_currentValue?.Value).Equals(default) ? DefaultValue : _currentValue.Value);
        }
        set
        {
            _currentValue =  new Lazy<object?>(() => value);
            
            if(value is null || ((TValue?)value).Equals(default))
                OnCurrentValueDeleted();
            
            OnCurrentValueChanged();
        }
    }

    #endregion

}

