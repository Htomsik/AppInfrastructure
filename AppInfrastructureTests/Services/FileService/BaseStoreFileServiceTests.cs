using AppInfrastructure.Services.FileService;
using AppInfrastructure.Services.ParserService;
using AppInfrastructure.Stores.DefaultStore;

namespace AppInfrastructureTests.Services.FileService;

[TestClass]
public class BaseStoreFileServiceTests 
{
    protected record Person
    {
        public string Name { get; set; }
        
        public int Age { get; set; }
    }
    
    protected class ParserService : IParserService
    {
        public string Serialize<T>(T nonSerialized) => fastJSON.JSON.ToJSON(nonSerialized);

        public T? DeSerialize<T>(string serialized) => fastJSON.JSON.ToObject<T>(serialized);
    }

    protected const string FileName  = "PersonInfo.json";
    protected readonly string  _directory = Directory.GetCurrentDirectory();

    protected readonly Person _person = new()
    {
        Age = 50,
        Name = "SomeName"
    };

    protected void DeleteFile()
    {
        if(File.Exists(Path.Combine(_directory, FileName)))
            File.Delete(Path.Combine(_directory, FileName));
    }

    public BaseStoreFileServiceTests()
    {
        DeleteFile();
    }
    
    #region Test Methods

    /// <summary>
    ///     Checks that data are equal after getting from file
    /// </summary>
    [TestMethod]
    public async Task IsRightSetGet()
    {
        //Arrange
        var personStore = new BaseLazyStore<Person>(_person);

        var saveService = new BaseStoreFileService<BaseLazyStore<Person>, Person>(personStore,new ParserService(),FileName, _directory);
        
        //Act
        await saveService.SetAsync();

        personStore.CurrentValue = null!;

        await saveService.GetAsync();
        
        //Assert
        Assert.IsNotNull(personStore.CurrentValue);
        Assert.AreEqual(_person,personStore.CurrentValue);
    }
    
    
    /// <summary>
    ///     Checks that files doesn't saved when data is null and parameter isNullIgnored = false
    /// </summary>
    [TestMethod]
    public async Task IsStoreCurrentValueIsNull()
    {
        //Arrange
        var personStore = new BaseLazyStore<Person>
        {
            CurrentValue = null!
        };

        var notIgnoreNullsSaveService = new BaseStoreFileService<BaseLazyStore<Person>, Person>(personStore,new ParserService(),FileName, _directory);
        
        var ignoreNullsSaveService = new BaseStoreFileService<BaseLazyStore<Person>, Person>(personStore,new ParserService(),FileName, _directory)
        {
            IgnoreNullS = true
        };
        
        //Act
        
        var isSaved = await ignoreNullsSaveService.SetAsync();

        //Assert
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(notIgnoreNullsSaveService.SetAsync);
        Assert.IsTrue(isSaved);
    }

    
    /// <summary>
    ///     Checks that data doesn't get when file doesn't exists
    /// </summary>
    [TestMethod]
    public async Task IsFileNotFound()
    {
        //Arrange
        var personStore = new BaseLazyStore<Person>();

        var saveService = new BaseStoreFileService<BaseLazyStore<Person>, Person>(personStore,new ParserService(),FileName, _directory);
        
        //Act
        DeleteFile();
        
        //Assert
        await Assert.ThrowsExceptionAsync<FileNotFoundException>(saveService.GetAsync);
    }
    
    /// <summary>
    ///     Checks that data doesn't get when file is null data
    /// </summary>
    [TestMethod]
    public async Task IsNullFile()
    {
        //Arrange
        var personStore = new BaseLazyStore<Person>();

        var saveService = new BaseStoreFileService<BaseLazyStore<Person>, Person>(personStore,new ParserService(),FileName, _directory)
        {
            IgnoreNullS = true
        };
        
        //Act
        DeleteFile();

        await saveService.SetAsync();

        saveService.IgnoreNullS = false;
        
        //Assert
        await Assert.ThrowsExceptionAsync<ArgumentNullException>(saveService.GetAsync);
    }
    
    #endregion
}