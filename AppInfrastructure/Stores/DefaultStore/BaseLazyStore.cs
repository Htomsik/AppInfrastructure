namespace AppInfrastructure.Stores.DefaultStore;

/// <summary>
///     Base lazy generic realize for IStore.
/// </summary>
/// <typeparam name="TValue">Value with some type</typeparam>
public class BaseLazyStore<TValue> : BaseLazyStore, IStore<TValue>
{
    #region CurrentValue
    
    public new virtual TValue? CurrentValue
    {
        get => (TValue?)_currentValue.Value;
        set
        {
            _currentValue =  new Lazy<object?>(() => value);
            OnCurrentValueChanged();
        }
    }

    #endregion

    #region Constructors

    public BaseLazyStore(TValue value) => CurrentValue = value;

    public BaseLazyStore(){}

    #endregion
    
}

/// <summary>
///     Base lazy realize for IStore.
/// </summary>
public class BaseLazyStore : IStore
{
    #region CurrentValue

    protected Lazy<object?> _currentValue = new (()=>default);
    
    public virtual object? CurrentValue
    {
        get => _currentValue.Value;
        set
        {
            _currentValue =  new Lazy<object?>(() => value);
            
            if(value is null || value == default)
                OnCurrentValueDeleted();
            
            OnCurrentValueChanged();
        }
    }

    #endregion

    #region CurrentValueChangedNotifier

    protected virtual void OnCurrentValueChanged() =>  CurrentValueChangedNotifier?.Invoke();
    public event Action? CurrentValueChangedNotifier;
    
    #endregion
    
    #region CurrentValueDeletedNotifier

    protected virtual void OnCurrentValueDeleted() =>  CurrentValueDeletedNotifier?.Invoke();
    public event Action? CurrentValueDeletedNotifier;

    #endregion

    #region Constructors

    public BaseLazyStore(object value) => CurrentValue = value;

    public BaseLazyStore(){}

    #endregion
    
}

