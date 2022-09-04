# AppInfrastructure

> P.S 
> 
>I'm a begining .Net programmer and It's my vision in creating Wpf and AvaloniaUI mvvm app infrastructure. 
> 
> I  don' have mentors and don't know how right do it. 
> 
> It's a problem for me because all what i do doesn't reviewing and many mistakes that i do could be avoid if i have mentor.
> 
> If i do something wrong u can say me about that. I will be grateful to you.


# Main Idea:

## Main idea that i use on all my latest Wpf (MvvM) project is separation project on units:

### 1. Stores 

> store information and notify when it changes.

<details>
  <summary>Store example</summary>

    public interface IStore
    {
   
        object? CurrentValue { get; set; } 

        //  Notify when value changed  
        event Action? CurrentValueChangedNotifier;  
    }

    // Simple relalization of IStore
    public class SimpleStore : IStore
    {

        private object? _currentValue;
    
        public object? CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                CurrentValueChangedNotifier?.Invoke();
            }
        }

        public event Action? CurrentValueChangedNotifier;
    }

    //example in Wpf app when store getting from outer sources (ex: IOC container/ other class etc)
    Public class example
    {
        private readonly IStore _simpleStore;
        
        //Getting information from store
        public object SomeInformation => _simpleStore.CurrentValue;
            
        public example(IStore simpleStore)
        {
            _simpleStore = simplestore;
            
            //When value changing notifier retranslating in INPC
            _sinpleStore.CurrentValueChangedNotifier += () => OnPropertyChanged(nameof(SomeInformation)); 
        }
    }

</details>

### 2. Services

> process some information. Usually working with stores.

<details>
  <summary>Services example</summary>
    
    //Something close service
    Public interface ICloseService
    {
        void Close();
    }

    //Simple close services that deleted value in store.
    public class SimpleStoreCloseServices
    {
        private readonly IStore _simpleStore;

        public SimpleStoreCloseServices(IStore simpleStore)
        {
            _simpleStore = simpleStore;
        }

        public void Close() => _simpleStore.CurrentValue = null;
    }

</details>

 #### Current services types:

- ICloseService: <- Close something
  - methods :
    - void close() 


- INavigationService: <- Navigate something
  - methods :
    - void Navigate() 


- IFullNavigationService: INavigationService + ICloseService based
  - methods :
    - void Navigate() 
    - void close() 


- IParamNavigationService: <- Navigate something with Generic parameter
  - methods :
    - void Navigate(TValue parameter)


- IFullParamNavigationService: IParamNavigationService + ICloseService based
  - methods :
    - void Navigate(TValue parameter)
    - void close()


### 3. Magazines

>IFullParamNavigationService based specific service that navigation by search something in collations dictionaries and put it in Store.


#### To better understand what i mean:

<details>
  <summary>Image</summary>

![Alt text](https://raw.githubusercontent.com/Htomsik/AppInfrastructure/master/AppInfrastructure/Resources/Structures/Magazine/Magazine.png)

</details>

#### Current magazines types:

- BaseLazyMagazineNavigationService: IParamNavigationService  based
- BaseLazyMagazineFullNavigationService : IFullParamNavigationService based


### 4. Repository 

> Store + service. It store information and allows more action that service.

<details>
  <summary>Repository example</summary>

> Example and Repositories will be adding in newest realeses

</details>


